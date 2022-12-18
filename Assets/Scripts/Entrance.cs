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
    private ViewSpawner<TextView, TextViewModel, ReactiveProperty<string>> _textSpawner;
    private ViewSpawner<PhysicsMovementView, PhysicsMovementViewModel, ReactiveProperty<Vector3>> _productSpawner;
    private void Start()
    {
        _textSpawner = new ViewSpawner<TextView, TextViewModel, ReactiveProperty<string>>();
        _productSpawner = new ViewSpawner<PhysicsMovementView, PhysicsMovementViewModel, ReactiveProperty<Vector3>>();
        PrepareObjects();
    }
    private async UniTask PrepareObjects()
    {
        TextViewModel textViewModel = await _textSpawner.InstantiateViewAndGetViewModelAsync(CanvasPrefab, new TextViewModel());
        PhysicsMovementViewModel physicsMovementViewModel = await _productSpawner.InstantiateViewAndGetViewModelAsync(ProductPrefab, new PhysicsMovementViewModel());
        textViewModel.Text = new ReactiveProperty<string>("Testing for a moment...");
        physicsMovementViewModel.MovementVector = new ReactiveProperty<Vector3>(new Vector3(Random.Range(-5,5), Random.Range(-5,5), Random.Range(-5,5)));
    }
}
