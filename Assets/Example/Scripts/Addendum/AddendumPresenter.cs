using UniRx;
using UnityEngine;

namespace Skibitsky.UniRxUI.Example
{
    public class AddendumPresenter : IAddendumPresenter
    {
        public ReactiveCommand<string> AddendumChanged { get; } = new ReactiveCommand<string>();
    }
}