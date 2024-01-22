using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp19Var.Model
{
    internal class Permission
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string Discription { get; set; }
        public DateTime DateCreate { get; set; }

        public Permission() { }

        public Permission(int id, string permitionName, string discription, DateTime dateCreate)
        {
            Id = id;
            PermissionName = permitionName;
            Discription = discription;
            DateCreate = dateCreate;
        }

        public Permission ShallowCopy()
        {
            return (Permission)this.MemberwiseClone();
        }
    }
}
