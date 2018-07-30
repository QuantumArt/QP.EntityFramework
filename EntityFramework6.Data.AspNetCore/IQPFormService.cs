namespace EntityFramework6.Data.AspNetCore
{
    public interface IQPFormService
    {
        string GetFormNameByNetNames(string netContentName, string netFieldName);
        string ReplacePlaceholders(string text);
    }
}