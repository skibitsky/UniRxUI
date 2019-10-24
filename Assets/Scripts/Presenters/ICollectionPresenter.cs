using UniRx;

namespace Skibitsky.UniRxUI
{
    public interface ICollectionPresenter<T> : IPresenter where T : IPresenter
    {
        ReactiveCollection<T> Collection { get; }
    }
}