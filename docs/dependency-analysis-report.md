# Core.Maui Dependency Analysis Report

**Generated:** 2026-03-12
**Analyzer:** crash-override

## Executive Summary

Core.Maui is consumed by 4 projects:
- KonaTracker (KonaAnalyzer.Maui)
- LearningTools (SpellingTest.Maui)
- GameCollector (GCD.Maui)
- rpg-pf-assistant (PFAssistant.MauiApp)

The wiki notes that Controls are "poorly implemented legacy Xamarin code" and recommends considering alternatives. This analysis identifies which components are actively used vs safe to deprecate.

---

## Component Usage Summary

### Controls (src/Controls/)

| Control | Usage Count | Status |
|---------|-------------|--------|
| **TextView** | 347 | ⚠️ **KEEP** - Heavy usage |
| **PageBase** | 269 | ⚠️ **KEEP** - Core infrastructure |
| **CheckBox** | 54 | ⚠️ **KEEP** - Active use |
| **PopupPageBase** | 33 | ⚠️ **KEEP** - Active use |
| **EntryPopup** | 12 | ⚠️ **KEEP** - Active use |
| **ListPageBase** | 7 | ⚠️ **KEEP** - Active use |
| **ContentViewBase** | 7 | ⚠️ **KEEP** - Active use |
| **LabelButton** | 4 | ⚠️ **KEEP** - Active use |
| **UserControl** | 4 | ⚠️ **KEEP** - Active use |
| **DisplayableView** | 2 | ⚠️ **KEEP** - Light use |
| **DisplayCell** | 2 | ⚠️ **KEEP** - Light use |
| **ExpandableView** | 0 | ❌ **DEPRECATE** - No usage |
| **GridView** | 0 | ❌ **DEPRECATE** - No usage |
| **BusyPageTemplate** | 0 | ⚠️ **REVIEW** - May be internal |
| **MultiPickerDialog** | 0 | ⚠️ **REVIEW** - May be internal |

### Converters (src/Converters/)

| Converter | Usage Count | Status |
|-----------|-------------|--------|
| **Converter** | 15 | ⚠️ **KEEP** - Base class |
| **TypedConverter** | 2 | ⚠️ **KEEP** - Base class |
| **BooleanConverter** | 1 | ⚠️ **KEEP** - Light use |
| **StringToVisibilityConverter** | 1 | ⚠️ **KEEP** - Light use |
| **HexStringToColorConverter** | 0 | ❌ **DEPRECATE** - No usage |
| **ImageToVisibilityConverter** | 0 | ❌ **DEPRECATE** - No usage |
| **InverseBooleanConverter** | 0 | ❌ **DEPRECATE** - No usage |

### Services (src/Services/)

| Service | Usage Count | Status |
|---------|-------------|--------|
| **DialogService** | 313 | ⚠️ **KEEP** - Core infrastructure |
| **ItemPicker** | 56 | ⚠️ **KEEP** - Active use |
| **MainThreadDispatcher** | 33 | ⚠️ **KEEP** - Core infrastructure |
| **NavigatorService** | 17 | ⚠️ **KEEP** - Active use |
| **HttpService** | 15 | ⚠️ **KEEP** - Active use |
| **SoundService** | 14 | ⚠️ **KEEP** - Active use |
| **FilePickerService** | 10 | ⚠️ **KEEP** - Active use |
| **SettingService** | 7 | ⚠️ **KEEP** - Light use |
| **TokenService** | 0 | ⚠️ **REVIEW** - May be internal |
| **HistoryService** | 0 | ⚠️ **REVIEW** - May be internal |
| **AuthenticatorService** | 0 | ⚠️ **REVIEW** - May be internal |

### Views (src/Views/)

| View | Usage Count | Status |
|------|-------------|--------|
| **MenuPage** | 20 | ⚠️ **KEEP** - Active use |
| **TabbedPageBase** | 20 | ⚠️ **KEEP** - Active use |
| **RootPage** | 9 | ⚠️ **KEEP** - Active use |
| **WebPageBase** | 9 | ⚠️ **KEEP** - Active use |
| **TabbedViewModelBase** | 2 | ⚠️ **KEEP** - Light use |

### Models (src/Models/)

| Model | Usage Count | Status |
|-------|-------------|--------|
| **ToggleBoolean** | 9 | ⚠️ **KEEP** - Active use |

