using Quantumart.QP8.CodeGeneration.Services;

namespace Quantumart.QP8.EntityFramework6.Data
{
    public class FileSchemaProvider : ISchemaProvider
    {
        private readonly string _path;

        public FileSchemaProvider(string path)
        {
            _path = path;
        }

        #region ISchemaProvider implementation
        public ModelReader GetSchema()
        {
            return new ModelReader(_path, _ => { });
        }

        public object GetCacheKey()
        {
            return _path;
        }
        #endregion
    }
}
