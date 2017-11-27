using EntityFramework6.Test.DataContext;
using EntityFramework6.Test.Infrastructure;
using NUnit.Framework;

namespace EntityFramework6.Test.Tests.UpdateContentData
{
    [TestFixture]
    class UpdateBooleanFieldFixture : DataContextUpdateFixtureBase
    {
        [Test, Combinatorial]
        [Category("UpdateContentData")]
        public void Check_That_Boolean_Field_isUpdated([ContentAccessValues] ContentAccess access, [MappingValues] Mapping mapping)
        {
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.Boolean = null, a => a.Boolean);
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.Boolean = true, a => a.Boolean);
            UpdateProperty<AfiellFieldsItem>(access, mapping, a => a.Boolean = false, a => a.Boolean);            
        }
    }
}
