using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class AreaService
    {
        AreaManager am = new AreaManager();
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllArea()
        {
            return am.GetAllArea();
        }
        /// <summary>
        /// 按照ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Area GetAreaById(int id)
        {
            return am.GetAreaById(id);
        }
        /// <summary>
        /// 按照城市的外键ID查询
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetAreaBiCid(int cid)
        {
            return am.GetAreaBiCid(cid);
        }
    }
}
