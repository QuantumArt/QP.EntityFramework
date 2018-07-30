// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace EntityFramework6.DevData.AspNetCore
{
    public partial class ProductParameter: IQPArticle
    {
        public ProductParameter()
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
        public virtual Int32? GroupMapped_ID { get; set; }
        public virtual Int32? BaseParameter_ID { get; set; }
        public virtual Int32? Zone_ID { get; set; }
        public virtual Int32? Direction_ID { get; set; }
        public virtual Int32? SortOrder { get; set; }
        public virtual Double? NumValue { get; set; }
        public virtual String Value { get; set; }
        public virtual Int32? Unit_ID { get; set; }
        public virtual String Legal { get; set; }
        public virtual String ShortTitle { get; set; }
        public virtual String ShortValue { get; set; }
        public virtual Int32? MatrixParameter_ID { get; set; }
        public virtual Int32? OldSiteId { get; set; }
		/// <summary>
		/// 
		/// </summary>			
		public virtual Product Product { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? Product_ID { get; set; }
		#region Generated Content properties
        // public Int32 GroupMapped_IDExact { get { return this.GroupMapped_ID == null ? default(Int32) : this.GroupMapped_ID.Value; } }
        // public Int32 BaseParameter_IDExact { get { return this.BaseParameter_ID == null ? default(Int32) : this.BaseParameter_ID.Value; } }
        // public Int32 Zone_IDExact { get { return this.Zone_ID == null ? default(Int32) : this.Zone_ID.Value; } }
        // public Int32 Direction_IDExact { get { return this.Direction_ID == null ? default(Int32) : this.Direction_ID.Value; } }
        // public Int32 SortOrderExact { get { return this.SortOrder == null ? default(Int32) : this.SortOrder.Value; } }
        // public Double NumValueExact { get { return this.NumValue == null ? default(Double) : this.NumValue.Value; } }
        // public Int32 Unit_IDExact { get { return this.Unit_ID == null ? default(Int32) : this.Unit_ID.Value; } }
        // public Int32 MatrixParameter_IDExact { get { return this.MatrixParameter_ID == null ? default(Int32) : this.MatrixParameter_ID.Value; } }
        // public Int32 OldSiteIdExact { get { return this.OldSiteId == null ? default(Int32) : this.OldSiteId.Value; } }
		#endregion
	}
}
	
