using UnityEngine;

namespace Skibitsky.UniRxUI
{
    public class ReactiveView<T> : MonoBehaviour, IViewFor<T> where T : IPresenter
    {
        // ReSharper disable once MemberCanBePrivate.Global
        protected RectTransform Transform;
        public T Presenter { get; set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }

        public virtual void Initialise(T presenter)
        {
            Presenter = presenter;
        }
    }
}