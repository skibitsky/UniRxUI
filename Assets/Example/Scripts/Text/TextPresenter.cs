using UniRx;

namespace Skibitsky.UniRxUI.Example
{
    public class TextPresenter : ITextPresenter
    {
        public StringReactiveProperty Text { get; set; } = new StringReactiveProperty("Empty");
    }
}