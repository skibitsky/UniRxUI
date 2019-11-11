using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public interface IUpdatePointsButtonPresenter : IPresenter
    {
        IReactiveCommand<Unit> UpdatePointsCommand { get; }
    }
}