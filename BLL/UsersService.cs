using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
namespace BLL
{
   public class UsersService
    {
        UsersManager um = new UsersManager();
        public int Add(Users user)
        {
            return um.Add(user);
        }

        public DataTable GetData()
        {
            return um.GetData();
        }
        public DataTable GetList()
        {
            return um.GetList();
        }
        public int Delete(int id)
        {
            return um.Delete(id);
        }
        
        public int Alter(Users user)
        {
            return um.Alter(user);
        }



        public Users GetDataById(int id)
        {
            return um.GetDataById(id);
        }
        public int Edit(Users u)
        {
            return um.Edit(u);
        }
    }
}
