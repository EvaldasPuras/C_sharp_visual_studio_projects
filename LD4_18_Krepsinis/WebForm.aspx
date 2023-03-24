<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm.aspx.cs" Inherits="WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Krepsininkai</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel3" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderWidth="2px" Font-Bold="True" HorizontalAlign="Center" Width="730px">
            LD4_18_Krepšinis</asp:Panel>
        <br />
        Nurodykite poziciją&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nurodykite norimų rodyti žaidėjų kiekį<br />
        <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#CCFF99" Height="25px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="123px">
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" BackColor="#CCFF99"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderWidth="1px" OnClick="Button1_Click" Text="Sudaryti sąrašą" Height="50px" Width="200px"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" Font-Italic="False" Font-Size="Large" HorizontalAlign="Center" Width="887px">
            Zaidėjai</asp:Panel>
        <asp:Table ID="Table1" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Both" Width="891px">
        </asp:Table>
    
    </div>
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    </form>
</body>
</html>
