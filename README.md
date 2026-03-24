# PG.Core.Maui
Maui helpers. This project represents a collection of old Xamarin Forms classes and helpers I made to aide my old apps reuse. 

## Status (Updated 2026-03-12)

**Legacy Controls Cleanup Complete:**

The following controls have been marked with `[Obsolete]` attribute and should not be used for new development:

| Control | Status | Recommended Alternative |
|---------|--------|------------------------|
| `UserControl` | [Obsolete] | Use `ContentView` directly |
| `GridView` | [Obsolete] | Use `CollectionView` with `GridItemsLayout` |
| `ListPageBase` | [Obsolete] | Use `CollectionView` with `DataTemplateSelector` |
| `ListWithClickPageBase` | [Obsolete] | Use `CollectionView` with `SelectionChanged` |
| `Checkbox` (custom) | [Obsolete] | Use MAUI's built-in `CheckBox` |
| `DisplayCell` | [Obsolete] | Use `CollectionView` with `DataTemplate` |
| `DisplayableView` | [Obsolete] | Use `ContentView` directly |
| `TextView` | [Obsolete] | Use `Label` directly |
| `LabelButton` | [Obsolete] | Use `Label` with `TapGestureRecognizer` |

**Converters:** All converters remain active and recommended. See [[Converters]] for details.

**Wiki:** Updated with current component status and recommendations.

## Original Notes

Some of these I am leaving intact to support porting if they don't feel too obnoxious, others I'm deleting outright if I feel they are hazardous patterns. I may comment out things and leave todos in place for areas I wish to clean up and re-write some Maui-ish code I feel needs attention. Time will tell. I've been out of the mobile game for a bit and need to brush up.

![[Models]]

![[Controls]]

[[Converters]]

## 📖 Documentation
Detailed documentation can be found in the following sections:
- [Feature Index](./docs/features/README.md)
- [Core Capabilities](./docs/features/core-capabilities.md)
