using NUnit.Framework;
using System.IO;
using EntityFramework6.DevData;
using Microsoft.Extensions.Configuration;
using Quantumart.QPublishing.FileSystem;

namespace EntityFramework6.Test.Infrastructure
{
    public class DataContextFixtureBase
    {
        private const string DefaultSiteName = "original_site";
        private const string DynamicSiteName = "dynamic_site";
        private const string DefaultMappingResult = @"DataContext\ModelMappingResult.xml";
        private const string DynamicMappingResult = @"DataContext\DynamicMappingResult.xml";

        protected EF6Model GetDataContext(ContentAccess access, Mapping mapping)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            EF6Model.DefaultConnectionString = configuration["ConnectionStrings:EF6Model"];
            EF6Model context;
            switch (mapping)
            {
                case Mapping.StaticMapping:
                    context = EF6Model.CreateWithStaticMapping(access);
                    break;
                case Mapping.DatabaseDefaultMapping:
                    context = EF6Model.CreateWithDatabaseMapping(access, DefaultSiteName);
                    break;
                case Mapping.DatabaseDynamicMapping:
                    context = EF6Model.CreateWithDatabaseMapping(access, DynamicSiteName);
                    break;
                case Mapping.FileDefaultMapping:
                    context = EF6Model.CreateWithFileMapping(access, GetPath(DefaultMappingResult));
                    break;
                case Mapping.FileDynamicMapping:
                    context = EF6Model.CreateWithFileMapping(access, GetPath(DynamicMappingResult));
                    break;
                default:
                    context = EF6Model.Create();
                    break;
            }
            context.Cnn.FileSystem = new FakeFileSystem();
            return context;
        }

        protected string GetPath(string file)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, file);
        }
    }
}
