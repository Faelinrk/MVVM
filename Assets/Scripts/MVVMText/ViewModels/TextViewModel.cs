using Interfaces;
using Models;
using System;
using UniRx;

namespace ViewModels
{
    public sealed class TextViewModel : IPropertyChangeObserver<ReactiveProperty<string>>, IDisposable
    {
        private TextModel _textModel;

        public event Action<ReactiveProperty<string>> OnPropertyChanged;

        public TextViewModel()
        {
            _textModel = new TextModel();
        }
        public ReactiveProperty<string> Text
        {
            get
            {
                return _textModel.Text;
            }
            set
            {
                _textModel.Text = value;
                NotifyPropertyChanged(_textModel.Text);
            }
        }
        public void NotifyPropertyChanged(ReactiveProperty<string> property)
        {
            OnPropertyChanged?.Invoke(property);
        }

        public void Dispose()
        {
            _textModel.Dispose();
        }
    }
}