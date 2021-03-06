using Quantumart.QP8.CodeGeneration.Services;
using Quantumart.QP8.EntityFramework.Models;
using System;
using System.Linq.Expressions;

namespace Quantumart.QP8.EntityFramework6.DevData
{
    public interface IQPSchema
    {
        SchemaInfo GetInfo();
        ContentInfo GetInfo<T>() where T : IQPArticle;
        AttributeInfo GetInfo<Tcontent>(Expression<Func<Tcontent, object>> fieldSelector) where Tcontent : IQPArticle;
    }
}
