using System;
using UniRx;

namespace Models
{
    public sealed class TextModel : IDisposable
    {
        private ReactiveProperty<string> _text;
        public ReactiveProperty<string> Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (Text == value)
                {
                    return;
                }
                _text = value;
            }
        }

        public void Dispose()
        {
            
        }
    }
}