using Models;
using UniRx;
using UnityEngine.Events;

namespace ViewModels
{
    public sealed class TextViewModel
    {
        TextModel textModel;
        public UnityEvent<ReactiveProperty<string>> OnPropertyChanged;
        public TextViewModel()
        {
            textModel = new TextModel();
            OnPropertyChanged = new UnityEvent<ReactiveProperty<string>>();
        }
        public ReactiveProperty<string> Text
        {
            get
            {
                return textModel.Text;
            }
            set
            {
                textModel.Text = value;
                NotifyPropertyChanged(textModel.Text);
            }
        }

        public void NotifyPropertyChanged(ReactiveProperty<string> property)
        {
            OnPropertyChanged.Invoke(property);
        }
    }
}