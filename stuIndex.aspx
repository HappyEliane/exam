<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stuIndex.aspx.cs" Inherits="stuIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>计算机文化基础在线考试--答题页面</title>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
        <div style="z-index: 105; left: 309px; width: 473px; position: absolute; top: 31px;
            height: 27px";Font-Size="large">
            <asp:Label ID="Label9" runat="server" Width="417px" ></asp:Label>
            <div style="z-index: 101; left: 1px; width: 482px; position: absolute; top: 13px;
                height: 21px";>
                <asp:Label ID="Examtime" runat="server" Text="考试时间："></asp:Label><asp:Label ID="timebox" runat="server"></asp:Label>
                <asp:Label ID="timeInfo" runat="server" Text="分钟，你还有时间："></asp:Label><input type="text" name="input1" id="Text1" language="javascript" readonly="readOnly" style="background-color: transparent; border-left-color: white; border-bottom-color: white; border-top-style: dotted; border-top-color: white; border-right-style: dotted; border-left-style: dotted; border-right-color: white; border-bottom-style: dotted;" size="20">
                <asp:Button ID="btnword" runat="server" OnClick="btnWord_Click" Text="答案生成word" />
                 <asp:Label ID="Label18" runat="server"  ></asp:Label>
				<script language="javascript">
				var sec=60;
				var min=<%=Request.Cookies["time"].Value%>-1;
				idt=window.setTimeout("update();",1000);
				function update()
				{
				    Get();
				    sec--;
				    
				    
				    if(sec==0)
					{
					    sec=59;
					    min--;
					}
					Set(min,sec);
					document.form1.input1.value= min +"分"+sec +"秒";
					if((min==2)&&(sec==0))
					{
					alert("离考试结束还有2分钟，请及时交卷！")
					}
					if(min<0)
					{
					//alert("时间到了，请交卷！");
					location.href = "sendBlank.aspx";
					}
					idt=window.setTimeout("update();",1000);
			    }
				function Set(min,sec){
                    var Then = new Date();
                    Then.setTime(Then.getTime() + 10*1000);
                    document.cookie = "Cookie1="+min+" "+sec+";expires="+ Then.toGMTString();
                    }
                    function Get(){ 
                    var str = new String(document.cookie);
                    var cookieString = str.substring(0, str.indexOf(";"));
                    var cookieHeader = "Cookie1=";
                    var beginPosition = cookieString.indexOf(cookieHeader);
                    if (beginPosition != -1){
                    var string = new String(cookieString.substring(beginPosition + cookieHeader.length));
                    min =string.substring(0,string.indexOf(' '));
                    sec = string.substring(string.lastIndexOf(' '),string.length);
                    return true;
                    }
                    else
                    {
                    document.form1.input1.value = "Cookie 未找到!";	
                    return false;
                    }
                    }
			    </script>
              </div>
        </div>
    <div>
   <table id="Table_01" width="1007" height="599" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td style="height: 370px; width: 573px;">
			<img src="images/计算机文化技术在线考试final3_01.jpg" width="1366" height="650" alt=""></td>
</table>
<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <div style="z-index: 101; left: 371px; width: 453px; position: absolute; top: 106px;
            height: 405px">
            <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False"
                DataSourceID="SqlDataSource1" Height="1px" Width="348px" OnPageIndexChanged="DetailsView1_PageIndexChanged" GridLines="None">
                <RowStyle BorderWidth="0px" />
                <PagerStyle BorderStyle="None" />
                <FooterTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("QesDescription", "{0}") %>'
                        Width="549px"></asp:Label>
                    <table style="width: 541px; height: 124px">
                        <tr>
                            <td style="width: 1px; height: 41px">
                                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged"
                                    Text="A." /></td>
                            <td style="width: 100px; height: 41px">
                    <asp:Label ID="Label3" runat="server" Height="1px" Text='<%# Eval("QesAnswer1") %>' Width="500px" ForeColor="Black"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 1px; height: 41px">
                                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" Text="B." Width="38px" OnCheckedChanged="RadioButton2_CheckedChanged" /></td>
                            <td style="width: 100px; height: 41px">
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("QesAnswer2", "{0}") %>' Width="500px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 1px; height: 41px">
                                <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" Text="C." OnCheckedChanged="RadioButton3_CheckedChanged" /></td>
                            <td style="width: 100px; height: 41px">
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("QesAnswer3", "{0}") %>' Width="500px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 1px; height: 21px">
                                <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" Text="D." OnCheckedChanged="RadioButton4_CheckedChanged" /></td>
                            <td style="width: 100px; height: 21px">
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("QesAnswer4", "{0}") %>' Width="500px"></asp:Label></td>
                        </tr>
                    </table>
                </FooterTemplate>
            </asp:DetailsView>
            <div style="z-index: 102; left: -68px; width: 613px; position: absolute; top: 320px;
                height: 69px">
            <asp:Label ID="Label1" runat="server" Width="200px" Height="14px"></asp:Label><asp:Label ID="Label10" runat="server" Width="28px" ForeColor="Red"></asp:Label>
               &nbsp;&nbsp;
                <asp:CheckBox
                        ID="CheckBox1" runat="server" AutoPostBack="True"
                        Text="选中答题自动跳转" /><br />
                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/images/SHANG.jpg" />&nbsp;<asp:ImageButton
                    ID="ImageButton2" runat="server" OnClick="ImageButton2_Click" ImageUrl="~/images/XIA.jpg" />&nbsp;&nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
               

                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/jiaojuan.jpg" OnClick="ImageButton3_Click" /></div>
        </div>
        <div style="z-index: 102; left: 22px; width: 93px; color: #6666cc; position: absolute;
            top: 49px; height: 357px">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" Font-Bold="True" ForeColor="Black" Enabled="False" Font-Size="Smaller" OnDataBound="CheckBoxList1_DataBound">
            </asp:CheckBoxList>
        </div>
        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="15000">
        </asp:Timer>
        <div style="z-index: 103; left: 308px; width: 36px; position: absolute; top: 106px;
            height: 16px">
            <asp:Label ID="Label7" runat="server" Font-Size="Larger" Text="题目1：" Width="63px" Height="1px"></asp:Label></div>
        <div style="z-index: 104; left: 75px; width: 32px; position: absolute; top: 50px;
            height: 370px">
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
                DataTextField="QesDescription" DataValueField="QesDescription" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged"
                ToolTip="选中查看题目信息" Width="131px" OnDataBound="RadioButtonList2_DataBound" Font-Size="Smaller" Height="1px">
            </asp:RadioButtonList>
            <div style="z-index: 102; left: -47px; width: 129px; position: absolute; top: -16px;
                height: 1px">
                <asp:Label ID="Label8" runat="server" Font-Size="Smaller" Text="已做题目 查看题目" Width="138px"></asp:Label></div>
            <div style="z-index: 101; left: 139px; width: 4px; position: absolute; top: -44px;
                height: 558px; background-color: silver">
            </div>
        </div>
        <div style="z-index: 106; left: 341px; width: 100px; position: absolute; top: 512px;
            height: 16px">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
                SelectCommand="SELECT Question.QesDescription, Question.QesAnswer1, Question.QesAnswer2, Question.QesAnswer3, Question.QesAnswer4, Question.QesID FROM QesPapConn INNER JOIN Examination ON QesPapConn.PapID = Examination.PapID INNER JOIN Question ON QesPapConn.QesID = Question.QesID WHERE (Examination.ExaNow= 1)">
            </asp:SqlDataSource>
        </div>
    </div>
    </ContentTemplate>
  </asp:UpdatePanel> 
    </form>
</body>
</html>
