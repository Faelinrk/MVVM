using Models;
using System;
using UniRx;
using UnityEngine.Events;
using Interfaces;

namespace ViewModels
{
    public sealed class TextViewModel : IPropertyChangeObserver<ReactiveProperty<string>>, IDisposable
    {
        TextModel textModel;

        public event Action<ReactiveProperty<string>> OnPropertyChanged;

        public TextViewModel()
        {
            textModel = new TextModel();
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
            OnPropertyChanged?.Invoke(property);
        }

        public void Dispose()
        {
            textModel.Dispose();
        }
    }
}