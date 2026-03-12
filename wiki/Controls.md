# Controls

These are mostly a collection of poorly implemented controls from my Xamarin days ported over to support classic apps. 

## Status (Updated 2026-03-12)

**DEPRECATED - Marked with [Obsolete]:**
- `UserControl` - Legacy Xamarin.Forms pattern. Use `ContentView` directly.
- `GridView` - Legacy control. Use `CollectionView` with `GridItemsLayout`.
- `ListPageBase` - Legacy Xamarin.Forms pattern. Use `CollectionView` with `DataTemplateSelector`.
- `ListWithClickPageBase` - Legacy Xamarin.Forms pattern. Use `CollectionView` with `SelectionChanged`.
- `Checkbox` (custom) - Legacy control. Use MAUI's built-in `CheckBox`.
- `DisplayCell` - Uses `ViewCell` which is Xamarin.Forms specific. Use `CollectionView` with `DataTemplate`.
- `DisplayableView` - Legacy control. Use `ContentView` directly.
- `TextView` - Legacy control. Use `Label` directly.
- `LabelButton` - Legacy control. Use `Label` with `TapGestureRecognizer`.

**RECOMMENDED ALTERNATIVES:**
- For list/grid scenarios: Use `CollectionView` with `GridItemsLayout` or `LinearItemsLayout`
- For checkboxes: Use MAUI's built-in `CheckBox` control
- For custom content: Inherit from `ContentView` directly
- For labels with tap: Use `Label` with `TapGestureRecognizer`

I really recommend not using these legacy controls and considering modern MAUI alternatives at this point. I may update this eventually.