using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Skibitsky.UniRxUI.Example
{
    public class TextView : ReactiveView<ITextPresenter>
    {
        [SerializeField] private Text text;

        public override void Initialise(ITextPresenter presenter)
        {
            base.Initialise(presenter);

            presenter.Text
                .SubscribeToText(text)
                .AddTo(gameObject);
        }
    }
}