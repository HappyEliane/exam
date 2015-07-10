<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuForTeacher.aspx.cs" Inherits="MenuForTeacher" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>计算机文化基础在线考试--教师首页</title>
<script language="javascript" type="text/javascript">
<!--

function IMG1_onclick() {

}

// -->
</script>
</head>
<body  >
    <form id="form1" runat="server" >
    <div >
<!-- ImageReady Slices (计算机文化技术在线考试final2.psd) -->
        <div style="z-index: 101; left: 200px; width: 400px; position: absolute; top: 153px;
            height: 100px">
            <asp:Label ID="lblName" runat="server"></asp:Label>
            <span style="font-size: large">欢迎您：<br />
            您现在登录的是教师页面。<br />
                您可以进行如下操作：<br />
                <asp:BulletedList ID="BulletedList1" runat="server">
                    <asp:ListItem>管理题库</asp:ListItem>
                    <asp:ListItem>创建删除试卷</asp:ListItem>
                    <asp:ListItem>创建考试</asp:ListItem>
                    <asp:ListItem>批卷</asp:ListItem>
                    <asp:ListItem>修改密码</asp:ListItem>
                </asp:BulletedList>
                <asp:ImageButton ID="mima" runat="server" ImageUrl="~/images/密码.jpg"
                OnClick="btnpassword_Click" />
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
            <a href="MenuForTeacher.aspx">
			<img src="images/计算机文化技术在线考试final2_04.jpg" border="0" width="114" height="45" alt=""></a></td>
		<td>
            <a href="Question.aspx">
			<img src="images/计算机文化技术在线考试final2_05.jpg" border="0" width="118" height="45" alt=""></a></td>
		<td>
            <a href="Paper.aspx">
			<img src="images/计算机文化技术在线考试final2_06.jpg" border="0" width="128" height="45" alt=""></a></td>
		<td colspan="2">
            <a href="Exam.aspx">
			<img src="images/计算机文化技术在线考试final2_07.jpg" border="0" width="124" height="45" alt=""></a></td>
		<td>
            <a href="Grade.aspx">
			<img src="images/计算机文化技术在线考试final2_08.jpg" border="0" width="117" height="45" alt=""></a></td>
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
<!-- End ImageReady Slices -->
        <br />
        </div>
    </form>
</body>
</html>
