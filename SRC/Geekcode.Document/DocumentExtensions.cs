using System.Reflection;

namespace Geekcode.Document;

public static class DocumentExtensions
{
    public static string GetName(this object value)
    {
        var type = value.GetType();
        var field = type.GetField(value.ToString() ?? string.Empty);
        if (field?.IsDefined(typeof(DocumentAttribute), true) ?? false)
        {
            var attr = field.GetCustomAttribute<DocumentAttribute>();
            return attr?.GetName() ?? string.Empty;
        }

        return value.ToString() ?? string.Empty;
    }
    
    public static string GetDescription(this object value)
    {
        var type = value.GetType();
        var field = type.GetField(value.ToString() ?? string.Empty);
        if (field?.IsDefined(typeof(DocumentAttribute), true) ?? false)
        {
            var attr = field.GetCustomAttribute<DocumentAttribute>();
            return attr?.GetDescription() ?? string.Empty;
        }

        return value.ToString() ?? string.Empty;
    }
}