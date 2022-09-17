using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
/* place your custom usings here */

namespace EntityFramework6.DevData
{
    public partial class EF6Model : DbContext
    {
        public static ContentAccess DefaultContentAccess = ContentAccess.Live;

        partial void OnContextCreated();

        static EF6Model()
        {
            Database.SetInitializer<EF6Model>(new NullDatabaseInitializer<EF6Model>());
        }

        public EF6Model()
            : base("name=qp_database")
        {
            MappingResolver = GetDefaultMappingResolver();
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;

            OnContextCreated();
        }

        public virtual DbSet<StatusType> StatusTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        public virtual DbSet<AfiellFieldsItem> AfiellFieldsItems { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<StringItem> StringItems { get; set; }
        public virtual DbSet<StringItemForUpdate> StringItemsForUpdate { get; set; }
        public virtual DbSet<StringItemForUnsert> StringItemsForInsert { get; set; }
        public virtual DbSet<ItemForUpdate> ItemsForUpdate { get; set; }
        public virtual DbSet<ItemForInsert> ItemsForInsert { get; set; }
        public virtual DbSet<PublishedNotPublishedItem> PublishedNotPublishedItems { get; set; }
        public virtual DbSet<ReplacingPlaceholdersItem> ReplacingPlaceholdersItems { get; set; }
        public virtual DbSet<FileFieldsItem> FileFieldsItems { get; set; }
        public virtual DbSet<SymmetricRelationArticle> SymmetricRelationArticles { get; set; }
        public virtual DbSet<ToSymmetricRelationAtricle> ToSymmetricRelationAtricles { get; set; }
        public virtual DbSet<MtMItemForUpdate> MtMItemsForUpdate { get; set; }
        public virtual DbSet<MtMDictionaryForUpdate> MtMDictionaryForUpdate { get; set; }
        public virtual DbSet<OtMItemForUpdate> OtMItemsForUpdate { get; set; }
        public virtual DbSet<OtMDictionaryForUpdate> OtMDictionaryForUpdate { get; set; }
        public virtual DbSet<DateItemForUpdate> DateItemsForUpdate { get; set; }
        public virtual DbSet<TimeItemForUpdate> TimeItemsForUpdate { get; set; }
        public virtual DbSet<DateTimeItemForUpdate> DateTimeItemsForUpdate { get; set; }
        public virtual DbSet<FileItemForUpdate> FileItemsForUpdate { get; set; }
        public virtual DbSet<ImageItemForUpdate> ImageItemsForUpdate { get; set; }
        public virtual DbSet<OtMItemForMapping> OtMItemsForMapping { get; set; }
        public virtual DbSet<OtMRelatedItemWithMapping> OtMRelatedItemsWithMapping { get; set; }
        public virtual DbSet<OtMItemToContentWithoutMapping> OtMItemsToContentWithoutMapping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var schemaProvider = new StaticSchemaProvider();
            var mapping = new MappingConfigurator(DefaultContentAccess, schemaProvider);
            mapping.OnModelCreating(modelBuilder);
        }
	}
}
