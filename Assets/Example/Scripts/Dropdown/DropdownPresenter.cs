using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public class DropdownPresenter : IDropdownPresenter
    {
        public ReactiveCommand<int> ValueChanged { get; } = new ReactiveCommand<int>();

        public int InitialValue { get; protected set; } = 0;
    }
}