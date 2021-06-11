using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class RoleService : BaseService
    {
        public List<Role> GetRoles()
        {
            return Gets<Role>("Role");
        }
        public int Add(Role obj)
        {
            return Post<Role>("role", obj);
        }
        public int Delete(int id)
        {
            return Delete($"role/{id}");
        }
        public Role GetRoleById(int id)
        {
            return Get<Role>($"role/{id}");
        }
        public int Edit(Role obj)
        {
            return Put<Role>($"role/{obj.Id}", obj);
        }
    }
}
