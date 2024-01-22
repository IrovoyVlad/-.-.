using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.ViewModel;

namespace WpfApp19Var.Model
{
    class RoleDPO
    {
        public int Id { get; set; }
        public string Permission { get; set; }
        public string NameRole { get; set; }
        public string Discription { get; set; }

        public RoleDPO() { }

        public RoleDPO(int id, string permition, string nameRole, string discription)
        {
            Id = id;
            Permission = permition;
            NameRole = nameRole;
            Discription = discription;
        }

        public RoleDPO CopyFromRole(Role role)
        {
            RoleDPO roleDPO = new RoleDPO();
            PermissionViewModel permissions = new PermissionViewModel();
            string permissionName = string.Empty;
            foreach (var p in permissions.Permissions)
            {
                if (p.Id == role.PermissionId)
                {
                    permissionName = p.PermissionName;
                    break;
                }
            }

            if (permissionName != string.Empty)
            {
                roleDPO.Id = role.Id;
                roleDPO.Permission = permissionName;
                roleDPO.NameRole = role.NameRole;
                roleDPO.Discription = role.Discription;
            }

            return roleDPO;
        }

        public RoleDPO ShallowCopy()
        {
            return (RoleDPO)this.MemberwiseClone();
        }
    }
}
