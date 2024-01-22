using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.Model;

namespace WpfApp19Var.Helper
{
    class FindPermission
    {
        int id;
        public FindPermission(int id)
        {
            this.id = id;
        }
        public bool PermissionPredicate(Permission p)
        {
            return p.Id == id;
        }
    }
}
