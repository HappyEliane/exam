<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Paper.aspx.cs" Inherits="Paper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>计算机文化基础在线考试系统--试卷</title>
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
<!-- End ImageReady Slices -->
        <div style="z-index: 101; left: 17px; width: 100px; position: absolute; top: 74px;
            height: 100px">

          <asp:Panel ID="panelPaper" runat="server" Height="46px" Width="418px">
                <br />
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="PapID"
                    DataSourceID="SqlDataSource3" OnSelectedIndexChanged="GridView3_SelectedIndexChanged"
                    Width="509px" Font-Size="Smaller" OnSelectedIndexChanging="GridView3_SelectedIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                <asp:CheckBox ID="checkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PapID" HeaderText="试卷号" Visible="False" />
                        <asp:ButtonField CommandName="select" DataTextField="PapName" HeaderText="试卷名" Text="按钮" />
                        <asp:BoundField DataField="PapSubmitTime" HeaderText="提交时间" SortExpression="PapSubmitTime" />
                        <asp:BoundField DataField="TcrID" HeaderText="提交者ID" SortExpression="TcrID" />
                    </Columns>
                    <HeaderStyle BackColor="#B7DB6E" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                    SelectCommand="SELECT * FROM [Paper] ORDER BY [PapSubmitTime] DESC"></asp:SqlDataSource>
                <table>
                    <tr>
                        <td style="width: 100px; height: 26px;">
                            <asp:Button ID="btnDeletePaper" runat="server" OnClick="btnDeletePaper_Click" Text="删除选中试卷" /></td>
                        <td style="width: 3733px; height: 26px;">
                            <asp:Button ID="btnAddPaper" runat="server" OnClick="btnAddPaper_Click" Text="添加新试卷" /></td>
                    </tr>
                </table>
            </asp:Panel>
           
            <div style="z-index: 102; left: 600px; width: 750px; position: absolute; top: 80px;
            height: 100px">
        <asp:Panel ID="panelStart" runat="server" Height="207px" Width="768px" Visible="False">
            试卷的详细信息：<br />
            <table style="width: 590px; height: 204px">
                <tr>
                    <td style="width: 155px">
                        试卷题目：</td>
                    <td style="width: 44px">
                        <asp:TextBox ID="txtPapName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 155px; height: 6px;">
                        考试时间（分钟）：</td>
                    <td style="width: 44px; height: 6px;">
                        <asp:TextBox ID="txtPapDuration" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 155px; height: 6px">
                        选择题每题分值：</td>
                    <td style="width: 44px; height: 6px">
                        <asp:TextBox ID="txtPoint" runat="server"></asp:TextBox></td>
                </tr>
                                <tr>
                    <td style="width: 155px; height: 6px">
                     多选题每题分值：</td>
                    <td style="width: 44px; height: 6px">
                        <asp:TextBox ID="txtMultiSelectPoint" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 155px; height: 6px">
                      判断题每题分值：</td>
                    <td style="width: 44px; height: 6px">
                        <asp:TextBox ID="txtJudgePoint" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 155px; height: 6px">
                      填空题每题分值：</td>
                    <td style="width: 44px; height: 6px">
                        <asp:TextBox ID="txtFillBlankPoint" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td style="width: 155px; height: 133px;">
                        备注：</td>
                    <td style="width: 44px; height: 133px;">
                        <asp:TextBox ID="txtPapRmk" runat="server" Height="93px" TextMode="MultiLine" Width="428px"></asp:TextBox></td>
                </tr>
                </div>
            </table>
            <asp:Button ID="btnBegain" runat="server" OnClick="btnBegain_Click" Text="创建试卷" />&nbsp;
            <asp:Button ID="btnAddCancel" runat="server" OnClick="btnAddCancel_Click" Text="取消" /><br />
            <asp:Label ID="lblTest1" runat="server"></asp:Label>&nbsp;
            </asp:Panel>
        </div>
        
    
    </div>
    
    </form>
</body>
</html>
