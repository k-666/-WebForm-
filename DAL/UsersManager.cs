using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class UsersManager
    {
        /// <summary>
       /// 新增用户
      /// </summary>
     /// <param name="user"></param>
    /// <returns></returns>
        public int Add(Users user)
        {
            string sql = "insert into Users(Name,Birthday,Sex,Pid,Cid,Aid,Addresss) values (@Name,@Birthday,@Sex,@Pid,@Cid,@Aid,@Addresss)";
            SqlParameter[] param =
            {
                new SqlParameter("@Name",SqlDbType.VarChar){Value = user.Name},
                new SqlParameter("@Birthday",SqlDbType.DateTime){Value = user.Birthday},
                new SqlParameter("@Sex",SqlDbType.Char){Value = user.Sex},
                new SqlParameter("@Pid",SqlDbType.Int){Value = user.Pid},
                new SqlParameter("@Cid",SqlDbType.Int){Value = user.Cid},
                new SqlParameter("@Aid",SqlDbType.Int){Value = user.Aid},
                new SqlParameter("@Addresss",SqlDbType.VarChar){Value = user.Addresss},
            };
            return SqlHelper.ExcueteNonQuery(sql, param);
        }

        //全查询用户
        public DataTable GetData()
        {
            string sql = "select * from Users";
            return SqlHelper.Query(sql,param:null);
        }

        public DataTable GetList()
        {
            string sql = "select Id,Name,Birthday,Sex from Users select title from Province select title from City";
            return SqlHelper.Query(sql, param: null);
        }
        //删除
        public int Delete(int id) 
        {
            string sql = "delete from Users where Id = @id";
            SqlParameter[] param =
            {
                new SqlParameter("@id",id)
            };
            return SqlHelper.ExcueteNonQuery(sql, param);
        }
        //修改
        public int Alter(Users user)
        {
            string sql = "UPDATE Users SET Name = @name,Birthday = @brithday,Sex=@sex,Addresss = @addresss WHERE Id = Id";
            SqlParameter[] param =
            {
                new SqlParameter("@name",user.Name),
                new SqlParameter("@brithday",user.Birthday),
                new SqlParameter("@sex",user.Sex),
                new SqlParameter("@pid",user.Pid),
                new SqlParameter("@id",user.Cid),
                new SqlParameter("@aid",user.Aid),
                new SqlParameter("@addresss",user.Addresss)

            };
            return SqlHelper.ExcueteNonQuery(sql,param);
        }

        public Users GetDataById(int id)
        {
            string sql = "select * from users where Id = @ id";
            SqlParameter[] param =
            {
                new SqlParameter("@id",id)
            };
            var dt = SqlHelper.Query(sql,param);
            //判断表中是否有值
            if (dt.Rows.Count > 0 )
            {
                return new Users()
                {
                    Id = int.Parse(dt.Rows[0]["Id"].ToString()),
                    Name = dt.Rows[0]["Name"].ToString(),
                    Birthday = dt.Rows[0]["Birthday"].ToString(),
                    Sex = dt.Rows[0]["Sex"].ToString()
                };
            }
            else
            {
                return null;//没有值的情况;
            }
        }
        public int Edit(Users u)
        {
            string sql = "update Users set Name = @Name,Birthday = @Birthday,Sex = @Sex where Id = @Id";
            SqlParameter[] param =
            {
                new SqlParameter("@Name",u.Name),
                new SqlParameter("@Birthday",u.Birthday),
                new SqlParameter("@Sex",u.Sex),
                new SqlParameter("@Id",u.Id)
            };
            return SqlHelper.ExcueteNonQuery(sql,param);
        }
    }
}
