<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Question.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>计算机文化基础在线考试系统--题库</title>
</head>
<body>
<form id="form1" runat="server">

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
<!-- End ImageReady Slices -->
    <div style="z-index: 101; left: 18px; width: 743px; position: absolute; top: 80px;
        height: 219px">
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="btnQuestion_Click" ImageUrl="~/images/选择题.jpg" />&nbsp;</asp:ImageButton>
        <asp:ImageButton ID="ImageButton4" runat="server" OnClick="btnMultiSelectQuestion_Click" ImageUrl="~/images/多选题.jpg" />&nbsp;</asp:ImageButton>
        <asp:ImageButton ID="ImageButton2" runat="server" OnClick="btnJudgeQuestion_Click" ImageUrl="~/images/判断题.jpg" />&nbsp;</asp:ImageButton>
        <asp:ImageButton ID="ImageButton3" runat="server" OnClick="btnFillBlankQuestion_Click" ImageUrl="~/images/填空题.jpg" />&nbsp;</asp:ImageButton>

        &nbsp;<asp:Panel ID="panelAdd" runat="server" Visible="False" Width="765px" >
<h3>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server"></asp:Label></h3>
    <p>
        题干：</p>
    <p>
        &nbsp;<asp:TextBox ID="txtDes" runat="server" Height="178px" TextMode="MultiLine" Width="537px"></asp:TextBox></p>
            <div style="z-index: 101; left: 553px; width: 100px; position: absolute; top: 69px;
                height: 100px">
        选项描述：<br />
        <table style="width: 358px; height: 182px">
            <tr>
                <td style="width: 133px">
                    A:</td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtAnswser1" runat="server" Height="41px" TextMode="MultiLine" Width="302px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 133px">
                    B：</td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtAnswser2" runat="server" Height="41px" TextMode="MultiLine" Width="302px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 51px;">
                    C :</td>
                <td style="width: 214px; height: 51px;">
                    <asp:TextBox ID="txtAnswser3" runat="server" Height="41px" TextMode="MultiLine" Width="302px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 51px;">
                    D:</td>
                <td style="width: 214px; height: 51px;">
                    <asp:TextBox ID="txtAnswser4" runat="server" Height="41px" TextMode="MultiLine" Width="302px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 84px">
                    正确答案:</td>
                <td style="width: 214px; height: 84px">
        <asp:RadioButtonList ID="rblKey" runat="server" Height="63px" Width="164px" RepeatDirection="Horizontal">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
        </asp:RadioButtonList></td>
            </tr>
        </table>
            </div>
            <p>
            </p>
    <p>
        <asp:Button ID="btn_Submit" runat="server" Text="提交" OnClick="btn_Submit_Click" />
        <asp:Button ID="btn_Reset" runat="server" Text="重写" OnClick="btn_Reset_Click" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" /></p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp; &nbsp;</p>
    <p>
        <asp:Label ID="lblTest" runat="server"></asp:Label>&nbsp;</p>
     <p>
         &nbsp;&nbsp;</p>
        
        </asp:Panel>
         <asp:Panel ID="PanelView" runat="server" Height="50px" Width="654px">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <strong>
        选择题浏览<br />
             </strong>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="SELECT * FROM [Question]" DeleteCommand="DELETE FROM [Question] WHERE [QesID] = @QesID" InsertCommand="INSERT INTO [Question] ([QesDescription], [QesKey], [QesAnswer1], [QesAnswer2], [QesAnswer3], [QesAnswer4]) VALUES (@QesDescription, @QesKey, @QesAnswer1, @QesAnswer2, @QesAnswer3, @QesAnswer4)" UpdateCommand="UPDATE [Question] SET [QesDescription] = @QesDescription, [QesKey] = @QesKey, [QesAnswer1] = @QesAnswer1, [QesAnswer2] = @QesAnswer2, [QesAnswer3] = @QesAnswer3, [QesAnswer4] = @QesAnswer4 WHERE [QesID] = @QesID">
            <DeleteParameters>
                <asp:Parameter Name="QesID" Type="Int64" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="QesDescription" Type="String" />
                <asp:Parameter Name="QesKey" Type="String" />
                <asp:Parameter Name="QesAnswer1" Type="String" />
                <asp:Parameter Name="QesAnswer2" Type="String" />
                <asp:Parameter Name="QesAnswer3" Type="String" />
                <asp:Parameter Name="QesAnswer4" Type="String" />
                <asp:Parameter Name="QesID" Type="Int64" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="QesDescription" Type="String" />
                <asp:Parameter Name="QesKey" Type="String" />
                <asp:Parameter Name="QesAnswer1" Type="String" />
                <asp:Parameter Name="QesAnswer2" Type="String" />
                <asp:Parameter Name="QesAnswer3" Type="String" />
                <asp:Parameter Name="QesAnswer4" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" pagesize="15" AutoGenerateColumns="False"
            DataKeyNames="QesID" DataSourceID="SqlDataSource1"
             Width="971px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Font-Size="Smaller">
            <Columns>
                <asp:BoundField DataField="QesID" HeaderText="试题编号 " InsertVisible="False" ReadOnly="True"
                    SortExpression="QesID" >
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:ButtonField CommandName="Select" DataTextField="QesDescription" HeaderText="题干"
                    Text="按钮" >
                    <HeaderStyle Wrap="False" />
                </asp:ButtonField>
                <asp:BoundField DataField="QesKey" HeaderText="答案" SortExpression="QesKey" >
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="QesAnswer1" HeaderText="A" SortExpression="QesAnswer1" />
                <asp:BoundField DataField="QesAnswer2" HeaderText="B" SortExpression="QesAnswer2" />
                <asp:BoundField DataField="QesAnswer3" HeaderText="C" SortExpression="QesAnswer3" />
                <asp:BoundField DataField="QesAnswer4" HeaderText="D" SortExpression="QesAnswer4" />
                <asp:ButtonField CommandName="delete" Text="删除" ButtonType="Image" HeaderText="删除 " ImageUrl="~/images/delete.gif" >
                    <HeaderStyle Wrap="False" />
                </asp:ButtonField>
            </Columns>
            <HeaderStyle BackColor="#B7DB6E" BorderStyle="None" />
        </asp:GridView>
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添加选择题" /></asp:Panel>
    </div>
    </form>
</body>
</html>
