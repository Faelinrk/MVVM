using Interfaces;
using Models;
using System;
using UniRx;
using UnityEngine;

namespace ViewModels
{
    public sealed class PhysicsMovementViewModel : IPropertyChangeObserver<ReactiveProperty<Vector3>>, IDisposable
    {
        PhysicsMovementModel _textModel;

        public event Action<ReactiveProperty<Vector3>> OnPropertyChanged;

        public PhysicsMovementViewModel()
        {
            _textModel = new PhysicsMovementModel();
        }
        public ReactiveProperty<Vector3> MovementVector
        {
            get
            {
                return _textModel.MovementVector;
            }
            set
            {
                _textModel.MovementVector = value;
                NotifyPropertyChanged(_textModel.MovementVector);
            }
        }
        public void NotifyPropertyChanged(ReactiveProperty<Vector3> property)
        {
            OnPropertyChanged?.Invoke(property);
        }

        public void Dispose()
        {
            _textModel.Dispose();
        }
    }
}