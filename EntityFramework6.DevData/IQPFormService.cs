namespace EntityFramework6.DevData
{
    public interface IQPFormService
    {
        string GetFormNameByNetNames(string netContentName, string netFieldName);
        string ReplacePlaceholders(string text);
    }
}
