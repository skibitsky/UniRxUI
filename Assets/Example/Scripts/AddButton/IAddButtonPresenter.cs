using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public interface IAddButtonPresenter : IPresenter
    {
        IReactiveCommand<Unit> AddCommand { get; }
    }
}