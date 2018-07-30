using Quantumart.QP8.CodeGeneration.Services;

namespace EntityFramework6.Data.AspNetCore
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}