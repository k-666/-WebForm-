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
   public class ProvinceManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllProvince()
        {
            string sql = "select * from Province";
            return SqlHelper.Query(sql,null);
        }
        /// <summary>
        /// 按照ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Province GetProvinceById(int id) 
        {
            string sql = "select * from Province where Id = @Id";
            SqlParameter[] param = 
            {
                new SqlParameter("@Id",SqlDbType.Int){Value = id}
            };
            var dt = SqlHelper.Query(sql,param);
            if (dt.Rows.Count<=0) 
            {
                return null;
            }
            return new Province()
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                Title = dt.Rows[0]["Title"].ToString()
            };
        }
    }
}
