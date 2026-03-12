# Converters

Value converters for MAUI bindings.

## Available Converters

### Typed Converter<T,T2>
Foundation class for other converters. Provides type-safe conversion.

### Boolean Converters
Standard boolean value converters.

### HexStringToColor
Converts between hex color strings and MAUI Color objects.

### ImageToVisibilityConverter
Converts image URLs to visibility (true if image exists, false if placeholder).

### InverseBooleanConverter
Inverts a boolean value. Useful for visibility bindings.

### StringToVisibilityConverter
Converts strings to visibility (true if not null/empty, false otherwise).

## Status (Updated 2026-03-12)

All converters are currently **ACTIVE** and recommended for use. These are utility classes that are commonly needed in MAUI applications.

If you need additional converters, consider using the CommunityToolkit.Maui Converters package which provides many pre-built converters.