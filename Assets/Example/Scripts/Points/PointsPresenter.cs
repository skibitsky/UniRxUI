using System;
using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public class PointsPresenter : IPointsPresenter
    {
        public PointsPresenter(IReadOnlyReactiveProperty<int> pointsAmount)
        {
            // Update Points Amount Label Gradually
            PointsAmountChanged = pointsAmount
                .Skip(1)
                .Scan(new {Previous = 0, Current = pointsAmount.Value},
                    (accumulator, newVal) => new {Previous = accumulator.Current, Current = newVal})
                .Select(pair =>
                {
                    var direction = pair.Current > pair.Previous ? 1 : -1;

                    return Observable.Interval(TimeSpan.FromMilliseconds(30))
                        .Scan(pair.Previous, (accumulator, _) => accumulator + direction)
                        .TakeWhile(val => val != pair.Current + direction);
                })
                .Switch()
                .StartWith(pointsAmount.Value);
        }

        public UniRx.IObservable<int> PointsAmountChanged { get; }
    }
}