<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="LaretsState.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Войти в систему</title>
    <style>
        .center {
            margin: 0 auto;
            margin-top:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Panel ID="MainPanel" runat="server" Width="500px"  CssClass="center" Font-Names="Segoe UI"
            BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
            <div style="text-align:center">
                <b>Пожалуйста, войдите в систему</b>
                <br />
                <br />
                <table style="width:100%" border="0">
                    <tr>
                        <td style="height: 43px; width:30%; vertical-align:top; text-align:left">Имя пользователя:</td>
                        <td style="height: 43px; width:70%">
                            <asp:TextBox ID="UsernameText" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server"
                                ErrorMessage="*" ControlToValidate="UsernameText" ForeColor="Red" />
                            <br />
                            <asp:RegularExpressionValidator
                                ID="UsernameValidator" runat="server"
                                ControlToValidate="UsernameText"
                                ErrorMessage="Некорректное имя пользователя"
                                ValidationExpression="[\w| ]*"
                                ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 30%; vertical-align: top;text-align:left">Пароль:</td>
                        <td style="height: 26px; width: 70%">
                            <asp:TextBox ID="PasswordText" runat="server" Width="80%" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="PwdRequiredValidator"
                                runat="server" ErrorMessage="*"
                                ControlToValidate="PasswordText" ForeColor="Red" />
                            <br />
                            <asp:RegularExpressionValidator ID="PwdValidator"
                                runat="server" ControlToValidate="PasswordText"
                                ErrorMessage="Некорректный пароль"
                                ValidationExpression='[\w| !"§$%&amp;/()=\-?\*]*'
                                ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="LoginAction" runat="server" OnClick="LoginAction_Click" Text="Войти" /><br />
                <asp:Label ID="LegendStatus" runat="server" EnableViewState="false" Text="" />
                <br/>
            </div>
        </asp:Panel>

    </form>
</body>
</html>

