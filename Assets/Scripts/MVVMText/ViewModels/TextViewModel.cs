using Interfaces;
using Models;
using System;
using UniRx;

namespace ViewModels
{
    public sealed class TextViewModel : IPropertyChangeObserver<string>, IDisposable
    {
        private TextModel _textModel;

        public TextViewModel()
        {
            _textModel = new TextModel();
        }
        public ReactiveProperty<string> Property
        {
            get
            {
                return _textModel.Text;
            }
            set
            {
                _textModel.Text = value;
            }
        }

        public void Dispose()
        {
            _textModel.Dispose();
        }
    }
}