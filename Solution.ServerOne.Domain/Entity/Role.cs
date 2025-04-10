using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ServerOne.Domain.Entity
{
    public class Role
    {
        public int IdRole {  get; set; }
        public string NameRole {  get; set; } = string.Empty;
        public string Description{  get; set; } = string.Empty;
        public ICollection<User> Users { get; set; }

        public static Role Create(string namerole, string description)
        {
            if(namerole == null) throw new ArgumentNullException(nameof(namerole));
            if(description == null) throw new ArgumentNullException("description");

            return new Role()
            {
                NameRole = namerole,
                Description = description,
                Users = null

            };
        }
    }
}
