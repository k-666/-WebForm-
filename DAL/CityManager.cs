using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace DAL
{
   public class CityManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCity()
        {
            string sql = "select * from City";
            return SqlHelper.Query(sql, null);
        }
        /// <summary>
        /// 按照ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public City GetCityById(int id)
        {
            string sql = "select * from City where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",SqlDbType.Int){Value = id}
            };
            var dt = SqlHelper.Query(sql, param);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            return new City()
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                Title = dt.Rows[0]["Title"].ToString(),
                Pid = int.Parse(dt.Rows[0]["Pid"].ToString())
            };
        }
        /// <summary>
        /// 按照省份ID查询
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetCityBiPid(int pid)
        {
            string sql = "select * from City where Pid = @Pid";

            SqlParameter[] param =
            {
                new SqlParameter("@Pid",SqlDbType.Int){Value = pid}
            };
            return SqlHelper.Query(sql,param);
        }
    }
}
