// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace EntityFramework6.DevData
{
    public partial class OtMItemForUpdate: IQPArticle
    {
        public OtMItemForUpdate()
        {
        }

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }

        public virtual String Title { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual OtMDictionaryForUpdate Reference { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? Reference_ID { get; set; }

	}
}

