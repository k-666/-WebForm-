<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Web1.aspx.cs" Inherits="WebApp.Web1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="width:60%">
        <div class="form-group">
            <label for="">请输入账号</label>
            <%--<input type="text" class="form-control"/>--%>
            <asp:TextBox ID="code" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div>
            <label for="">请输入密码</label>
             <asp:TextBox ID="pwd" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BtnSubmit" runat="server" Text="登录" CssClass="btn btn-success" OnClick="BtnSubmit_Click"/>
            <asp:Button ID="BtnReset" runat="server" Text="重置" CssClass="btn btn-danger"/>

        </div>
    </form>
</body>
</html>
