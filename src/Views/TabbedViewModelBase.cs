using System.Diagnostics;

namespace PolyhydraGames.Core.Maui.Views
{

    public abstract class TabbedViewModelBase : ViewModelAsyncBase
    {
        private readonly IServiceProvider _provider;
        public List<IViewModel> SubViewModels { get; } = new List<IViewModel>();
        protected IViewModel LastViewModel;
        protected TabbedViewModelBase(IServiceProvider provider)
        {
            _provider = provider;
        }
        protected void AddViewModel<T>() where T : IViewModel
        {
            var viewModel = _provider.GetRequiredService<T>();
            SubViewModels.Add(viewModel);
        }

        protected async Task LoadModelsAsync<T>(Func<T, Task> action) where T : class
        {
            foreach (var item in SubViewModels)
            {
                if (item is T local)
                {
                    await action(local);
                }
                else
                {
                    throw new Exception($"Type of {item.GetType()} was not {typeof(T)}");
                    Debug.WriteLine("SubViewModel was not loaded!");
                }
            }

        }

        public void OnIndexChanged(int index)
        {
            Debug.WriteLine($"Index changing to {index}");
            if (index < 0 || index >= SubViewModels.Count) return;
            LastViewModel?.OnDisappearing();
            var newViewModel = SubViewModels[index];
            LastViewModel = newViewModel;
            newViewModel.OnAppearing();
            Title = newViewModel.Title;
        }

        public virtual void OnDisappearing()
        {

        }
    }
}