using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public interface IAddendumPresenter : IPresenter
    {
        ReactiveCommand<string> AddendumChanged { get; }
    }
}