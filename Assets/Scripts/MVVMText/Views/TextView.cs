using System;
using TMPro;
using UniRx;
using UnityEngine;
using ViewModels;
using Interfaces;

namespace Views
{
    public sealed class TextView : MonoBehaviour, IPropertyChangedObservable<ReactiveProperty<string>>
    {
        private TMP_Text _text;
        private IPropertyChangeObserver<ReactiveProperty<string>> _viewModel;
        private CompositeDisposable _disposables = new CompositeDisposable();


        public void Initialize(IPropertyChangeObserver<ReactiveProperty<string>> viewModel)
        {
            _text = GetComponent<TMP_Text>();
            _viewModel = viewModel;
            Observable.FromEvent<Action<ReactiveProperty<string>>, ReactiveProperty<string>>(
                h => h,
                h => _viewModel.OnPropertyChanged += h, h => _viewModel.OnPropertyChanged -= h)
                .Subscribe(text => _text.text = text.Value)
                .AddTo(_disposables);
        }
        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}