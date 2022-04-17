using System.Reflection;
using Geekcode.Document.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geekcode.Document.WebApi;

public class DocumentStartup
{
    public List<DocumentClassEntry> OnInit()
    {
        var data = new List<DocumentClassEntry>();
        var types = GetType().Assembly.GetTypes()
            .Where(t=>t.IsClass && t.GetCustomAttributes(typeof(DocumentAttribute), false).Length > 0);
        foreach (var type in types)
        {
            var item = new DocumentClassEntry
            {
                Clazz = type.Name,
                Route = type.Name.Replace("Controller", ""),
                ClazzName = type.Namespace ?? string.Empty,
                Name = type.GetCustomAttribute<DocumentAttribute>()?.GetName() ?? string.Empty,
                Description = type.GetCustomAttribute<DocumentAttribute>()?.GetDescription() ?? string.Empty
            };
            var methodInfos = type.GetMethods();
            foreach (var methodInfo in methodInfos)
            {
                var method = methodInfo.GetCustomAttribute<DocumentAttribute>();
                if (method == null)
                {
                    continue;
                }

                item.Methods.Add(new DocumentMethodEntry()
                {
                    Name = method.GetName(),
                    Route = $"/{item.Route}/{methodInfo.Name}",
                    Method = methodInfo.Name,
                    MethodName = methodInfo.GetName(),
                    Description = method.GetDescription()
                });
            }

            data.Add(item);
        }
        return data;
    }
}