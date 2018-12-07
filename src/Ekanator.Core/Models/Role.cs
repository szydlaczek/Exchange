using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace Exchange.Core.Models
{
    public class Role : IRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}