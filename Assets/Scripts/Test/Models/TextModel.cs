using UniRx;

namespace Models
{
    public sealed class TextModel
    {
        private ReactiveProperty<string> text;
        public ReactiveProperty<string> Text
        {
            get
            {
                return text;
            }
            set
            {
                if (Text == value)
                {
                    return;
                }
                text = value;
            }
        }
    }
}