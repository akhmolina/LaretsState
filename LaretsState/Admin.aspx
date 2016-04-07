<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LaretsState.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Текущее состояние сервиса "Ларец":</h1>

        <asp:Label ID="StateLabel1" runat="server" OnDataBinding="Page_Load"></asp:Label>
        <br />
        <asp:Label ID="StateLabel2" runat="server" OnDataBinding="Page_Load"></asp:Label>
    
    </div>
    
    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Запланировать очередное обслуживание</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Посмотреть все запланированные работы</asp:LinkButton>
    <br />
    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Изменить запланированные работы</asp:LinkButton>
    <br />

    <asp:MultiView ID="MultiView1" runat="server">  
        <asp:View ID="View1" runat="server">
            <h1>Запланировать очередное обслуживание</h1>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor ="Red" />
            Дата и время начала обслуживания:&nbsp; 
            <br />
            <table >
                <tr>
                    <td>
                        <asp:Calendar ID="NextDate" runat="server"
                        ></asp:Calendar>
                        <%-- как быть без validation group? --%>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="NextDate" 
                        ErrorMessage="*" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                    </td>
                
                    <td>
                        <asp:TextBox ID="NextTime" runat="server" Text="0:00"
                            ValidationGroup="PlanValidationGroup" Width="52px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="NextTime" Text="*"
                        ErrorMessage="Укажите время." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="NextTime" 
                            Display="Dynamic" ForeColor="Red" ValidationExpression="^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                            ErrorMessage="Неверный формат времени. Введите время в формате hh:mm или h:mm"></asp:RegularExpressionValidator>

                    </td>
                </tr>    
            </table>
        
            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                ErrorMessage="Дата должна быть не раньше текущей." 
                ServerValidationFunction ="SelectedDateLaterThenNow_ServerValidate"
                Display="Dynamic"  ForeColor="Red" ></asp:CustomValidator>
            <br />

            Продолжительность обслуживания (мин): 
            <asp:TextBox ID="Duration" runat="server"
                Text ="30" Width="21px" ValidationGroup="PlanValidationGroup"></asp:TextBox>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="Duration" Display="Dynamic"
                ErrorMessage="&nbsp;Продолжительность обслуживания должна быть числом." 
                ValidationExpression="^[0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="Duration" ErrorMessage="&nbsp;Недопустимая продолжительность обслуживания."
                Display="Dynamic"  ForeColor="Red" MaximumValue="90" MinimumValue="30"></asp:RangeValidator>

            <br />
            <br />
        
            <asp:Button ID="PlanButton" runat="server" Text="Запланировать" OnClick="Button1_Click"/>
            <br />
            <br />
            <asp:CustomValidator ID="CustomValidator2" runat="server" ValidationGroup="PlanValidationGroup"
                Display="Dynamic" ForeColor="Red"
                ErrorMessage="В указанный промежуток времени уже запланированы работы."
                ServerValidationFunction ="SelectedDateOlreadyExist_ServerValidate" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br />
            <br />
            <asp:Label ID="LabelOutput" runat="server" Text=""></asp:Label>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <h1>Посмотреть все запланированные работы</h1>
    
        </asp:View>
        <asp:View ID="View3" runat="server">
            <h1>Изменить запланированные работы</h1>
    
        </asp:View>
    </asp:MultiView>

    </form>
</body>
</html>
