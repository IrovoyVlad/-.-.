using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp19Var.Model;

namespace WpfApp19Var.Helper
{
    class FindUser
    {
        int id;
        public FindUser(int id)
        {
            this.id = id;
        }
        public bool UserPredicate(User u)
        {
            return u.Id == id;
        }
    }
}
