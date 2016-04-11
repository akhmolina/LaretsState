﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="LaretsState.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Администрирование регламентных работ на сервисе Ларец</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

        <%-- Текущее состояние --%>
        <asp:Panel ID="StatePanel" runat="server" Width="800px"  Wrap="False" CssClass="">
            <div style="text-align: center">
                <h1>Текущее состояние сервиса "Ларец"</h1>

                <asp:Label ID="StateLabel" runat="server" OnDataBinding="Page_Load"></asp:Label>
                <br />
                <asp:Label ID="PlanLabel" runat="server" OnDataBinding="Page_Load"></asp:Label>
            </div>
        </asp:Panel>
        <br />
    
        <%-- Навигация --%>
        <asp:Panel ID="NavigationPanel" runat="server" Width="800px"  Wrap="False" CssClass="">
            <table style="text-align: center">
                <tr>
                    <td style="width:33%; vertical-align:top">
                        <asp:LinkButton ID="PlanLinkButton" runat="server" OnClick="PlanLinkButton_Click">Запланировать очередное обслуживание</asp:LinkButton>
                    </td>
                    <td style="width:34%; vertical-align:top">
                        <asp:LinkButton ID="ShowAllLinkButton" runat="server" OnClick="ShowAllLinkButton_Click">Посмотреть и изменить все запланированные работы</asp:LinkButton>
                    </td >
                    <td style="width:33%; vertical-align:top">
                        <asp:LinkButton ID="LogOutLinkButton" runat="server" OnClick="LogOutLinkButton_Click">Выйти из системы</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
    
        <asp:MultiView ID="MultiView" runat="server" ActiveViewIndex="0">  
        <%--Запланировать очередное обслуживание--%>
        <asp:View ID="PlanView" runat="server" >
            <asp:Panel ID="MainPanel" runat="server" Width="800px"  Wrap="False" CssClass="">
                
                <h1 style="text-align: center">Запланировать очередное обслуживание</h1>

                <asp:ValidationSummary ID="ValidationSummary" runat="server" ForeColor ="Red" />

                <table style="width:100%" border="0">
                    <tr>
                        <td style="height: 200px; width:30%; vertical-align:top">
                            Дата начала обслуживания:
                        </td>
                        <td style="height: 200px; width:70%; vertical-align:top " >
                            <div style="width:180px; border-color:#CCCCCC; border-style:solid; border-width:1px; text-align:center;">
                                
                                <asp:UpdatePanel ID="NextDatePanel" runat="server" >
                                    <ContentTemplate>
                                        <asp:label ID="NextDateLabel" runat="server" ></asp:label>
                                        <br />
                                        <asp:Calendar ID="NextDate" runat="server"  
                                            OnSelectionChanged="NextDate_SelectionChanged"></asp:Calendar>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>  
                    <tr>
                        <td style="height: 50px; width:30%; vertical-align:top">
                            Время начала обслуживания:
                        </td>
                        <td style="height: 50px; width:70%; vertical-align:top ">
                            <asp:UpdatePanel ID="NextTimeUpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="NextTime" runat="server" Text="00:00" AutoPostBack="true"
                                    ValidationGroup="PlanValidationGroup" Width="50px"></asp:TextBox>
                                
                                    <asp:RequiredFieldValidator ID="NextTimeRequiredFieldValidator" runat="server" 
                                    ControlToValidate="NextTime" Text="*"
                                    ErrorMessage="Укажите время" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="NextTimeRegularExpressionValidator" runat="server"
                                        ControlToValidate="NextTime" 
                                        Display="Dynamic" ForeColor="Red" ValidationExpression="^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
                                        ErrorMessage="Введите время в формате hh:mm или h:mm"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                       </td>
                    </tr> 
                    <tr>
                        <td style="height: 50px; width:30%; vertical-align:top">
                            Продолжительность обслуживания (мин): 
                        </td>
                        <td style="height: 50px; width:70%; vertical-align:top ">
                             <asp:UpdatePanel ID="DurationUpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="Duration" runat="server" AutoPostback="true"
                                        Text ="30" Width="21px" ValidationGroup="PlanValidationGroup"></asp:TextBox>

                                    <br />

                                    <asp:RegularExpressionValidator ID="DurationRegularExpressionValidator" runat="server"
                                        ControlToValidate="Duration" Display="Dynamic"
                                        ErrorMessage="Продолжительность обслуживания должна быть числом" 
                                        ValidationExpression="^[0-9]+$" ForeColor="Red"></asp:RegularExpressionValidator>
                        
                                    <asp:RangeValidator ID="DurationRangeValidator" runat="server" 
                                        ControlToValidate="Duration" ErrorMessage="Допустимая продолжительность обслуживания от 30 до 90 минут"
                                        Display="Dynamic"  ForeColor="Red" MaximumValue="90" MinimumValue="30"></asp:RangeValidator>
                                 </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
                <div style="text-align: center">
                    <asp:Button ID="PlanButton" runat="server" Text="Запланировать"  OnClick="PlanButton_Click"/>           
                    <br />
                    <asp:Label ID="PlanStatus" runat="server" Text=""></asp:Label>
                </div>
            
            </asp:Panel>
        </asp:View>

        <%--Посмотреть и изменить все запланированные работы--%>
        <asp:View ID="ShowAllView" runat="server">
            <h1 style="text-align: center">Посмотреть и изменить запланированные работы</h1>

            <p style="text-align: center">
                <asp:ObjectDataSource ID="ServiceRecordsDataSource" runat="server" 
                    DataObjectTypeName="LaretsState.serviceRecord" TypeName="LaretsState.state"
                    DeleteMethod="deleteRecord" InsertMethod="addRecord" 
                    SelectMethod="getRecords" UpdateMethod="updateRecord" OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>

                <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" ObjectDataSourceId ="ServiceRecordsDataSource" DataSourceID="ServiceRecordsDataSource">
                </asp:GridView>
            </p>
            
        </asp:View>

    </asp:MultiView>

    </form>
</body>
</html>
