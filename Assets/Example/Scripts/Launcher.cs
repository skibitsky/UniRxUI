using UniRx;
using UnityEngine;

namespace Skibitsky.UniRxUI.Example
{
    public class Launcher : MonoBehaviour
    {
        // Assume this is our model :)
        private readonly IReactiveProperty<int> _points = new ReactiveProperty<int>();
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
            addendumPresenter.AddendumChanged
                .Select(int.Parse)
                .Subscribe(i => _pointsAddendum = i)
                .AddTo(gameObject);

        }
    }
}