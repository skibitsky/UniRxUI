using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public class AddButtonPresenter : IAddButtonPresenter
    {
        public IReactiveCommand<Unit> AddCommand { get; } = new ReactiveCommand<Unit>();
    }
}