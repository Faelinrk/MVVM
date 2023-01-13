using Interfaces;
using Models;
using System;
using UniRx;
using UnityEngine;

namespace ViewModels
{
    public sealed class PhysicsMovementViewModel : IPropertyChangeObserver<Vector3>, IDisposable
    {
        PhysicsMovementModel _textModel;

        public PhysicsMovementViewModel()
        {
            _textModel = new PhysicsMovementModel();
        }
        public ReactiveProperty<Vector3> Property
        {
            get
            {
                return _textModel.MovementVector;
            }
            set
            {
                _textModel.MovementVector = value;
            }
        }

        public void Dispose()
        {
            _textModel.Dispose();
        }
    }
}