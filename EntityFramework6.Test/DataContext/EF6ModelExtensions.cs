// Code generated by a template
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using Quantumart.QPublishing.Database;
using Quantumart.QP8.CodeGeneration.Services;
using System.Linq.Expressions;
using System.Collections.Generic;
using Quantumart.QPublishing.Info;
using System.Data.Entity.Core;
using System.Collections;
using System.Globalization;


namespace EntityFramework6.Test.DataContext
{
    public partial class EF6Model: IQPLibraryService, IQPFormService, IQPSchema
    {
        #region Constructors

        public EF6Model(string connectionStringOrName)
            : base(connectionStringOrName)
        {
            MappingResolver = GetDefaultMappingResolver();
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            OnContextCreated();
        }

        public EF6Model(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            MappingResolver = GetDefaultMappingResolver();
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            OnContextCreated();
        }

        public EF6Model(DbCompiledModel model, ModelReader schema) : base(model)
        {
            MappingResolver = new MappingResolver(schema);
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            OnContextCreated();
        }

        public EF6Model(DbConnection connection, DbCompiledModel model, ModelReader schema, bool contextOwnsConnection)
            : base(connection, model, contextOwnsConnection)
        {
            MappingResolver = new MappingResolver(schema);
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;
            OnContextCreated();
        }

        private IMappingResolver GetDefaultMappingResolver()
        {
            var schema = new StaticSchemaProvider();
            return new MappingResolver(schema.GetSchema());
        }

        protected ObjectContext CurrentObjectContext
        {
			get 
			{
				return ((IObjectContextAdapter)this).ObjectContext;
			}
        }

        #endregion

        #region Private members
        private const string uploadPlaceholder = "<%=upload_url%>";
        private const string sitePlaceholder = "<%=site_url%>";
        private static string _defaultSiteName = "original_site";
        private static string _defaultConnectionString;
        private static string _defaultConnectionStringName = "EF6Model";
        private bool _shouldRemoveSchema = false;
        private string _siteName;
        private DBConnector _cnn;
        #endregion

        #region Properties
        public static bool RemoveUploadUrlSchema = false;

        protected IMappingResolver MappingResolver { get; private set; }

        public bool ShouldRemoveSchema { get { return _shouldRemoveSchema; } set { _shouldRemoveSchema = value; } }
        public Int32 SiteId { get; private set; }
		public string SiteUrl { get { return StageSiteUrl; } }
		public string UploadUrl { get { return LongUploadUrl; } }
		public string LiveSiteUrl { get; private set; }
		public string LiveSiteUrlRel { get; private set; }
		public string StageSiteUrl { get; private set; }
		public string StageSiteUrlRel { get; private set; }
		public string LongUploadUrl { get; private set; }
		public string ShortUploadUrl { get; private set; }
		public Int32 PublishedId { get; private set; }
		public string ConnectionString { get; private set; }
		public static string DefaultSiteName 
		{ 
			get { return _defaultSiteName; }
			set { _defaultSiteName = value; }
		}
		public DBConnector Cnn
		{
			get 
			{
				if (_cnn == null) 
				{
					_cnn = new DBConnector(Database.Connection);
					_cnn.UpdateManyToMany = false;
				}
				return _cnn;
			}
		}
		public string SiteName 
		{ 
			get { return _siteName; } 
			set
			{
				if (!String.Equals(_siteName, value, StringComparison.InvariantCultureIgnoreCase))
				{
					_siteName = value;
					SiteId = Cnn.GetSiteId(_siteName);
					LoadSiteSpecificInfo();
				}
			}
		}
		public static string DefaultConnectionString 
		{ 
			get
			{
				if (_defaultConnectionString == null)
				{
					var obj = System.Configuration.ConfigurationManager.ConnectionStrings[_defaultConnectionStringName];
					if (obj == null)
						throw new ApplicationException(string.Format("Connection string '{0}' is not specified", _defaultConnectionStringName));
					_defaultConnectionString = obj.ConnectionString;
				}
				return _defaultConnectionString;
			}
			set
			{
				_defaultConnectionString = value;
			}
		}
		#endregion

