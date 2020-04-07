using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public static class SqlHelper
    {
        private static readonly string constr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        /// <summary>
        /// 增删改方法
        /// </summary>
        /// <param name="sql">要执行的语句</param>
        /// <param name="param">传递的参数</param>
        /// <returns>受影响行数</returns>
        public static int ExcueteNonQuery(string sql,SqlParameter[] param)
        {
            using (SqlConnection conn = new SqlConnection(constr)) 
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn)) 
                {
                    if (param != null) 
                        cmd.Parameters.AddRange(param);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns>系统虚表</returns>
        public static DataTable Query(string sql,SqlParameter[] param) 
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql,constr))
            {
                if (param != null)
                    sda.SelectCommand.Parameters.AddRange(param);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }

        
    }
}
