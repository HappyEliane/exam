<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stuDefault.aspx.cs" Inherits="stuDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>信息查看</title>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
    <table id="Table_01" width="1366" height="650" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="height: 370px">
			<img src="images/计算机文化技术在线考试final3_01.jpg" width="1366" height="650" alt=""></td>
	</tr>
</table>
    <div>
        <div style="z-index: 101; left: 300px; width: 637px; position: absolute; top: 70px;
            height: 19px">
            <asp:Label ID="Info" runat="server" Text="Label" Width="506px" Font-Size="X-large"></asp:Label><br />
            <br />
            <table style="border-collapse: separate; font-size: large; border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none;">
                <tr>
                    <td style="width: 100px; height: 20px">
                        考试号</td>
                    <td style="width: 100px; height: 20px">
                        试卷号</td>
                    <td style="width: 150px; height: 20px">
                        试卷名称</td>
                    <td style="width: 100px; height: 20px">
                        开始时间</td>
                    <td style="width: 100px; height: 20px">
                        考试时长</td>
                    <td style="width: 100px; height: 20px">
                        出卷老师</td>
                </tr>
                <tr>
                    <td style="width: 120px; height: 30px">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 74px; height: 30px">
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 151px; height: 30px">
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 168px; height: 30px">
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 74px; height: 30px">
                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label></td>
                    <td style="width: 100px; height: 30px">
                        <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label></td>
                </tr>
               
            </table>
        </div>
        <div style="z-index: 102; left: 741px; width: 200px; position: absolute; top: 480px;
            height: 1px">
            &nbsp;
            <div style="z-index: 101; left: -400px; width: 546px; position: absolute; top: -256px;
                height: 240px; background-color: white; font-size: medium;">
                <br />
                &nbsp;考试说明：<br />
                <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 1、本系统供哈尔滨工业大学（威海）学生上机考试之用。<br />
                <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 2、考试时间从考生确认（右下角“确认”按钮）开始计。<br />
                 <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 3、请诚信考试。<br />
                <br />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 4、在考试过程中如果遇到问题，请向监考老师反映。</div>
               <td ><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/确认.jpg"
                OnClick="ImageButton1_Click" /></td>
                </div>
                 <div style="z-index: 101; left: 400px; width: 546px; position: absolute; top: 480px;
                height: 240px; font-size: medium;">
                 <td><asp:ImageButton ID="mima" runat="server" ImageUrl="~/images/密码.jpg"
                OnClick="btnpassword_Click" />
                </div>
            
    </div>
    </form>
</body>
</html>