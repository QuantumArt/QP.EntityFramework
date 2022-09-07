using Quantumart.QP8.CodeGeneration.Services;

namespace EntityFramework6.DevData.AspNetCore
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}
