using UniRx;
using UnityEngine;

namespace Skibitsky.UniRxUI.Example
{
    public class Launcher : MonoBehaviour
    {
        // Assume this is our model :)
        private readonly IReactiveProperty<int> _points = new ReactiveProperty<int>(10);
        private int _pointsAddendum = 1;
        
        private void Start()
        {
            // Get reference to the view (you can do this with DI or SerializeField)
            var pointsView = FindObjectOfType<ReactiveView<IPointsPresenter>>();
            // Create Points Presenter and pass our model's properties to it
            var pointsPresenter = new PointsPresenter(_points);
            // Initialise view with our presenter
            pointsView.Initialise(pointsPresenter);

            var addendumView = FindObjectOfType<ReactiveView<IAddendumPresenter>>();
            var addendumPresenter = new AddendumPresenter();
            addendumView.Initialise(addendumPresenter);
            // Update local addendum variable
            addendumPresenter.AddendumChanged
                .Select(int.Parse)
                .OnErrorRetry()
                .Subscribe(i => _pointsAddendum = i)
                .AddTo(gameObject);

            var addButtonView = FindObjectOfType<AddButtonView>();
            var addButtonPresenter = new AddButtonPresenter();
            addButtonView.Initialise(addButtonPresenter);
            // Update Points using Addendum
            addButtonPresenter.AddCommand
                .Subscribe(_ => _points.Value += _pointsAddendum)
                .AddTo(gameObject);
        }
    }
}