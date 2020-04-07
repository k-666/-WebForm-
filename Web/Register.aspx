<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="BLL" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        table{ width:900px;}
        table tr td{
            text-align:center;
        }
    </style>
    <link href="Content/bootstrap.css" rel="stylesheet" />
   
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group" style="width:50%">
           <label for="">请输入真实姓名:</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control-file"></asp:TextBox>
        </div>
        <div class="form-group" style="width:50%">
           <label for="">请输入出生日期:</label>
            <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control-file"></asp:TextBox>
        </div>
        <div class="form-group">
           <label for="">请输入性别:</label>
            <asp:RadioButton ID="RdMan" runat="server" GroupName="Sex" Text="男" Checked="true"/>
            <asp:RadioButton ID="RdWoman" runat="server" GroupName="Sex" Text="女" />
        </div>
        <div class="form-group">
           <label for="">请输入家庭住址:</label>
            <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true" CssClass=""></asp:DropDownList>
             <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass=""></asp:DropDownList>
             <asp:DropDownList ID="ddlArea" runat="server" CssClass=""></asp:DropDownList>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BtnSubmit" runat="server" Text="注册" CssClass="btn btn-success" OnClick="BtnSubmit_Click"/>
             <asp:Button ID="BtnReset" runat="server" Text="重置" CssClass="btn btn-success" OnClick="BtnReset_Click"/>
        </div>
        <div style="text-align:center">
            <!-- 小脚本不能写在后面代码页面里,
                  需要把内容都写在网页页面内    -->
            <%
                //实例化BLL业务逻辑层内容
                BLL.UsersService us = new BLL.UsersService();
                DataTable dt = us.GetData();
            %>
              <!--NavigateUrl="" 是服务器空间超链接的连接路径  a标签的href相似-->
             <asp:HyperLink runat="server" NavigateUrl="add.aspx">超链接</asp:HyperLink>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="序号" ></asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="姓名" ></asp:BoundField>
                    <asp:BoundField DataField="Birthday" HeaderText="生日" ></asp:BoundField>
                    <asp:BoundField DataField="Sex" HeaderText="性别" ></asp:BoundField>
                    <asp:BoundField DataField="Pid" HeaderText="省份" ></asp:BoundField>
                    <asp:BoundField DataField="Cid" HeaderText="城市" ></asp:BoundField>
                    <asp:BoundField DataField="Aid" HeaderText="区" ></asp:BoundField>
                    <asp:BoundField DataField="Addresss" HeaderText="详情地址" ></asp:BoundField>
                    <asp:CommandField HeaderText="删除" ShowDeleteButton="True" />
                    <asp:CommandField HeaderText="修改" ShowEditButton="True" />
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="edit.aspx?id={0}" HeaderText="编辑" Text="编辑" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    
</body>
</html>
