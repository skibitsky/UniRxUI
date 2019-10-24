using UnityEngine;
using UniRx;

namespace Skibitsky.UniRxUI
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class CollectionView<T> : ReactiveView<ICollectionPresenter<T>> where T : IPresenter
    {
        /// <summary>
        /// Collection element's View that will be used as the template
        /// </summary>
        protected virtual ReactiveView<T> Template { get; }

        protected virtual void Awake()
        {
            // Make sure that template is not visible
            Template.gameObject.SetActive(false);
        }

        public override void Initialise(ICollectionPresenter<T> presenter)
        {
            base.Initialise(presenter);

            // Spawn all existing collection's elements
            for (var i = 0; i < presenter.Collection.Count; i++)
            {
                InstantiateNewElement(i, presenter.Collection[i]);
            }

            // Add new collection items
            presenter.Collection
                .ObserveAdd()
                .Subscribe(e => InstantiateNewElement(e.Index, e.Value))
                .AddTo(gameObject);
            
            // Remove element from collection
            presenter.Collection
                .ObserveRemove()
                .Subscribe(e => RemoveElement(e.Index))
                .AddTo(gameObject);
            
            // Replace element
            presenter.Collection
                .ObserveReplace()
                .Subscribe(e => ReplaceElement(e.Index, e.NewValue))
                .AddTo(gameObject);
        }

        private void InstantiateNewElement(int index, T value)
        {
            // Spawn game object
            var tr = Instantiate(Template.gameObject).transform;
            // Set parent to this view
            tr.SetParent(transform);
            // Make sibling index to match collection's index
            tr.SetSiblingIndex(index);
            // Make sure the scale is correct
            tr.localScale = Vector3.one;
            // Enable game object
            tr.gameObject.SetActive(true);
            
            // Get element's view and initialise it
            var view = tr.GetComponent<ReactiveView<T>>();
            view.Initialise(value);
        }

        private void RemoveElement(int index)
        {
            Destroy(transform.GetChild(index).gameObject);
        }

        private void ReplaceElement(int index, T newValue)
        {
            // Can be optimised
            RemoveElement(index);
            InstantiateNewElement(index, newValue);
        }
    }
}