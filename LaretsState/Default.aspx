<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LaretsState.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Состояние регламентных работ на сервисе Ларец</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="StatePanel" runat="server" Width="800px"  Wrap="False" CssClass="">
            <div style="text-align: center">
                <h1 >Текущее состояние сервиса "Ларец"</h1>
                <p>Здесь Вы можете узнать о предстоящих и текущих регламентных работах на сервисе сбыта мечт "Ларец"</p>

                <asp:Label ID="StateLabel" runat="server" OnDataBinding="Page_Load"></asp:Label>
                <br />
                <asp:Label ID="PlanLabel" runat="server" OnDataBinding="Page_Load"></asp:Label>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
