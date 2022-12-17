using UnityEngine.UI;
using UniRx;
using UnityEngine;
using ViewModels;

namespace Views
{
    public sealed class TextView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private TextViewModel _viewModel;
        CompositeDisposable disposables = new CompositeDisposable();

        private void Init(TextViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.OnPropertyChanged
                .AsObservable()
                .Subscribe(text => _text.text = text.Value)
                .AddTo(disposables);
        }
        void OnDestroy()
        {
            disposables.Dispose();
        }
    }
}