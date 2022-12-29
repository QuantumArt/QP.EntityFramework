using NUnit.Framework;

namespace EntityFramework6.Test.Infrastructure
{
    public class MappingValuesAttribute : ValuesAttribute
    {
        public MappingValuesAttribute()
            : base(
                Mapping.StaticMapping,
                Mapping.DatabaseDefaultMapping,
                Mapping.FileDefaultMapping,
                Mapping.FileDynamicMapping,
                Mapping.DatabaseDynamicMapping)
        {
        }
    }
}
