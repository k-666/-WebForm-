using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        private ProvinceService ps = new ProvinceService();
        private CityService cs = new CityService();
        private AreaService ase = new AreaService();
        private UsersService us = new UsersService();
        /// <summary>
        /// 页面加载方法;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)//页面回发事件:用于判断是否更新当前页面里面的内容;
                return;   //如果不写,页面的值不会更新;默认为true,是不更新
            #region 省份下拉列表绑定
            var ps_list = ps.GetAllProvince();
            this.ddlProvince.DataSource = ps_list;
            this.ddlProvince.DataValueField = "Id";
            this.ddlProvince.DataTextField = "Title";
            this.ddlProvince.DataBind();
            #endregion
            //只显示对应的城市 不显示无效的;
            //三级联动:指的是三个下拉列表根据相互的值 互相改变;
            #region 市下拉列表绑定
            int pid = int.Parse(ps_list.Rows[0]["Id"].ToString());
            var cs_list = cs.GetCityBiPid(pid);
            this.ddlCity.DataSource = cs.GetCityBiPid(pid);
            this.ddlCity.DataValueField = "Id";
            this.ddlCity.DataTextField = "Title";
            this.ddlCity.DataBind();
            #endregion

            #region 区下拉列表绑定
            int cid = int.Parse(cs_list.Rows[0]["Id"].ToString());
            this.ddlArea.DataSource = ase.GetAreaBiCid(cid);
            this.ddlArea.DataValueField = "Id";
            this.ddlArea.DataTextField = "Title";
            this.ddlArea.DataBind();
            #endregion

            Bind();//调用数据绑定方法
            

        }
        /// <summary>
        /// 省份下拉列表索引改变事件;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //(1)先获取当前省份下拉列表选中的值
            int pid = int.Parse(this.ddlProvince.SelectedValue);
            //(2)得到新的pid之后,重新进行绑定
            this.ddlCity.DataSource = cs.GetCityBiPid(pid);
            this.ddlCity.DataValueField = "Id";
            this.ddlCity.DataTextField = "Title";
            this.ddlCity.DataBind();

            //获取市下拉列表的值
            int cid = int.Parse(this.ddlCity.SelectedValue);
            //进行重新绑定
            this.ddlArea.DataSource = ase.GetAreaBiCid(cid);
            this.ddlArea.DataValueField = "Id";
            this.ddlArea.DataTextField = "Title";
            this.ddlArea.DataBind();
        }
        /// <summary>
        /// 市下拉列表索引改变事件;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取市下拉列表的值
            int cid = int.Parse(this.ddlCity.SelectedValue);
            this.ddlArea.DataSource = ase.GetAreaBiCid(cid);
            this.ddlArea.DataValueField = "Id";
            this.ddlArea.DataTextField = "Title";
            this.ddlArea.DataBind();
        }
        /// <summary>
        /// 注册按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            //新增的时候要求传递内容为对象(user)对象,需要创建对应的对象出来
            Users user = new Users()
            {
                //trim() 去除空格
                Name = this.txtName.Text.Trim(),
                Birthday = this.txtBirthday.Text.Trim(),
                Sex = this.RdMan.Checked ? "男" : "女", //三元表达式 ? 代表真的  : 代表假的
                Pid = int.Parse(this.ddlProvince.SelectedValue),
                Cid = int.Parse(this.ddlCity.SelectedValue),
                Aid = int.Parse(this.ddlArea.SelectedValue),
                Addresss = this.txtAddress.Text
            };
            int rs = us.Add(user);
            if (rs > 0)
            {
                Response.Write("<script>alert('注册成功!')</script>");
            }
        }
        /// <summary>
        /// 重置按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReset_Click(object sender, EventArgs e)
        {
            this.txtName.Text = this.txtBirthday.Text = this.txtAddress.Text = "";
            this.RdMan.Checked = true;
            this.ddlProvince.SelectedIndex = 0;
        }
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;// e是删除事件Can数  
            var value = this.GridView1.DataKeys[index].Value.ToString();//获取选中之后的行里面对应的值
            int num = us.Delete(int.Parse(value));
            if (num > 0)
            {
                Response.Write("<script>alert('删除成功');</script>");
                //删除成功之后 需要对数据更新
                Bind();
            }
            else
            {
                Response.Write("<script>alert('删除失败');</script>");
            }
        }
        public void Bind()
        {
            //通过索引找到的值 里面存放的内容是哪个列里面的值
            this.GridView1.DataKeyNames = new string[] { "Id" };

            DataView dv = us.GetData().DefaultView;
            this.GridView1.DataSource = us.GetData();//存入数据源
            this.GridView1.DataBind();//绑定数据源(WebForm有的 存入是存入,绑定是绑定)
                                      //WinForm在存入的时候就自动绑定了
        }

        //添加编辑事件
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //设置编辑时的行 等于触发事件的这个行
            this.GridView1.EditIndex = e.NewEditIndex;
            //重新绑定 
            Bind();
        }
        //编辑时的更新按钮
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //当前更新的行数
            int index = e.RowIndex;
            //获取格子里面，第index行，第0号单元格里面第0个控件,获取值
            string id = ((TextBox)this.GridView1.Rows[index].Cells[0].Controls[0]).Text.ToString();
            string name = ((TextBox)this.GridView1.Rows[index].Cells[1].Controls[0]).Text.ToString();
            string birthday = ((TextBox)this.GridView1.Rows[index].Cells[2].Controls[0]).Text.ToString();
            string sex = ((TextBox)this.GridView1.Rows[index].Cells[3].Controls[0]).Text.ToString();
            string addresss = ((TextBox)this.GridView1.Rows[index].Cells[4].Controls[0]).Text.ToString();
            //这里的id是绑定上去的主键
            int Id = Convert.ToInt32(this.GridView1.DataKeys[index].Value);
            Users user = new Users();
            user.Name = name;
            user.Birthday = birthday;
            user.Sex = sex;
            user.Addresss = addresss;
            if (us.Alter(user) == 1)
            {
                //更新成功
                Response.Write("<srcipt>alert('修改成功')</srcipt>");
                this.GridView1.EditIndex = -1;//设置编辑为否
                this.Bind();//重新绑定
            }
            else
            {
                //更新失败
                Response.Write("<srcipt>alert('修改失败')</srcipt>");
                this.GridView1.EditIndex = -1;//设置编辑为否
                this.Bind();//重新绑定
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //设置当前选中行索引为-1（也就是没有）
            this.GridView1.EditIndex = -1;
            //重新绑定 
            Bind();
        }

        //
    }
}