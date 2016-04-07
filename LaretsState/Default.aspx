<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LaretsState.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Статус сервиса "Ларец"</h1>
        <p>Здесь Вы можете узнать о предстоящих и текущих регламентных работах на сервисе сбыта мечт "Ларец".</p>

        <asp:Label ID="StateLabel1" runat="server" OnDataBinding="Page_Load"></asp:Label>
        <br />
        <asp:Label ID="StateLabel2" runat="server" OnDataBinding="Page_Load"></asp:Label>

    </div>
    </form>
</body>
</html>
