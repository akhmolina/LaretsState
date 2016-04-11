<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="LaretsState.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Войти в систему</title>
</head>
<body>
       <form id="form1" runat="server">
        <div style="text-align: center">
            <h1>Пожалуйста, войдите в систему</h1>

            <%--<asp:ValidationSummary ID="ValidationSummary" runat="server" />--%>
            <asp:Panel ID="MainPanel" runat="server" Width="500px"  Wrap="False" CssClass="">
                <br />
                <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Admin.aspx"
                    FailureAction="RedirectToLoginPage"
                    ></asp:Login>

                <%--<table style="width:100%" border="0">
                    <tr>
                        <td style="height: 43px; width:30%; vertical-align:top">Логин:</td>
                        <td style="height: 43px; width: 70%">
                            
                            <asp:TextBox ID="UsernameText" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server"
                                Text ="*" ErrorMessage="Введите логин" 
                                ControlToValidate="UsernameText" ForeColor="Red" />
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
                        <td style="height: 26px; width: 30%; vertical-align: top">Пароль:</td>
                        <td style="height: 26px; width: 70%">
                            <asp:TextBox ID="PasswordText" runat="server" Width="80%" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="PasswordRequiredValidator"
                                runat="server" Text ="*"
                                ErrorMessage="Введите пароль"
                                ControlToValidate="PasswordText" ForeColor="Red" />
                            <br />
                            <asp:RegularExpressionValidator ID="PasswordValidator"
                                runat="server" ControlToValidate="PasswordText"
                                ErrorMessage="Некорректный пароль"
                                ValidationExpression='[\w| !"§$%&amp;/()=\-?\*]*'
                                ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="LoginAction" runat="server" OnClick="LoginAction_Click" Text="Войти" />
                <br />
                <asp:Label ID="LoginStatus" runat="server" EnableViewState="false" Text="" Display="Static" />--%>
            </asp:Panel>
        </div>
    </form>

</body>
</html>
