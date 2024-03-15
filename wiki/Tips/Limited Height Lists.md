StackLayout with BindableLayouts may be a solution
Include Bindable.Items, this can work with other data types as well.
BindableLayout.ItemSource
BindableLayout.ItemTemplate

Consider using a gesture recognizer on the item in the template and binding it to the command on the binding context of containing page.