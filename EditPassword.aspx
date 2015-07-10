<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditPassword.aspx.cs" Inherits="EditPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>密码修改</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table id="Table_01" width="1366" height="650" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="height: 370px">
			<img src="images/计算机文化技术在线考试final3_01.jpg" width="1366" height="650" alt=""></td>
		</tr>
    </table>
    <div>
        <div style="z-index: 101; left: 300px; width: 637px; position: absolute; top: 70px;
            height: 19px">
            <asp:Label ID="Info" runat="server" Text="Label" Width="700px" Font-Size="X-large"></asp:Label><br />
            <br />
      </div>
        </div>
            
        <div style="z-index: 102; left: 200px; width: 750px; position: absolute; top: 150px;
            height: 100px">
        <asp:Panel ID="panelStart" runat="server" Height="207px" Width="768px">
            
            <table style="width: 590px; height: 204px">
                <tr>
                    <td style="width: 40px">
                        输入原密码：</td>
                    <td style="width: 20px;height: 20px;">
                        <asp:TextBox ID="Password1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 40px; height: 20px;">
                        输入新密码：</td>
                    <td style="width: 44px; height: 20px;">
                        <asp:TextBox ID="Password2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 40px; height: 6px">
                        确认新密码：</td>
                    <td style="width: 44px; height: 20px">
                        <asp:TextBox ID="Password3" runat="server"></asp:TextBox></td>
                </tr>
                </div>
            </table>
            <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="确定" />&nbsp;
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="取消" /><br />
           </asp:Panel>
        </div>
    </form>
</body>
</html>
