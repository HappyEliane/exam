<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StuInfo.aspx.cs" Inherits="StuInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
     <div style="z-index: 101; left: 50px; width: 743px; position: absolute; top: 69px;
        height: 219px">
      &nbsp;<asp:Panel ID="panelAdd" runat="server" Visible="False" Width="765px" >
<h3>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server"></asp:Label></h3>
    
            <div style="z-index: 101; left: 100px; width: 400px; position: absolute; top: 100px;
                height: 130px">
        具体信息：<br />
        <table style="width: 358px; height: 182px">
            <tr>
                <td style="width: 100px; height: 50px">
                    学号:</td>
                <td style="width:300px" visible="False">
                    <asp:TextBox ID="TextUsrID" runat="server" Height="20px"  Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 50px">
                    权限号:</td>
                <td style="width: 400px; height: 50px">
        <asp:RadioButtonList ID="txtPrivilege" runat="server" Height="30px" Width="180px" RepeatDirection="Horizontal">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            </asp:RadioButtonList></td>
            </tr>
            <tr>
                 <td style="width: 100px; height: 50px">
                    姓名：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtName" runat="server" Height="20px"  Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 51px;">
                    密码:</td>
                <td style="width: 214px; height: 51px;">
                    <asp:TextBox ID="txtPassword" runat="server" Height="20px"  Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 51px;">
                    班级:</td>
                <td style="width: 214px; height: 51px;">
                    <asp:TextBox ID="txtClass" runat="server" Height="20px"  Width="150px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 133px; height: 51px">
                    专业:</td>
                    <td style="width: 214px; height: 51px;">
                   <asp:TextBox ID="TextDept" runat="server" Height="20px"  Width="150px"></asp:TextBox></td>
            </tr>
           
        </table>
         <p>
        <asp:Button ID="btn_Submit" runat="server" Text="提交" OnClick="btn_Submit_Click" />
        <asp:Button ID="btn_Reset" runat="server" Text="重写" OnClick="btn_Reset_Click" />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" /></p>
    <p>
    
            </div>
            
         &nbsp;&nbsp;             

        
        </asp:Panel>

         <asp:Panel ID="PanelView" runat="server" Height="50px" Width="654px">
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <strong>
        学生信息<br />
             </strong>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
           SelectCommand="SELECT * FROM [UserInfo] WHERE [UsrPrivilege] = '2' " DeleteCommand="DELETE FROM [UserInfo] WHERE [UsrID] = @UsrID DELETE FROM [StuExaConn] WHERE [StuID] = @StuID" InsertCommand="INSERT INTO [UserInfo] ([UsrID], [UsrPrivilege], [UsrName], [UsrPassword], [UsrClass], [UsrDept]) VALUES (@UsrID, @UsrPrivilege, @UsrName, @UsrPassword, @UsrClass, @UsrDept)" UpdateCommand="UPDATE [UserInfo] SET  [UsrPrivilege] = @UsrPrivilege, [UsrName] = @UsrName, [UsrPassword] = @UsrPassword, [UsrClass] = @UsrClass, [UsrDept] = @UsrDept WHERE [UsrID] = @UsrID">
            <DeleteParameters>
                <asp:Parameter Name="UsrID" Type="String" />
                <asp:Parameter Name="StuID" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="UsrPrivilege" Type="Int32" />
                <asp:Parameter Name="UsrName" Type="String" />
                <asp:Parameter Name="UsrPassword" Type="String" />
                <asp:Parameter Name="UsrClass" Type="String" />
                <asp:Parameter Name="UsrDept" Type="String" />
                
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="UsrID" Type="String" />
                <asp:Parameter Name="UsrPrivilege" Type="Int32" />
                <asp:Parameter Name="UsrName" Type="String" />
                <asp:Parameter Name="UsrPassword" Type="String" />
                <asp:Parameter Name="UsrClass" Type="String" />
                <asp:Parameter Name="UsrDept" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" pagesize="18" AutoGenerateColumns="False"
            DataKeyNames="UsrID" DataSourceID="SqlDataSource1"
             Width="971px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Font-Size="Smaller">
            <Columns>
                
                <asp:BoundField DataField="UsrID" HeaderText="学号" SortExpression="UsrID" >
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                 <asp:BoundField DataField="UsrPrivilege" HeaderText="权限号" SortExpression="UsrPrivilege" >
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
                <asp:ButtonField CommandName="Select" DataTextField="UsrName"  HeaderText="姓名"
                    Text="按钮" >
                    <HeaderStyle Wrap="False" />
                </asp:ButtonField>
               
                <asp:BoundField DataField="UsrPassword" HeaderText="密码" SortExpression="UsrPassword" />
                <asp:BoundField DataField="UsrClass" HeaderText="班级" SortExpression="UsrClass" />
                <asp:BoundField DataField="UsrDept" HeaderText="院系" SortExpression="UsrDept" />
                <asp:ButtonField CommandName="delete" Text="删除" ButtonType="Image" HeaderText="删除 " ImageUrl="~/images/delete.gif" >
                    <HeaderStyle Wrap="False" />
                </asp:ButtonField>
            </Columns>
            <HeaderStyle BackColor="#B7DB6E" BorderStyle="None" />
        </asp:GridView>
        <tr>
                <td colspan="3" style="text-align: left">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="305px" />
                    &nbsp; &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="批量导入信息" /></td>
            </tr>
         <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添加学生" /></asp:Panel>

    </div>
           <div style="z-index: 102; left: 1000px; width: 150px; position: absolute; top: 80px;
            height: 100px">
        <asp:Panel ID="panelSearch" runat="server" Height="207px" Width="768px" >
            
          
            <tr>
                    <td style="width: 214px; height: 51px;">
                    <asp:TextBox ID="TextBox1" runat="server" Height="20px"  Width="150px"></asp:TextBox></td>
            </tr>
            <asp:Button ID="BtnSearch" runat="server" OnClick="btnSearch_Click" Text="输入学号查询" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
