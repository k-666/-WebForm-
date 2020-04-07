using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;
namespace BLL
{
   public class CityService
    {
        CityManager cm = new CityManager();
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCity()
        {
            return cm.GetAllCity();
        }
        /// <summary>
        /// 按照ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City GetCityById(int id)
        {
            return cm.GetCityById(id);
        }

        /// <summary>
        /// 按照省份的外键ID查询
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetCityBiPid(int pid)
        {
            return cm.GetCityBiPid(pid);
        }
    }
}