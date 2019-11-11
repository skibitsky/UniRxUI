using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public interface IPointsPresenter : IPresenter
    {
        IObservable<int> PointsAmountChanged { get; }
    }
}