using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Interfaces;
using UniRx;

public sealed class ViewSpawner<T, T2, T3> where T : IPropertyChangedObservable<T3> where T2: IPropertyChangeObserver<T3>
{
        private AsyncOperationHandle<GameObject> _currentUnitHandle;
        private GameObject _unitInstance;

        public async UniTask<T2> InstantiateViewAndGetViewModelAsync(AssetReference assetReference, T2 viewModel)
        {
            if (_currentUnitHandle.IsValid())
            {
                Addressables.Release(_currentUnitHandle);
            }
            _currentUnitHandle = assetReference.LoadAssetAsync<GameObject>();
            var unitInstance = assetReference.InstantiateAsync();
            await unitInstance;
            if (unitInstance.Status == AsyncOperationStatus.Succeeded)
            {
                _unitInstance = unitInstance.Result;
            }
            _unitInstance.GetComponentInChildren<T>().Initialize(viewModel);
            return viewModel;
        }
}
