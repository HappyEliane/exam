<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Exam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>计算机文化基础在线考试系统--考试</title>
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
        &nbsp;
        <div style="z-index: 102; left: 34px; width: 750px; position: absolute; top: 134px;
            height: 100px">
            <span style="font-size: 8pt">
        已有的考试信息：</span><br />
            <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ExaID"
            DataSourceID="SqlDataSource1" Width="455px" Font-Size="Smaller">
            <Columns>
                        <asp:TemplateField HeaderText="选择">
                            <ItemTemplate>
                                <asp:CheckBox ID="checkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                <asp:BoundField DataField="ExaID" HeaderText="考试序号" InsertVisible="False" ReadOnly="True"
                    SortExpression="ExaID" />
                <asp:BoundField DataField="PapID" HeaderText="试卷序号" SortExpression="PapID" />
                <asp:BoundField DataField="ExaDescription" HeaderText="考试备注" SortExpression="ExaDescription" />
                <asp:BoundField DataField="PapName" HeaderText="试卷名" SortExpression="PapName" />
            </Columns>
            <HeaderStyle BackColor="#B7DB6E" BorderStyle="None" Font-Size="Larger" />
        </asp:GridView>
            <div style="z-index: 102; left: 620px; width: 253px; position: absolute; top: 25px;
                height: 175px">
                &nbsp; &nbsp;
                <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource4" OnPageIndexChanging="FormView1_PageIndexChanging">
                    <ItemTemplate>
                        <span style="font-size: 8pt">&nbsp;</span><br />
                        <table>
                            <tr>
                                <td style="width: 189px">
                                    <span style="font-size: 8pt">考试编号：</span></td>
                                <td style="width: 393px">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ExaID") %>' Font-Size="Smaller"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 189px; height: 21px">
                                    <span style="font-size: 8pt">考试备注：</span></td>
                                <td style="width: 393px; height: 21px">
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ExaDescription") %>' Font-Size="Smaller"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 189px; height: 21px">
                                    <span style="font-size: 8pt">试卷编号：</span></td>
                                <td style="width: 393px; height: 21px">
                                    &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("PapID") %>' Font-Size="Smaller"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 189px">
                                    <span style="font-size: 8pt">试卷名：</span></td>
                                <td style="width: 393px">
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Text='<%# Eval("PapName") %>'></asp:LinkButton></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <HeaderStyle BackColor="#B7DB6E" />
                    <HeaderTemplate>
                        当前考试信息
                    </HeaderTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                    SelectCommand="sp_get_exam_now" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
            </div>
            &nbsp;&nbsp;
        <div style="z-index: 101; left: 0px; width: 263px; position: absolute; top: -50px;
            height: 1px">
            <span style="font-size: 8pt">当前考试</span>：<asp:DropDownList ID="ddlActive" runat="server" DataSourceID="SqlDataSource3"
                DataTextField="ExaID" DataValueField="ExaID">
            </asp:DropDownList>
            <asp:Button ID="btnNow" runat="server" Text="确定" OnClick="btnNow_Click" />
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                SelectCommand="SELECT * FROM [Examination]"></asp:SqlDataSource>
        </div>
            <br />
        <asp:Button ID="btnNew" runat="server" Text="新建考试" OnClick="btnNew_Click" />
        <asp:Button ID="Button1" runat="server" Text="删除选中考试" OnClick="btnDeleteExam_Click" />
        <asp:Panel ID="panelNew" runat="server" Height="50px" Width="449px" Visible="False">
            <table>
                <tr>
                    <td style="width: 100px; height: 24px;">
                        <span style="font-size: 8pt">
                        选择试卷：</span></td>
                    <td style="width: 100px; height: 24px;">
                        <asp:DropDownList ID="ddlPap" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="PapName" DataValueField="PapID">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <span style="font-size: 8pt">考试备注：</span></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDes" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="确定" />&nbsp;<asp:Button
                ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" /><br />
            <asp:Label ID="lblTest" runat="server" Text="Label" Visible=false></asp:Label></asp:Panel>
        </div>
    </div>
        <p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="sp_get_exam" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="SELECT [PapName], [PapID] FROM [Paper]"></asp:SqlDataSource>
    </form>
</body>
</html>
