using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public interface IDropdownPresenter : IPresenter
    {
        ReactiveCommand<int> ValueChanged { get; }

        int InitialValue { get; }
    }
}