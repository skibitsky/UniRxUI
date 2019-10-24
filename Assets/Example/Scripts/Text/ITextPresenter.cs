using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public interface ITextPresenter : IPresenter
    {
        StringReactiveProperty Text { get; }
    }
}