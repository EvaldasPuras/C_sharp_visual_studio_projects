<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm.aspx.cs" Inherits="WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        3 laboratorinis. LD 18 - Taksi<br />
        <br />
        Metai 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Metai 2<br />
        <asp:TextBox ID="TextBox1" runat="server" BackColor="#99FF99" ToolTip="Įveskite pirmą amžiaus ribą"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" BackColor="#99FF99" ToolTip="Įveskite antrą amžiaus ribą"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Paleisti programą" BackColor="#FF9595" OnClick="Button1_Click" />
        <br />
        <br />
        Vairuotojų sąrašas<br />
        <asp:Table ID="Table1" runat="server" BackColor="#CCFF99" BorderColor="#006600" BorderStyle="Solid" BorderWidth="1px">
        </asp:Table>
    </form>
</body>
</html>
