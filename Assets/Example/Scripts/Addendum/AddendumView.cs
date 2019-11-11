using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Skibitsky.UniRxUI.Example
{
    public class AddendumView : ReactiveView<IAddendumPresenter>
    {
        [SerializeField] private InputField AddendumInputField;
        public override void Initialise(IAddendumPresenter presenter)
        {
            base.Initialise(presenter);

            presenter.AddendumChanged
                .BindTo(AddendumInputField)
                .AddTo(gameObject);
        }
    }
}