using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Skibitsky.UniRxUI.Example
{
    public class DropdownView : ReactiveView<IDropdownPresenter>
    {
        [SerializeField] private Dropdown dropdown;

        public override void Initialise(IDropdownPresenter presenter)
        {
            base.Initialise(presenter);

            dropdown.value = presenter.InitialValue;

            presenter.ValueChanged
                .BindTo(dropdown)
                .AddTo(gameObject);
        }
    }
}