		#region Factory methods
		public static EF6Model Create(SqlConnection connection)
		{
			return Create(connection, DefaultSiteName);
		}

		public static EF6Model Create(IMappingConfigurator configurator, SqlConnection connection, bool contextOwnsConnection)
        {
			var mapping = configurator.GetMappingInfo(connection);
            var ctx = new EF6Model(connection, mapping.DbCompiledModel, mapping.Schema, contextOwnsConnection);
            ctx.SiteName = mapping.Schema.Schema.SiteName;
            ctx.ConnectionString = connection.ConnectionString;
            return ctx;
        }

        public static EF6Model Create(IMappingConfigurator configurator, SqlConnection connection)
        {
            return Create(configurator, connection, true);
        }

        public static EF6Model Create(IMappingConfigurator configurator)
        {
            return Create(configurator, new SqlConnection(DefaultConnectionString), true);
        }

		public static EF6Model Create(string connection, string siteName) 
		{
            EF6Model ctx;
			if(connection.IndexOf("metadata", StringComparison.InvariantCultureIgnoreCase) == -1)
			{
				ctx = new EF6Model(new SqlConnection(connection), true);
				ctx.SiteName = siteName;
				ctx.ConnectionString = connection;
				return ctx;
			}

			ctx = new EF6Model(connection);
			ctx.SiteName = siteName;
			ctx.ConnectionString = connection;
			return ctx;
		}

		public static EF6Model Create(SqlConnection connection, string siteName) 
		{
			EF6Model ctx = new EF6Model(connection, false);
			ctx.SiteName = siteName;
			ctx.ConnectionString = connection.ConnectionString;
			return ctx;
		}

		public static EF6Model Create(string connection) 
		{
			return Create(connection, DefaultSiteName);
		}

		public static EF6Model Create() 
		{
			return Create(DefaultConnectionString);
		}

		public static EF6Model CreateWithStaticMapping(ContentAccess contentAccess)
        {
            return CreateWithStaticMapping(contentAccess, new SqlConnection(DefaultConnectionString), true);
        }

        public static EF6Model CreateWithStaticMapping(ContentAccess contentAccess, SqlConnection connection, bool contextOwnsConnection)
        {
			var schemaProvider = new StaticSchemaProvider();
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);
            return Create(configurator, connection, contextOwnsConnection);
        }

		  public static EF6Model CreateWithDatabaseMapping(ContentAccess contentAccess)
        {
            return CreateWithDatabaseMapping(contentAccess, DefaultSiteName);
        }

        public static EF6Model CreateWithDatabaseMapping(ContentAccess contentAccess, string siteName)
        {
            return CreateWithDatabaseMapping(contentAccess, siteName, new SqlConnection(DefaultConnectionString), true);
        }

