using System.Reflection;

namespace PolyhydraGames.Core.Maui.Controls;

public static class FrameExtensions
{
    public static T FindByField<T>(this object frame, string fieldName)
    {
        var t = typeof(T);
        var fi = t.GetRuntimeFields().FirstOrDefault(f => f.Name == fieldName);
        if (fi == null) throw new NullReferenceException($"Field {fieldName} not found.");
        var value = fi.GetValue(frame);

#pragma warning disable CS8600
#pragma warning disable CS8603
        return (T)value;
#pragma warning restore CS8603
#pragma warning restore CS8600
    }
}