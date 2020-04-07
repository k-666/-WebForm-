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
   public class AreaManager
    {
        /// <summary>
        /// 全查询
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllArea()
        {
            string sql = "select * from Area";
            return SqlHelper.Query(sql, null);
        }
        /// <summary>
        /// 按照ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Area GetAreaById(int id)
        {
            string sql = "select * from Area where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Id",SqlDbType.Int){Value = id}
            };
            var dt = SqlHelper.Query(sql, param);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            return new Area()
            {
                Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                Title = dt.Rows[0]["Title"].ToString(),
                Cid = int.Parse(dt.Rows[0]["Cid"].ToString())
            };
        }
        public DataTable GetAreaBiCid(int cid)
        {
            string sql = "select * from Area where Cid = @Cid";

            SqlParameter[] param =
            {
                new SqlParameter("@Cid",SqlDbType.Int){Value = cid}
            };
            return SqlHelper.Query(sql, param);
        }
    }
}
