namespace PolyhydraGames.Core.Maui.Controls
{
    public partial class Checkbox 
    {
        public Checkbox()
        {
            InitializeComponent(); 
        }
        public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title",
            typeof(string),
            typeof(Checkbox),
            string.Empty,
            BindingMode.OneWay,
            propertyChanged: TitlePropertyChanged);

        private static void TitlePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var titleLabel = (Checkbox)bindable;
            titleLabel.title.Text = (string)newvalue;
        }

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create("IsChecked",
            typeof(bool),
            typeof(Checkbox),
            null,
            BindingMode.OneWay,
            
            propertyChanged: CheckedPropertyChanged);

        private static void CheckedPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (Checkbox)bindable;
            var ischecked = (bool)newvalue;
            control.checkbox.IsChecked = ischecked; 
        }

 
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

       
    }
}
