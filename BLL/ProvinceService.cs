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
   public class ProvinceService
    {
        ProvinceManager pm = new ProvinceManager();
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllProvince()
        {
            return pm.GetAllProvince();
        }
        /// <summary>
        /// 按照ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Province GetProvinceById(int id)
        {
            return pm.GetProvinceById(id);
        }
    }
}
