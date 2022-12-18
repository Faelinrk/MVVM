using Interfaces;
using System;
using UniRx;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PhysicsMovementView : MonoBehaviour, IPropertyChangedObservable<ReactiveProperty<Vector3>>
    {
        private Rigidbody _rigidbody;
        private IPropertyChangeObserver<ReactiveProperty<Vector3>> _viewModel;
        private CompositeDisposable _disposables = new CompositeDisposable();


        public void Initialize(IPropertyChangeObserver<ReactiveProperty<Vector3>> viewModel)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _viewModel = viewModel;
            Observable.FromEvent<Action<ReactiveProperty<Vector3>>, ReactiveProperty<Vector3>>(
                h => h,
                h => _viewModel.OnPropertyChanged += h, h => _viewModel.OnPropertyChanged -= h)
                .Subscribe(vector => _rigidbody.velocity = vector.Value)
                .AddTo(_disposables);
        }
        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}