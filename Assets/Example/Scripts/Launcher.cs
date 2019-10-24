using UniRx;
using UnityEngine;

namespace Skibitsky.UniRxUI.Example
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private DropdownView dropdownView;
        [SerializeField] private TextView textView;
        private void Start()
        {
            // Init text
            var text = new TextPresenter();
            textView.Initialise(text);
            
            // Init dropdown
            var dropdown = new DropdownPresenter();
            dropdownView.Initialise(dropdown);

            // Bind text to dropdown index change
            dropdown.ValueChanged
                .Subscribe(v => text.Text.Value = $"Dropdown index: {v.ToString()}")
                .AddTo(gameObject);
        }
    }
}