using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using ViewModels;
using Views;

public sealed class Entrance : MonoBehaviour
{
    public AssetReference CanvasPrefab;
    private ViewSpawner<TextView, TextViewModel, ReactiveProperty<string>> _spawner;
    private void Start()
    {
        _spawner = new ViewSpawner<TextView, TextViewModel, ReactiveProperty<string>>();
        PrepareObjectsOnStart();
    }
    private async UniTask PrepareObjectsOnStart()
    {
        TextViewModel viewModel = await _spawner.InstantiateViewAndGetViewModelAsync(CanvasPrefab, new TextViewModel());
        viewModel.Text = new ReactiveProperty<string>("blablablabla");
    }
}
