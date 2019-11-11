using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public class UpdatePointsButtonPresenter : IUpdatePointsButtonPresenter
    {
        public IReactiveCommand<Unit> UpdatePointsCommand { get; } = new ReactiveCommand<Unit>();
    }
}