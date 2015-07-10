<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>计算机文化基础在线考试--登录</title>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <table id="Table_01" width="1007" height="599" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td>
			<img src="images/计算机文化技术在线考试final_01.jpg" width="1366" height="650" alt=""></td>
	<tr>	
</table>
    <div>
        <div style="z-index: 101; left: 1050px; width: 187px; position: absolute; top: 485px;
            height: 50px; color: blue;">
            &nbsp;
            <div style="z-index: 101; left: 9px; width: 182px; position: absolute; top: -48px;
                height: 50px">
            <asp:TextBox ID="UserName" runat="server" Height="25px" Width="171px" BackColor="#ECF6DE" BorderStyle="None"></asp:TextBox></div>
            <asp:TextBox ID="UserPassword" runat="server" TextMode="Password" Width="171px" Height="25px" BackColor="#ECF6DE" BorderStyle="None"></asp:TextBox></div>
        <div style="z-index: 102; left: 1050px; width: 522px; position: absolute; top: 540px;
            height: 1px">
            &nbsp;&nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/计算机文化技术在线考试web_11.jpg"
                OnClick="ImageButton1_Click" />
            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/计算机文化技术在线考试web_13.jpg"
                OnClick="ImageButton2_Click" />
            &nbsp;
        </div>
        <div style="z-index: 103; left: 760px; width: 178px; position: absolute; top: 470px;
            height: 8px">
            <asp:Label ID="Labelerr" runat="server" ForeColor="Lime" Width="206px" Font-Size="Smaller"></asp:Label></div>
    
    </div>
    </form>
</body>
</html>
