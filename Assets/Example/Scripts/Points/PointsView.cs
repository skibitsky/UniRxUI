using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Skibitsky.UniRxUI.Example
{
    public class PointsView : ReactiveView<IPointsPresenter>
    {
        [SerializeField] private Text pointsCountText;

        public override void Initialise(IPointsPresenter presenter)
        {
            base.Initialise(presenter);

            // Bind Presenter data to the UI component
            // Should be as simple as possible
            presenter.PointsAmountChanged
                .Select(p => p.ToString())
                .SubscribeToText(pointsCountText)
                .AddTo(gameObject);
        }
    }
}