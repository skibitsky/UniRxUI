using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Skibitsky.UniRxUI.Example
{
    [RequireComponent(typeof(Button))]
    public class UpdatePointsButtonView : ReactiveView<IUpdatePointsButtonPresenter>
    {
        private Button _button;
        
        protected override void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        public override void Initialise(IUpdatePointsButtonPresenter presenter)
        {
            base.Initialise(presenter);

            presenter.UpdatePointsCommand
                .BindTo(_button)
                .AddTo(gameObject);
        }
    }
}