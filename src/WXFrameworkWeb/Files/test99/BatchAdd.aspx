<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BatchAdd.aspx.cs" Inherits="upfile_MaterialManageMent_BatchAdd" %>

<%@ Register Assembly="YYControls" Namespace="YYControls" TagPrefix="yyc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="jquery-1.8.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="低值易耗品">低值易耗品</asp:ListItem>
                <asp:ListItem Value="IT耗材">IT耗材</asp:ListItem>
                <asp:ListItem Value="仪器耗材">仪器耗材</asp:ListItem>
                <asp:ListItem Value="其他">其他</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnSave" runat="server" Text="导入" OnClick="btnSave_Click" />

            <asp:Button ID="btnDoubleSave" runat="server" Text="确认强制导入" OnClick="btnDoubleSave_Click" />

        </div>

        <%--        <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True">
            <Columns>
                <asp:CheckBoxField DataField="JDENO" />
            </Columns>
        </asp:GridView>--%>

        <asp:CheckBoxList ID="CMenu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CMenu_SelectedIndexChanged" RepeatColumns="10" Visible="False"></asp:CheckBoxList>
        <yyc:SmartGridView ID="GridView1" runat="server" AllowPaging="True" class="wxplst" EmptyDataText="Data Is Empty" AllowSorting="True" CellPadding="4" EnableTheming="True" ForeColor="#333333" GridLines="Vertical" MouseOverCssClass="OverRow" PageSize="20" EnableModelValidation="True">
            <Columns>
                <asp:TemplateField>
                    <AlternatingItemTemplate>
                        <table cellpadding="0" cellspacing="0" style="margin:5px 0px; border:1px solid #A0A0A0;width:100%;height:100%">
                            <tr>
                                <td style="padding: 2px 4px; height: 17px; font-family: 微软雅黑; font-style: normal; font-weight: normal; font-size: 9pt; text-decoration: none; background-color: buttonface; color: #102040; background-image: url(mvwres://Microsoft.Web.Design.Client, Version=12.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a/TemplateHeaderBackground.gif); background-repeat: repeat-x; border-bottom: 1px solid #A0A0A0;">ItemTemplate </td>
                            </tr>
                            <tr style="">
                                <td style="padding:4px;height:50px;vertical-align:top;color:#333333;background-color:#EFF3FB;">
                                    <asp:CheckBox ID="item" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </AlternatingItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="all" runat="server" Text=""/>


                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="item" runat="server" />


                    </ItemTemplate>
                    <ItemStyle Width="25px"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="id" />
                <asp:BoundField DataField="JDENO" HeaderText="JDE编号" />
                 <asp:BoundField DataField="MaterialType" HeaderText="物料类型" />
                <asp:BoundField DataField="MaterialName" HeaderText="物料名称" />
                 <asp:BoundField DataField="SupplierNO" HeaderText="品牌货号" />
                <asp:BoundField DataField="Amount" HeaderText="数量" />
                 <asp:BoundField DataField="StorageUnit" HeaderText="单位" />
                <asp:BoundField DataField="UnitDescribe" HeaderText="单位描述" />
                 <asp:BoundField DataField="Price" HeaderText="价格" />
                <asp:BoundField DataField="MDLNO" HeaderText="MDL编号" />
                 <asp:BoundField DataField="IsBackup" HeaderText="是否备库" />
                <asp:BoundField DataField="IsCentralProcurement" HeaderText="是否统购" />
                 <asp:BoundField DataField="SaftCount" HeaderText="安全库存量" />
                <asp:BoundField DataField="ComePerson" HeaderText="入库人" />
                <asp:BoundField DataField="GroupNO" HeaderText="所在组" />
            </Columns>

            <SmartSorting AllowMultiSorting="True" AllowSortTip="True" SortAscImageUrl="~/images/up.gif"
                SortDescImageUrl="~/images/down.gif" />
            <CascadeCheckboxes>
                <yyc:CascadeCheckbox ChildCheckboxID="item" ParentCheckboxID="all" />
            </CascadeCheckboxes>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Left" />
            <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Left" />
        </yyc:SmartGridView>
    </form>
    <div id="DataDIV">
    </div>

</body>
</html>
