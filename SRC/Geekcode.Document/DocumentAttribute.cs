namespace Geekcode.Document;

[AttributeUsage(AttributeTargets.All, Inherited = false)]
public sealed class DocumentAttribute : Attribute
{
    private readonly string _name;
    private readonly string _description;

    public DocumentAttribute(string name, string description = "")
    {
        _name = name;
        _description = description;
    }

    public string GetName() => _name;

    public string GetDescription() => _description;
}