        public static EF6Model CreateWithDatabaseMapping(ContentAccess contentAccess, string siteName, SqlConnection connection, bool contextOwnsConnection)
        {
            var schemaProvider = new DatabaseSchemaProvider(siteName, connection);
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);         
            var context = Create(configurator, connection, contextOwnsConnection);
			context.SiteName = siteName;
			return context;
        }

        public static EF6Model CreateWithFileMapping(ContentAccess contentAccess, string path)
        {
            return CreateWithFileMapping(contentAccess, path, new SqlConnection(DefaultConnectionString), true);
        }

        public static EF6Model CreateWithFileMapping(ContentAccess contentAccess, string path, SqlConnection connection, bool contextOwnsConnection)
        {
            var schemaProvider = new FileSchemaProvider(path);
            var configurator = new MappingConfigurator(contentAccess, schemaProvider);
            return Create(configurator, connection, contextOwnsConnection);
        }
		#endregion

		#region Partial methods
		partial void OnObjectMaterialized(object entity);
		#endregion

		#region Helpers
		public string ReplacePlaceholders(string input)
		{
			string result = input;
			if (result != null && MappingResolver.GetSchema().ReplaceUrls)
			{
				result = result.Replace(uploadPlaceholder, UploadUrl);
				result = result.Replace(sitePlaceholder, SiteUrl);
			}
			return result;
		}

		public string GetUrl(string input, string className, string propertyName)
		{
            return String.Format(@"{0}/{1}", Cnn.GetUrlForFileAttribute(Cnn.GetAttributeIdByNetNames(SiteId, className, propertyName), true, ShouldRemoveSchema), input);
		}


		public string GetUploadPath(string input, string className, string propertyName)
		{
			return Cnn.GetDirectoryForFileAttribute(Cnn.GetAttributeIdByNetNames(SiteId, className, propertyName));
		}
		
		public void LoadSiteSpecificInfo()
        {
            if (RemoveUploadUrlSchema && !_shouldRemoveSchema)
            {
                _shouldRemoveSchema = RemoveUploadUrlSchema;
            }

            LiveSiteUrl = Cnn.GetSiteUrl(SiteId, true);
            LiveSiteUrlRel = Cnn.GetSiteUrlRel(SiteId, true);
            StageSiteUrl = Cnn.GetSiteUrl(SiteId, false);
            StageSiteUrlRel = Cnn.GetSiteUrlRel(SiteId, false);
            LongUploadUrl = Cnn.GetImagesUploadUrl(SiteId, false, _shouldRemoveSchema);
            ShortUploadUrl = Cnn.GetImagesUploadUrl(SiteId, true, _shouldRemoveSchema);
            PublishedId = Cnn.GetMaximumWeightStatusTypeId(SiteId);
        }
        #endregion

        partial void OnContextCreated()
        {
            this.CurrentObjectContext.ObjectMaterialized += OnObjectMaterialized;
        }

        void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            if (e.Entity == null)
                return;

            var entity = e.Entity;
            OnObjectMaterialized(entity);
			if(e.Entity is IQPArticle)
			{
				((IQPArticle)e.Entity).OnMaterialized(this);
			}
        }

        #region Save changes
        public override int SaveChanges()
        {
            return OnSaveChanges2();
        }

        private int OnSaveChanges2()
        {
            ChangeTracker.DetectChanges();

            var manager = CurrentObjectContext.ObjectStateManager;
            var modified = manager.GetObjectStateEntries(EntityState.Modified);
            var added = manager.GetObjectStateEntries(EntityState.Added);
            var deleted = manager.GetObjectStateEntries(EntityState.Deleted);

            if (Database.Connection.State == System.Data.ConnectionState.Closed)
            {
                Database.Connection.Open();
            }

            using (var transaction = Database.Connection.BeginTransaction())
            {
                Cnn.ExternalTransaction = transaction;

                UpdateObjectStateEntries(modified, (content, item) => item.GetModifiedProperties().ToArray(), true);
                UpdateObjectStateEntries(added, (content, item) => GetProperties(content), false);

                foreach (var deletedItem in deleted)
                {
                    var article = (IQPArticle)deletedItem.Entity;
                    Cnn.DeleteContentItem(article.Id);
                }

                transaction.Commit();
                Cnn.ExternalTransaction = null;
            }

            Database.Connection.Close();

            return 0;
        }

      private void UpdateObjectStateEntries(IEnumerable<ObjectStateEntry> entries, Func<ContentInfo, ObjectStateEntry, string[]> getProperties, bool passNullValues)
        {
            foreach (var group in entries.Where(e => !e.IsRelationship).GroupBy(m => m.Entity.GetType().Name))
            {
                var contentName = group.Key;
                var content = MappingResolver.GetContent(contentName);
                if (!content.IsVirtual)
                {
                  var items = group
                      .Where(item => item.Entity is IQPArticle)
                      .Select(item => {

                          var article = (IQPArticle)item.Entity;
                          var properties = getProperties(content, item);
                          var fieldValues = GetFieldValues(contentName, article, properties, passNullValues);

                          return new
                          {
                              article,
                              fieldValues
                          };
                      })
                      .ToArray();

                  Cnn.MassUpdate(content.Id, items.Select(item => item.fieldValues), 1);

                  foreach (var item in items)
                  {
                      SyncArticle(item.article, item.fieldValues);
                  }
                }
            }

            var relations = (from e in entries
                    where e.IsRelationship
                    let entityKey = (EntityKey)e.CurrentValues[0]
                    let relatedEntityKey = (EntityKey)e.CurrentValues[1]
                    let entry = e.ObjectStateManager.GetObjectStateEntry(entityKey)
                    let relatedEntry = e.ObjectStateManager.GetObjectStateEntry(relatedEntityKey)
                    let id = ((IQPArticle)entry.Entity).Id
                    let relatedId = ((IQPArticle)relatedEntry.Entity).Id
                    let attribute = MappingResolver.GetAttribute(e.EntitySet.Name)
                    let item = new
                    {
                        Id = id,
                        RelatedId = relatedId,
                        ContentId = attribute.ContentId,
                        Field = attribute.MappedName
                    }
                    group item by item.ContentId into g
                    select new { ContentId = g.Key, Items = g.ToArray() }
                    )
                    .ToArray();

            foreach (var relation in relations)
            {
                var values = relation.Items
                    .GroupBy(r => r.Id)
                    .Select(g =>
                    {
                        var d = g.GroupBy(x => x.Field).ToDictionary(x => x.Key, x => string.Join(",", x.Select(y => y.RelatedId)));
                        d[SystemColumnNames.Id] = g.Key.ToString();
                        return d;
                    })
                    .ToArray();
                
                Cnn.MassUpdate(relation.ContentId, values, 1);
            }
        }

        private void SyncArticle(IQPArticle article, Dictionary<string, string> fieldValues)
        {
            article.Id = int.Parse(fieldValues[SystemColumnNames.Id], CultureInfo.InvariantCulture);
            article.Modified = DateTime.Parse(fieldValues[SystemColumnNames.Modified], CultureInfo.InvariantCulture);
            article.Created = DateTime.Parse(fieldValues[SystemColumnNames.Created], CultureInfo.InvariantCulture);
        }

        private string[] GetProperties(ContentInfo content)
        {
            return content.Attributes
                .Where(c => !c.IsM2O)
                .Select(c => c.MappedName)
                .ToArray();
        }

        private Dictionary<string, string> GetFieldValues(string contentName, IQPArticle article, string[] fields, bool passNullValues)
        {
             var fieldValues = article.GetType()
                .GetProperties()
                .Where(f => fields.Contains(f.Name))
                .Select(f => new {
                    field = MappingResolver.GetAttribute(contentName, f.Name.Replace("_ID", "")).Name,
                    value = GetValue(f.GetValue(article))
                })
                .Where(f => passNullValues || f.value != null)
                .Distinct()
                .ToDictionary(
                    f => f.field,
                    f => f.value
                );
           
            fieldValues[SystemColumnNames.Id] = article.Id.ToString(CultureInfo.InvariantCulture);
            fieldValues[SystemColumnNames.Created] = article.Created.ToString(CultureInfo.InvariantCulture);
            fieldValues[SystemColumnNames.Modified] = article.Modified.ToString(CultureInfo.InvariantCulture);

            if (article.StatusTypeId != 0)
            {
                fieldValues[SystemColumnNames.StatusTypeId] = article.StatusTypeId.ToString();
            }

            return fieldValues;
        }

        private string GetValue(object o)
        {
            if (o == null)
            {
                return null;
            }
			else if (o is bool b)
            {
                return b ? "1" : "0";
            }
            else if (o is IQPArticle)
            {
                return ((IQPArticle)o).Id.ToString();
            }
            else if (o is string)
            {
                return (string)o;
            }
            else if (o is IEnumerable)
            {
                var ids = ((IEnumerable)o).OfType<IQPArticle>().Select(a => a.Id).ToArray();
                return string.Join(",", ids);
            }
            else
            {
                return o.ToString();
            }
        }


        int OnSaveChanges()
        {
            base.ChangeTracker.DetectChanges();

            var objectCount = 0;
            var ctx = CurrentObjectContext;
            var manager = ctx.ObjectStateManager;

            var added = manager.GetObjectStateEntries(EntityState.Added);
            var modified = manager.GetObjectStateEntries(EntityState.Modified);
            var deleted = manager.GetObjectStateEntries(EntityState.Deleted);

            foreach (var addedItem in added)
            {
                objectCount++;
                if (!addedItem.IsRelationship)
                {
                    var entity = addedItem.Entity as IQPArticle;
                    if(entity != null)
                    {
                        ProcessCreating(addedItem.EntitySet.ElementType.Name, entity, addedItem);
                    }
                }
                else
                {
                }
            }

            foreach (var modifiedItem in modified)
            {
                if (!modifiedItem.IsRelationship)
                {
                    objectCount++;
                    var entity = modifiedItem.Entity as IQPArticle;
                    if (entity != null)
                    {
                        ProcessUpdating(modifiedItem.EntitySet.ElementType.Name, entity, modifiedItem);
                    }
                }
                else
                {
                }
            }

            return 0;
        }


        private void ProcessCreating(string contentName, IQPArticle instance, ObjectStateEntry entry)
        {
            throw new NotImplementedException();
            var properties = entry.GetModifiedProperties().ToList();
            var values = instance.Pack(this);
            DateTime created = DateTime.Now;
            // instance.LoadStatusType();
            // todo: load first status
            const string lowestStatus = "None";
            if (!properties.Contains("Visible"))
                instance.Visible = true;
            if (!properties.Contains("Archive"))
                instance.Archive = false;

            // instance.Id = Cnn.AddFormToContent(SiteId, Cnn.GetContentIdByNetName(SiteId, contentName), lowestStatus, ref values, 0, true, 0, instance.Visible, instance.Archive, true, ref created);
            instance.Created = created;
            instance.Modified = created;
        }

        private void ProcessUpdating(string contentName, IQPArticle instance, ObjectStateEntry entry)
        {
		    throw new NotImplementedException();
		    var properties = entry.GetModifiedProperties().ToList();
			var values = instance.Pack(this);
			DateTime modified = DateTime.Now;
			throw new NotImplementedException("CUD operations are not implemented yet.");
			// Cnn.AddFormToContent(SiteId, Cnn.GetContentIdByNetName(SiteId, contentName), instance.StatusType.StatusTypeName, ref values, (int)instance.Id, true, 0, instance.Visible, instance.Archive, true, ref modified);
			// instance.Modified = modified;
        }
        #endregion
        string IQPFormService.GetFormNameByNetNames(string netContentName, string netFieldName)
        {
            return Cnn.GetFormNameByNetNames(this.SiteId, netContentName, netFieldName);
        }

        #region IQPSchema implementation
        public SchemaInfo GetInfo()
        {
            return MappingResolver.GetSchema();
        }

        public ContentInfo GetInfo<T>()
			where T : IQPArticle
        {
            return MappingResolver.GetContent(typeof(T).Name);
        }

        public AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector)
            where Tcontent : IQPArticle
        {
            var contentName = typeof(Tcontent).Name;
            var expression = (MemberExpression)fieldSelector.Body;
            var attributeName = expression.Member.Name;
            return MappingResolver.GetAttribute(contentName, attributeName);
        }
        #endregion
    }
}
