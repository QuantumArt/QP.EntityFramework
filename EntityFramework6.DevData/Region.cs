// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace Quantumart.QP8.EntityFramework6.DevData
{
    public partial class Region: IQPArticle
    {
        public Region()
        {
		    AllowedRegions = new HashSet<Region>();
		    DeniedRegions = new HashSet<Region>();
		    Children = new HashSet<Region>();
		    BackwardForRegions = new HashSet<Product>();
		    BackwardForAllowedRegions = new HashSet<Region>();
		    BackwardForDeniedRegions = new HashSet<Region>();
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
        public virtual String Alias { get; set; }
        public virtual Int32? OldSiteId { get; set; }
		/// <summary>
		/// 
		/// </summary>			
		public virtual Region Parent { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public virtual Int32? Parent_ID { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Region> AllowedRegions { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Region> DeniedRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for field (id: 1138)/Parent Children
		/// </summary>
		public  ICollection<Region> Children { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1228/Regions
		/// </summary>
		public  ICollection<Product> BackwardForRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1659/AllowedRegions
		/// </summary>
		public  ICollection<Region> BackwardForAllowedRegions { get; set; }
		/// <summary>
		/// Auto-generated backing property for 1660/DeniedRegions
		/// </summary>
		public  ICollection<Region> BackwardForDeniedRegions { get; set; }

	}
}
	
