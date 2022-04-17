namespace Geekcode.Document.Models;

public class DocumentClassEntry
{
    public string Name { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
    public string Clazz { get; set; } = string.Empty;
    public string ClazzName { get; set; }= string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<DocumentMethodEntry> Methods { get; set; } = new();
}