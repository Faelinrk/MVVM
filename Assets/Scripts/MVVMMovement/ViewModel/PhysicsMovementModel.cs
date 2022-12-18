using System;
using UniRx;
using UnityEngine;

namespace Models
{
    public sealed class PhysicsMovementModel : IDisposable
    {
        private ReactiveProperty<Vector3> _movementVector;
        public ReactiveProperty<Vector3> MovementVector
        {
            get
            {
                return _movementVector;
            }
            set
            {
                if (MovementVector == value)
                {
                    return;
                }
                _movementVector = value;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
