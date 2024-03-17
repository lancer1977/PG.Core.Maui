using CommunityToolkit.Maui.Views;

namespace PolyhydraGames.Core.Maui.Controls
{


    public abstract class ExpandableViewBase : ContentView
    {
        public static readonly BindableProperty ContentProperty =
            BindableProperty.Create(nameof(Content), typeof(IView), typeof(ExpandableViewBase), null, propertyChanged:
                (bindable, value, newValue) =>
                {
                    var view = (ExpandableViewBase)bindable;
                    view.Expander.Content = newValue as IView;
                });

        public IView? Content
        {
            get { return (IView)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }


        public Expander Expander { get; set; } = new();
        public INotifyPropertyChanged ViewModel => (INotifyPropertyChanged)BindingContext;
        protected ExpandableViewBase()
        {
            BindingContextChanged += OnBindingContextChanged;
        }
        public void Dispose()
        {
            if (ViewModel == null) return;
            ViewModel.PropertyChanged -= ViewModelOnPropertyChanged;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {

            if (ViewModel != null)
            {
                ViewModel.PropertyChanged -= ViewModelOnPropertyChanged;
            }
            ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsExpanded")
            {
                Expander.ForceLayout();
            }
            if (e.PropertyName == "CountChanged")
            {
                Expander.ForceLayout();
            }
        }
    }
}