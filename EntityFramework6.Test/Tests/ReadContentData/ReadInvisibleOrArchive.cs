﻿using System.Linq;
using EntityFramework6.DevData;
using NUnit.Framework;
using EntityFramework6.Test.Infrastructure;

namespace EntityFramework6.Test.Tests.ReadContentData
{
    [TestFixture]
    class ReadInvisibleOrArchive : DataContextFixtureBase
    {
        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_That_Published_Article_isLoaded([Values(ContentAccess.StageNoDefaultFiltration)] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var items = context.PublishedNotPublishedItems.ToArray();
                Assert.That(items, Is.Not.Null.And.Not.Empty);
            }
        }

        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_That_nonPublished_Article_isLoaded([Values(ContentAccess.StageNoDefaultFiltration)] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var status = ValuesHelper.GetNonPublishedStatus(mapping);
                var items = context.PublishedNotPublishedItems.Where(x => x.StatusTypeId == status).ToArray();
                Assert.That(items, Is.Not.Null.And.Not.Empty);
            }
        }

        private static string ALIAS_FOR_SPLITTED_ARTICLES = "SplittedItem";
        private static string TITLE_FOR_SPLITTED_ARTICLES = "SplittedArticle";
        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_That_Splitted_Article_isLoaded_SplittedVersion([Values(ContentAccess.StageNoDefaultFiltration)] ContentAccess access,[MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var item = context.PublishedNotPublishedItems.Where(x => x.Alias.Equals(ALIAS_FOR_SPLITTED_ARTICLES)).FirstOrDefault();
                Assert.That(item.Title, Is.EqualTo(TITLE_FOR_SPLITTED_ARTICLES));
            }
        }

        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_That_Archive_Article_isLoaded([Values(ContentAccess.StageNoDefaultFiltration)] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var item = context.PublishedNotPublishedItems.Where(x => x.Archive).ToArray();
                Assert.That(item, Is.Not.Null.Or.Empty);
            }
        }

        [Test, Combinatorial]
        [Category("ReadContentData")]
        public void Check_That_inVisible_Article_isLoaded([Values(ContentAccess.StageNoDefaultFiltration)] ContentAccess access, [MappingValues] Mapping mapping)
        {
            using (var context = GetDataContext(access, mapping))
            {
                var item = context.PublishedNotPublishedItems.Where(x => !x.Visible).ToArray();
                Assert.That(item, Is.Not.Null.Or.Empty);
            }
        }
    }
}
