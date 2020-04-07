using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace Web
{
    public partial class edit : System.Web.UI.Page
    {
        private UsersService us = new UsersService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //1.WebForm 开发后台代码第一个步骤都是设置页面回发
            if (IsPostBack)
                return;
            Bind();//调用绑定事件
        }

            //2.在WebForm自定义一个绑定方法 用于做查询
        public void Bind()
        {
            //先得到传递过来的id值
            var id = Request.Params["id"];
            //Request.Params["id"] 是.net 通过Request对象获取路径上传递过来的值
            //这个值都是string类型的
            //通过我们得到的值进行查询
            var user = us.GetDataById(int.Parse(id));
            if (user == null)
            {
                Response.Write("<script>alert('服务器忙,请稍后重试');loation.href = 'Register.aspx'</script>");
            }
            else
            {
                this.txtBrithday.Text = user.Id.ToString();
                this.txtName.Text = user.Name.ToString();
                this.txtBirthday.Text = user.Birthday.ToString();
                if (user.Sex.Equals("男"))
                {
                    this.man.Checked = true;
                }
                else
                {
                    this.woman.Checked = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Users us = new Users()
            {
                Id = int.Parse(this.txtBrithday.Text),
                Name  = this.txtName.Text,
                Birthday = this.txtBrithday.Text
               
            };
        }
    }
}