### Interfaces (src/Interfaces/)

| Interface | Status |
|-----------|--------|
| **IApp** | ⚠️ **KEEP** - Core interface |
| **IViewFactoryAsync** | ⚠️ **KEEP** - Core interface |
| **IViewNavigator** | ⚠️ **KEEP** - Core interface |
| **IFirstPageViewModelAsync** | ⚠️ **KEEP** - Core interface |
| **IPopupPage** | ⚠️ **KEEP** - Core interface |

### Navigation (src/Navigation/)

| Component | Status |
|-----------|--------|
| **NavigatorAsync** | ⚠️ **KEEP** - Core infrastructure |
| **ViewFactoryAsync** | ⚠️ **KEEP** - Core infrastructure |
| **NavigationExtensions** | ⚠️ **KEEP** - Active use |

### Setup (src/Setup/)

| Component | Status |
|-----------|--------|
| **AppBuilder** | ⚠️ **KEEP** - Core startup |
| **MauiSetup** | ⚠️ **KEEP** - Core startup |
| **DeviceModule** | ⚠️ **KEEP** - Platform integration |
| **ViewModelModule** | ⚠️ **KEEP** - Core registration |

---

## Safe to Remove (No Usage Found)

### Controls
- `ExpandableView.xaml.cs` - No consumer usage
- `GridView.cs` - No consumer usage

### Converters
- `HexStringToColorConverter.cs` - No consumer usage
- `ImageToVisibilityConverter.cs` - No consumer usage
- `InverseBooleanConverter.cs` - No consumer usage

---

## Must Keep (Active Usage)

### High Priority (>100 uses)
- `TextView` - 347 uses
- `PageBase` - 269 uses
- `DialogService` - 313 uses

### Medium Priority (10-100 uses)
- `CheckBox` - 54 uses
- `ItemPicker` - 56 uses
- `PopupPageBase` - 33 uses
- `MainThreadDispatcher` - 33 uses
- `MenuPage` - 20 uses
- `TabbedPageBase` - 20 uses
- `NavigatorService` - 17 uses
- `HttpService` - 15 uses
- `EntryPopup` - 12 uses

### Low Priority (<10 uses but active)
- `ListPageBase`, `ContentViewBase`, `LabelButton`, `UserControl`, `DisplayableView`, `DisplayCell`
- `FilePickerService`, `SettingService`, `SoundService`
- `RootPage`, `WebPageBase`, `TabbedViewModelBase`
- `ToggleBoolean`

---

## Recommendations

1. **Mark for Deprecation (Add [Obsolete] attribute):**
   - `ExpandableView` - No usage, can be removed in next major version
   - `GridView` - No usage, can be removed in next major version
   - `HexStringToColorConverter` - No usage
   - `ImageToVisibilityConverter` - No usage
   - `InverseBooleanConverter` - No usage

2. **Keep but Document as Legacy:**
   - All Controls with active usage should have documentation noting they're legacy Xamarin ports
   - Consider modern alternatives for new projects

3. **Review for Internal Usage:**
   - `BusyPageTemplate`, `MultiPickerDialog` - Check if used internally or in tests
   - `TokenService`, `HistoryService`, `AuthenticatorService` - May be internal infrastructure

4. **Update Wiki:**
   - Add specific deprecation notes for unused components
   - Document migration paths for deprecated components

---

## Validation Commands

```bash
# Verify component usage
grep -r "ExpandableView" ~/code/KonaTracker ~/code/LearningTools ~/code/GameCollector ~/code/rpg-pf-assistant --include="*.cs" | wc -l
# Expected: 0

grep -r "TextView" ~/code/KonaTracker ~/code/LearningTools ~/code/GameCollector ~/code/rpg-pf-assistant --include="*.cs" | wc -l
# Expected: >300

# Check solution references
grep -r "PolyhydraGames.Core.Maui" ~/code/*/src/*.csproj ~/code/*/*.csproj --include="*.csproj"
# Should show: KonaAnalyzer.Maui, SpellingTest.Maui, GCD.Maui, PFAssistant.MauiApp
```

---

## Next Steps

1. Add `[Obsolete("Legacy Xamarin control. Consider using modern MAUI alternatives.")]` to deprecated components
2. Update wiki with migration recommendations
3. Create unit tests for actively used components before any refactoring
4. Consider creating a `PolyhydraGames.Core.Maui.Modern` package with updated implementations