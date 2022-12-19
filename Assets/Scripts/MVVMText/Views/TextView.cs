using System;
using TMPro;
using UniRx;
using UnityEngine;
using ViewModels;
using Interfaces;

namespace Views
{
    public sealed class TextView : MonoBehaviour, IPropertyChangedObservable<string>
    {
        private TMP_Text _text;
        private IPropertyChangeObserver<string> _viewModel;
        private CompositeDisposable _disposables = new CompositeDisposable();


        public void Initialize(IPropertyChangeObserver<string> viewModel)
        {
            _text = GetComponent<TMP_Text>();
            _viewModel = viewModel;
            _viewModel.Property
                .Subscribe(text => _text.text = text)
                .AddTo(_disposables);
        }
        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}