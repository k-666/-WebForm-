<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="Web.edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="">编号:</label>
            <asp:TextBox ID="txtId" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
         <div>
            <label for="">姓名:</label>
            <asp:TextBox ID="txtName"  runat="server"></asp:TextBox>
        </div>
         <div>
            <label for="">生日:</label>
            <asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox>
        </div>
         <div>
            <label for="">性别:</label>
            <asp:RadioButton ID="man"  runat="server" GroupName="Sex" Text="男"></asp:RadioButton>
              <asp:RadioButton ID="woman"  runat="server" GroupName="Sex" Text="女"></asp:RadioButton>
        </div>
        <div>
            <asp:Button  ID="btnSubmit" runat="server" Text="提交"/>
            <asp:Button  ID="btnReset" runat="server" Text="重置"/>
        </div>
    </form>
</body>
</html>
