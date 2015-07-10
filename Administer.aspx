<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Administer.aspx.cs" Inherits="Administer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div >
<!-- ImageReady Slices (计算机文化技术在线考试final2.psd) -->
        <div style="z-index: 101; left: 200px; width: 400px; position: absolute; top: 153px;
            height: 100px">
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <span style="font-size: large">欢迎您：<br />
            您现在登录的是管理员页面。<br />
                您可以进行如下操作：<br />
                <asp:BulletedList ID="BulletedList1" runat="server">
                    <asp:ListItem>教师信息管理</asp:ListItem>
                    <asp:ListItem>学生信息管理</asp:ListItem>
                    <asp:ListItem>批量添加用户信息</asp:ListItem>
                    
                </asp:BulletedList>
            </span>
        </div>
    <table id="Table_01" width="1350" height="600" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td colspan="10">
			<img src="images/计算机文化技术在线考试final2_01.jpg" width="1366" height="17" alt=""></td>
	</tr>
	<tr>
		<td rowspan="2">
			<img src="images/计算机文化技术在线考试final2_03.jpg" width="300" height="353" alt=""></td>
		<td>
            <a href="Administer.aspx">
			<img src="images/首页.jpg" border="0" width="118" height="45" alt=""></a></td>
		<td>
           <a href="TeacherInfo.aspx">
			<img src="images/教师.jpg" border="0" width="245" height="45" alt=""></a></td>
		<td>
            <a href="StuInfo.aspx">
			<img src="images/学生.jpg" border="0" width="240" height="45" alt=""></a></td>
		
		<td rowspan="2">
			<img src="images/计算机文化技术在线考试final2_09.jpg" width="466" height="353" alt=""></td>
	</tr>
	<tr>
		<td colspan="7">
			<img src="images/计算机文化技术在线考试final2_10.jpg" width="930" height="308" alt=""></td>
		
	</tr>
	<tr>
		<td colspan="10">
			<img src="images/计算机文化技术在线考试final2_12.jpg" width="1366" height="131" alt=""></td>
	</tr>
	<tr>
		<td colspan="10">
			<img src="images/计算机文化技术在线考试final2_14.jpg" width="1366" height="130" alt=""></td>
	</tr>
</table>
    </form>
</body>
</html>
