using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Skibitsky.UniRxUI.Example
{
    [RequireComponent(typeof(Button))]
    public class AddButtonView : ReactiveView<IAddButtonPresenter>
    {
        private Button _button;
        
        protected override void Awake()
        {
            base.Awake();
            _button = GetComponent<Button>();
        }

        public override void Initialise(IAddButtonPresenter presenter)
        {
            base.Initialise(presenter);

            // Bind button click event and interactable state to reactive command
            presenter.AddCommand
                .BindTo(_button)
                .AddTo(gameObject);
        }
    }
}