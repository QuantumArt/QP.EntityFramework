// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace EntityFramework6.AspNetCore.Test.DataContext
{
    public partial class ImageItemForUpdate: IQPArticle
    {
        public ImageItemForUpdate()
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

        public virtual String ImageValueField { get; set; }
		#region Generated Content properties
        // public string ImageValueFieldUrl { get; set; }
        // public string ImageValueFieldUploadPath { get; set; }
		#endregion
	}
}
	
