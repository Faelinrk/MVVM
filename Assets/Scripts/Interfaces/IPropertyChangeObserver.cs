using System;

namespace Interfaces
{
    public interface IPropertyChangeObserver<T>
    {
        event Action<T> OnPropertyChanged;
        void NotifyPropertyChanged(T property);
    }
}
