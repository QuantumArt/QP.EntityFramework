using Quantumart.QP8.CodeGeneration.Services;

namespace EntityFramework6.AspNetCore.Test.DataContext
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}