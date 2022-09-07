using Quantumart.QP8.CodeGeneration.Services;
using System;
using System.Linq.Expressions;

namespace EntityFramework6.DevData.AspNetCore
{
    public interface IQPSchema
    {
        SchemaInfo GetInfo();
        ContentInfo GetInfo<T>() where T : IQPArticle;
        AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector) where Tcontent : IQPArticle;
    }
}
