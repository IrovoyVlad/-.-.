using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.ViewModel;

namespace WpfApp19Var.Model
{
    internal class Role
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public string NameRole { get; set; }
        public string Discription { get; set; }

        public Role() { }

        public Role(int id, int permitionId, string nameRole, string discription)
        {
            Id = id;
            PermissionId = permitionId;
            NameRole = nameRole;
            Discription = discription;
        }

        public Role CopyFromRoleDPO(RoleDPO role)
        {
            PermissionViewModel permission = new PermissionViewModel();
            int permissionId = 0;
            foreach (var r in permission.Permissions)
            {
                if (r.PermissionName == role.Permission)
                {
                    permissionId = r.Id;
                    break;
                }
            }

            if (permissionId != 0)
            {
                this.Id = role.Id;
                this.PermissionId = permissionId;
                this.NameRole = role.NameRole;
                this.Discription = role.Discription;
            }
            return this;
        }
    }
}
