// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace EntityFramework6.DevData
{
    public partial class OtMRelatedItemWithMapping: IQPArticle
    {
        public OtMRelatedItemWithMapping()
        {
		    BackOtMReferenceMapping = new HashSet<OtMItemForMapping>();
        }

        public virtual Int32 Id { get; set; }
        public virtual Int32 StatusTypeId { get; set; }
        public virtual bool Visible { get; set; }
        public virtual bool Archive { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual Int32 LastModifiedBy { get; set; }
        public virtual StatusType StatusType { get; set; }

		/// <summary>
		/// Auto-generated backing property for field (id: 40111)/OtMReferenceMapping BackOtMReferenceMapping
		/// </summary>
		public  ICollection<OtMItemForMapping> BackOtMReferenceMapping { get; set; }

	}
}

