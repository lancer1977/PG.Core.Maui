# Core.Maui Controls Audit (Deliverable 01)

Date: 2026-03-11

## Method

Reviewed `src/Controls/` and checked for references outside the controls folder using:

```bash
cd /home/lancer1977/code/Core.Maui
find src/Controls -type f \( -name '*.cs' -o -name '*.xaml' \) | sort
rg -n --glob '!src/Controls/**' --glob '!**/bin/**' --glob '!**/obj/**' "<TypeName>" src test README.md docs wiki
```

> Note: references found only in `src/PolyhydraGames.Core.Maui.csproj` (`<MauiXaml Update=...>`) are treated as packaging/build metadata, not active runtime usage.

## Categorization

### Active

- `PageBase` (used by `src/Views/MenuPage.xaml` and `MenuPage.xaml.cs`)
- `EntryPopup` / `EntryPopupViewModel` (used by `src/Services/PopupDialogService.cs`)

### Deprecated (candidate to keep temporarily, then migrate/remove)

These are included in project build metadata but have no runtime references outside `src/Controls/`:

- `BusyPageTemplate`
- `DisplayCell`
- `DisplayableView`
- `LabelButton`
- `ListPageBase`
- `ListWithClickPageBase`
- `MultiPickerDialogPage`

### Remove (no external references found)

No external references found in `src/`, `test/`, docs, or README:

- `CheckBox`
- `ContentViewBase` (duplicate file exists under `Controls/Abstracts/ContentViewBase.cs`)
- `EntryStyle`
- `ExpandableView`
- `GridView`
- `ListItemPickerViewModel`
- `ModelTargetType`
- `MultiPickerDialogViewModel`
- `MultiPickerExtensions`
- `MultiPickerItem`
- `PopupPageBase`
- `TextView`
- `UserControl`

## Recommended Next Steps

1. Remove `Remove` items in a separate deliverable with compile verification.
2. Decide whether deprecated items should be migrated to actively used views or removed.
3. Resolve `ContentViewBase` duplication by standardizing on one class/location.
