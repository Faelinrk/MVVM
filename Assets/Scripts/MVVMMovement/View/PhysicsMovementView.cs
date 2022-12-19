using Interfaces;
using System;
using UniRx;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PhysicsMovementView : MonoBehaviour, IPropertyChangedObservable<Vector3>
    {
        private Rigidbody _rigidbody;
        private IPropertyChangeObserver<Vector3> _viewModel;
        private CompositeDisposable _disposables = new CompositeDisposable();


        public void Initialize(IPropertyChangeObserver<Vector3> viewModel)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _viewModel = viewModel;
            _viewModel.Property
                .Subscribe(vector => _rigidbody.velocity = vector)
                .AddTo(_disposables);
        }
        private void OnDestroy()
        {
            _disposables.Dispose();
        }
    }
}