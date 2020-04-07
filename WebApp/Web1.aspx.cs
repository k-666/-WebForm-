using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 登录按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            //(1)获取文本框中的值
            string code = this.code.Text;
            string pwd = this.pwd.Text;
            if (code.Equals("admin") && pwd.Equals("123456")) 
            {
                Response.Write("<script>alert('登陆成功!')</script>");
            }
            else 
            {
                Response.Write("<script>alert('账号或者密码输入错误!')</script>");
            }

        }
    }
}