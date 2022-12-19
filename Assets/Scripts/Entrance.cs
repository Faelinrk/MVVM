using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using ViewModels;
using Views;

public sealed class Entrance : MonoBehaviour
{
    public AssetReference CanvasPrefab;
    public AssetReference ProductPrefab;
    private ViewSpawner<TextView, TextViewModel, string> _textSpawner;
    private ViewSpawner<PhysicsMovementView, PhysicsMovementViewModel, Vector3> _productSpawner;
    private void Start()
    {
        _textSpawner = new ViewSpawner<TextView, TextViewModel, string>();
        _productSpawner = new ViewSpawner<PhysicsMovementView, PhysicsMovementViewModel, Vector3>();
        PrepareObjects();
    }
    private async UniTask PrepareObjects()
    {
        TextViewModel textViewModel = await _textSpawner.InstantiateViewAndGetViewModelAsync(CanvasPrefab, new TextViewModel());
        PhysicsMovementViewModel physicsMovementViewModel = await _productSpawner.InstantiateViewAndGetViewModelAsync(ProductPrefab, new PhysicsMovementViewModel());
        textViewModel.Property.Value = "Testing for a moment...";
        physicsMovementViewModel.Property.Value = new Vector3(Random.Range(-5,5), Random.Range(-5,5), Random.Range(-5,5));
    }
}
