using Quantumart.QP8.CodeGeneration.Services;

namespace EntityFramework6.DevData
{
    public interface ISchemaProvider
    {
        ModelReader GetSchema();
        object GetCacheKey();
    }
}
