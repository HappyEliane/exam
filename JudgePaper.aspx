<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JudgePaper.aspx.cs" Inherits="JudgePaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
  <div style="z-index: 101; left: 50px; width: 100px; position: absolute; top: 100px;
            height: 100px">
            <asp:ImageButton ID="ImageButton1" runat="server" OnClick="btnQuestion_Click" ImageUrl="~/images/选择题.jpg" />&nbsp;<asp:ImageButton />
        </br>
        </br>
        <asp:ImageButton ID="ImageButton2" runat="server" OnClick="btnMultiSelectQuestion_Click" ImageUrl="~/images/多选题.jpg" />&nbsp;<asp:ImageButton />
        </br>
        </br>
        <asp:ImageButton ID="ImageButton3" runat="server" OnClick="btnJudgeQuestion_Click" ImageUrl="~/images/判断题.jpg" />&nbsp;<asp:ImageButton />
        </br>
        </br>
        <asp:ImageButton ID="ImageButton4" runat="server" OnClick="btnFillBlankQuestion_Click" ImageUrl="~/images/填空题.jpg" />&nbsp;<asp:ImageButton />
</div>

        <div style="z-index: 103; left: 170px; width: 100px; position: absolute; top: 80px;
            height: 100px">

        <asp:Panel ID="panelAdd" runat="server" Height="292px" Width="785px" Visible="False">
 
            <span style="font-size: 8pt">
            您可以从以下题库中选择试题：</span><br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                DataKeyNames="JudgeID" DataSourceID="SqlDataSource1"
                Width="1000px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" PageSize="15" Font-Size="Smaller" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="选中">
                        <HeaderTemplate>
                            选择
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="JudgeID" HeaderText="编号" InsertVisible="False" ReadOnly="True"
                        SortExpression="JudgeID" />
                    <asp:BoundField DataField="QesDescription" HeaderText="题干" SortExpression="QesDescription" />

                </Columns>
                <HeaderStyle BackColor="#B7DB6E" />
            </asp:GridView>
            &nbsp;<table>
                <tr>
                    <td style="width: 100px">
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="选择试题" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回试卷" /></td>
                </tr>
            </table>
            <br />
            &nbsp;<asp:Label ID="lblTest" runat="server" Visible="False"></asp:Label><br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                                DeleteCommand="DELETE FROM [JudgeQuestion] WHERE [JudgeID] = @JudgeID" InsertCommand="INSERT INTO [JudgeQuestion] ([QesDescription], [QesKey]) VALUES (@QesDescription, @QesKey)"
                SelectCommand="SELECT * FROM [JudgeQuestion]" UpdateCommand="UPDATE [JudgeQuestion] SET [QesDescription] = @QesDescription, [QesKey] = @QesKey WHERE [JudgeID] = @JudgeID">
                <DeleteParameters>
                    <asp:Parameter Name="JudgeID" Type="Int64" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="QesDescription" Type="String" />
                    <asp:Parameter Name="QesKey" Type="Int32" />
                    <asp:Parameter Name="JudgeID" Type="Int64" />
                </UpdateParameters>
                <InsertParameters>
                    <asp:Parameter Name="QesDescription" Type="String" />
                    <asp:Parameter Name="QesKey" Type="Int32" />
              
                </InsertParameters>
            </asp:SqlDataSource>
        </asp:Panel>
        
  
            &nbsp;&nbsp;<asp:Panel ID="panelQesOfPap" runat="server" Height="50px" Visible="True" Width="125px">
          
         <span style="font-size: 8pt">
            试卷中已有判断题：
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                SelectCommand="sp_get_judgeqestion_of_papper" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter DefaultValue="" Name="PapID" SessionField="PapID" Type="Int64" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2"
                Width="1000px" AllowPaging="True" PageSize="15" Font-Size="Larger">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:CheckBox ID="checkSelect" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="PapID" HeaderText="PapID" SortExpression="PapID" Visible="False" />
                    <asp:BoundField DataField="QesID" HeaderText="试题编号" SortExpression="QesID" >
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QesDescription" HeaderText="题干" SortExpression="QesDescription" >
                        <ItemStyle Wrap="True" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="QesKey" HeaderText="答案" SortExpression="QesKey" >
                        <ItemStyle Wrap="False" />
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
               
                </Columns>
                <HeaderStyle BackColor="#B7DB6E" BorderStyle="None" />
            </asp:GridView>
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="删除选中的试题" />
             </ContentTemplate>
                        </asp:UpdatePanel>
                        &nbsp;<asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添加判断题" /><br />
                    </span>
                </asp:Panel>
            <br />
           
        
 
    </form>
</body>
</html>
