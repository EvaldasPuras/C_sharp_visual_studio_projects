<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm.aspx.cs" Inherits="WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderStyle="Solid" BorderWidth="2px" Font-Bold="True" HorizontalAlign="Center" Width="443px">
            LD18 Miestas</asp:Panel>
    
    </div>
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#FFA4A4" Font-Bold="False" ForeColor="Black" OnClick="Button1_Click" Text="Paleisti programą" Width="158px" />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderStyle="Solid" BorderWidth="2px" OnTextChanged="TextBox2_TextChanged" ReadOnly="True" Width="153px">Pradiniai duomenys</asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderStyle="Solid" BorderWidth="2px" Height="299px" OnTextChanged="TextBox1_TextChanged" TextMode="MultiLine" Width="148px" Font-Bold="False" Font-Size="Large"></asp:TextBox>
        <br />
        <br />
    </form>
</body>
</html>
