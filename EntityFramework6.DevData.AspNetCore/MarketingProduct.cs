// Code generated by a template
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace EntityFramework6.DevData.AspNetCore
{
    public partial class MarketingProduct: IQPArticle
    {
        public MarketingProduct()
        {
		    Products = new HashSet<Product>();
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
        public virtual Int32? ProductType { get; set; }
        public virtual String Benefit { get; set; }
        public virtual String ShortBenefit { get; set; }
        public virtual String Legal { get; set; }
        public virtual String Description { get; set; }
        public virtual String ShortDescription { get; set; }
        public virtual String Purpose { get; set; }
        public virtual Int32? Family_ID { get; set; }
        public virtual String TitleForFamily { get; set; }
        public virtual String CommentForFamily { get; set; }
        public virtual Int32? MarketingSign_ID { get; set; }
        public virtual Int32? OldSiteId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public  ICollection<Product> Products { get; set; }

	}
}
	
