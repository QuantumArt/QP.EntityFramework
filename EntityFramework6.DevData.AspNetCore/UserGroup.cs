using System.Collections.Generic;

namespace EntityFramework6.DevData.AspNetCore
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
	
