namespace Skibitsky.UniRxUI
{
    public interface IViewFor<T> where T : IPresenter
    {
        T Presenter { get; set; }

        void Initialise(T presenter);
    }
}