<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Grade.aspx.cs" Inherits="newGrade" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- ImageReady Slices (计算机文化技术在线考试final2.psd) -->
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
        <div style="z-index: 101; left: 357px; width: 100px; position: absolute; top: 139px;
            height: 100px">
            &nbsp;&nbsp;
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyNames="ExaID" DataSourceID="SqlDataSource1" Font-Size="Smaller" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    Width="289px">
                    <Columns>
                        <asp:BoundField DataField="ExaID" HeaderText="考试编号" InsertVisible="False" ReadOnly="True"
                            SortExpression="ExaID" />
                        <asp:BoundField DataField="ExaDescription" HeaderText="考试备注" SortExpression="ExaDescription" />
                        <asp:ButtonField ButtonType="Image" CommandName="select" HeaderText="批卷 " ImageUrl="~/images/editor.gif"
                            Text="批卷 " />
                    </Columns>
                    <PagerStyle Font-Size="Smaller" />
                    <HeaderStyle BackColor="#B7DB6E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                    SelectCommand="SELECT [ExaID], [ExaDescription] FROM [Examination] ORDER BY [ExaID]">
                </asp:SqlDataSource>
                <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="查看成绩" /></asp:Panel>
            <br />
            <asp:Panel ID="panelView" runat="server" Height="50px" Width="125px" Visible="False">
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                    SelectCommand="sp_get_grade" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
                    Font-Size="Smaller" Height="111px" Width="320px">
                    <Columns>
                        <asp:BoundField DataField="UsrName" HeaderText="姓名" SortExpression="UsrName" />
                        <asp:BoundField DataField="UsrID" HeaderText="学号" ReadOnly="True" SortExpression="UsrID" />
                        <asp:BoundField DataField="FinalScore" HeaderText="成绩" SortExpression="FinalScore">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UsrDept" HeaderText="学院" SortExpression="UsrDept" />
                        <asp:BoundField DataField="UsrClass" HeaderText="班级" SortExpression="UsrClass" />
                    </Columns>
                    <HeaderStyle BackColor="#B7DB6E" />
                </asp:GridView>
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="导出" /><asp:Button
                    ID="btnBack" runat="server" OnClick="btnImport_Click" Text="返回" /></asp:Panel>
        </div>
<!-- End ImageReady Slices -->
    </div>
    </form>
</body>
</html>
