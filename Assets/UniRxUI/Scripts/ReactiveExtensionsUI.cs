using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Skibitsky.UniRxUI
{
    // ReSharper disable once InconsistentNaming
    public static class ReactiveExtensionsUI
    {
        /// <summary>
        /// Bind ReactiveCommand to inputField's Interactable and OnValueChanged.
        /// </summary>
        public static IDisposable BindTo(this IReactiveCommand<int> command, Dropdown dropdown)
        {
            var d1 = command.CanExecute.SubscribeToInteractable(dropdown);
            var d2 = dropdown.OnValueChangedAsObservable().SubscribeWithState(command, (x, c) => c.Execute(x));
            return StableCompositeDisposable.Create(d1, d2);
        }
        
        public static IDisposable BindTo(this IReactiveCommand<string> command, InputField inputField)
        {
            var d1 = command.CanExecute.SubscribeToInteractable(inputField);
            var d2 = inputField.OnValueChangedAsObservable().SubscribeWithState(command, (x, c) => c.Execute(x));
            return StableCompositeDisposable.Create(d1, d2);
        }
        
        public static IDisposable SubscribeToImage(this UniRx.IObservable<Sprite> source, Image image)
        {
            return source.SubscribeWithState(image, (x, i) => image.sprite = x);
        }
    }
}