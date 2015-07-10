<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserTest.aspx.cs" Inherits="Web_UserTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>在线考试界面</title>
    <style type="text/css">
body
{
	
background-image: url(images/exam2.jpg);

}

</style>
<script type="text/javascript">
     var prevselitem=null;
      function selectx(row)
     {
             if(prevselitem!=null)
             {
                 prevselitem.style.backgroundColor='#ffffff';
             }
             row.style.backgroundColor='PeachPuff';
              prevselitem=row;
            
      }
 </script>

</head>
<body leftmargin=0 rightmargin=0 topmargin=2>
    <form id="form1" runat="server">
    <div id="header">
<div id="biaoti"></div>
</div>
<div id="banner"></div>
<div id="main">
<div style="z-index: 105; left: 309px; width: 473px; position: absolute; top: 31px;
            height: 27px";Font-Size="large">
            <asp:Label ID="Label9" runat="server" Width="417px" ></asp:Label>
            <div style="z-index: 101; left: 1px; width: 482px; position: absolute; top: 13px;
                height: 21px";>
                <asp:Label ID="Examtime" runat="server" Text="考试时间："></asp:Label><asp:Label ID="timebox" runat="server"></asp:Label>
                <asp:Label ID="timeInfo" runat="server" Text="分钟，你还有时间："></asp:Label><input type="text" name="input1" id="Text1" language="javascript" readonly="readOnly" style="background-color: transparent; border-left-color: white; border-bottom-color: white; border-top-style: dotted; border-top-color: white; border-right-style: dotted; border-left-style: dotted; border-right-color: white; border-bottom-style: dotted;" size="20">
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
					//location.href = "ForeSendBlank.aspx";
					//location.href = "sendBlank.aspx";
					//Panel1.Visible = true;
                     //ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "var flag= window.confirm('确认交卷？点击确认后就不能继续答题，请慎重选择！');if(flag)location.href = 'sendBlank.aspx';", true);
                      document.getElementById("imgBtnSubmit1").click();
					
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

    <table cellSpacing="0" style="FONT-SIZE: 16px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellpadding="0" width=800 top=200 align="center"
				 border="1" GridLines=none>
				<tr height=60>
					<td align=center>						
						<b><asp:Label ID="lblPaperName"
                            runat="server"></asp:Label></b></font>				
					</td>
				</tr>
				
				<tr>
				    <td>                        
                        <asp:GridView ID="GridView1" runat="server" Width=100% AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
				                <asp:TemplateField>
				                    <HeaderTemplate>				                    
				                            <asp:Label id=Label24 runat="server" Text=一、单选题(每题>
									                </asp:Label>
									        <asp:Label id=Label27 runat="server">
									                </asp:Label>
                                            <asp:Label ID="Label25" runat="server" Text=分)>
                                            </asp:Label>
				                    </HeaderTemplate>
					                <ItemTemplate>
						                <TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							                <TR>
								                <TD colSpan="3">
									                <asp:Label id=Label1 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
									                </asp:Label>
									                <asp:Label id=Label2 runat="server" Text='<%# Eval("QesDescription","、{0}") %>'>
									                </asp:Label>
									                <asp:Label id=Label3 runat="server" Text='<%# Eval("QesKey") %>' Visible="False">
									                </asp:Label>
									                <asp:Label id=Label4 runat="server" Text='<%# Eval("Mark") %>' Visible="False">
									                </asp:Label>
									                <asp:Label id=Label50 runat="server" Text='<%# Eval("QesID") %>' Visible="False">
									                </asp:Label>									                
									                
									                </TD>
							                </TR>
							                <TR>
								                <TD width="35%">
									                <asp:RadioButton id=RadioButton1 runat="server" Text='<%# Eval("QesAnswer1") %>' GroupName="Sl">
									                </asp:RadioButton></TD>
								                <TD width="35%">
									                <asp:RadioButton id=RadioButton2 runat="server" Text='<%# Eval("QesAnswer2") %>' GroupName="Sl">
									                </asp:RadioButton></TD>
								                <TD></TD>
							                </TR>
							                <TR>
								                <TD width="35%">
									                <asp:RadioButton id=RadioButton3 runat="server" Text='<%# Eval("QesAnswer3") %>' GroupName="Sl">
									                </asp:RadioButton></TD>
								                <TD width="35%">
									                <asp:RadioButton id=RadioButton4 runat="server" Text='<%# Eval("QesAnswer4") %>' GroupName="Sl">
									                </asp:RadioButton></TD>
								                <TD></TD>
							                </TR>
						                </TABLE>
					                </ItemTemplate>
				                </asp:TemplateField>
			                </Columns>
                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>				                
								<tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" Width=100% AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
                            <Columns>
				                <asp:TemplateField>
				                    <HeaderTemplate>				                    
				                            <asp:Label id=Label22 runat="server" Text=二、多选题(每题>
									                </asp:Label>
									        <asp:Label id=Label28 runat="server">
									                </asp:Label>
                                            <asp:Label ID="Label23" runat="server" Text=分)>
                                            </asp:Label>
				                    </HeaderTemplate>
					                <ItemTemplate>
						                <TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							                <TR>
								                <TD colSpan="3">
									                <asp:Label id=Label5 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
									                </asp:Label>
									                <asp:Label id=Label6 runat="server" Text='<%# Eval("QesDescription","、{0}") %>'>
									                </asp:Label>
									                <asp:Label id=Label7 runat="server" Text='<%# Eval("QesKey") %>' Visible="False">
									                </asp:Label>
									                <asp:Label id=Label8 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
									                </asp:Label>
									                <asp:Label id=Label51 runat="server" Text='<%# Eval("QesID") %>' Visible="False">
									                </asp:Label>									                
									                </TD>
							                </TR>
							                <TR>
								                <TD style="HEIGHT: 22px" width="35%">
									                <asp:CheckBox id=CheckBox1 runat="server" Text='<%# Eval("QesAnswer1") %>'>
									                </asp:CheckBox></TD>
								                <TD style="HEIGHT: 22px" width="35%">
									                <asp:CheckBox id=CheckBox2 runat="server" Text='<%# Eval("QesAnswer2") %>'>
									                </asp:CheckBox></TD>
								                <TD style="HEIGHT: 22px"></TD>
							                </TR>
							                <TR>
								                <TD width="35%">
									                <asp:CheckBox id=CheckBox3 runat="server" Text='<%# Eval("QesAnswer3") %>'>
									                </asp:CheckBox></TD>
								                <TD width="350%">
									                <asp:CheckBox id=CheckBox4 runat="server" Text='<%# Eval("QesAnswer4") %>'>
									                </asp:CheckBox></TD>
								                <TD></TD>
							                </TR>
						                </TABLE>
					                </ItemTemplate>
				                </asp:TemplateField>
			                </Columns>
                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView3" runat="server" Width=100% AutoGenerateColumns="False"  OnRowDataBound="GridView3_RowDataBound">
                            <Columns>
				                <asp:TemplateField>
				                    <HeaderTemplate>				                    
				                            <asp:Label id=Label20 runat="server" Text=二、判断题(每题>
									                </asp:Label>
									        <asp:Label id=Label29 runat="server">
									                </asp:Label>
                                            <asp:Label ID="Label21" runat="server" Text=分)>
                                            </asp:Label>
				                    </HeaderTemplate>
					                <ItemTemplate>
						                <TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							                <TR>
								                <TD width="85%">
									                <asp:Label id=Label9 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
									                </asp:Label>
									                <asp:Label id=Label10 runat="server" Text='<%# Eval("QesDescription","、{0}") %>'>
									                </asp:Label>
									                <asp:Label id=Label11 runat="server" Text='<%# Eval("QesKey") %>' Visible="False">
									                </asp:Label>
									                <asp:Label id=Label12 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
									                </asp:Label>
									                <asp:Label id=Label52 runat="server" Text='<%# Eval("JudgeID") %>' Visible="False">
									                </asp:Label>										                
									                </TD>
								                <TD width="15%">
									                <asp:CheckBox id="CheckBox5" runat="server" Text="正确"></asp:CheckBox></TD>
							                </TR>
						                </TABLE>
					                </ItemTemplate>
				                </asp:TemplateField>
			                </Columns>
                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                                <tr>
                    <td>
                        <asp:GridView ID="GridView4" runat="server" Width=100% AutoGenerateColumns="False" OnRowDataBound="GridView4_RowDataBound">
                            <Columns>
				                <asp:TemplateField >
				                    <HeaderTemplate>				                    
				                            <asp:Label id=Label18 runat="server" Text=四、填空题(每题>
									                </asp:Label>
									        <asp:Label id=Label30 runat="server" >
									                </asp:Label>
                                            <asp:Label ID="Label19" runat="server" Text=分)>
                                            </asp:Label>
				                    </HeaderTemplate>
					                <ItemTemplate>
						                <TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							                <TR>
								                <TD>
									                <asp:Label id=Label13 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
									                </asp:Label>
									                <asp:Label id=Label14 runat="server" Text='<%# Eval("QesDescription","、{0}") %>'>
									                </asp:Label>
									                <asp:TextBox id="TextBox1" runat="server" Width="100px"></asp:TextBox>

									                <asp:Label id=Label16 runat="server" Text='<%# Eval("QesKey") %>' Visible="False">
									                </asp:Label>
									                <asp:Label id=Label17 runat="server" Text='<%# Eval("Mark") %>' Visible=false>
									                </asp:Label>
									                <asp:Label id=Label53 runat="server" Text='<%# Eval("QesID") %>' Visible="False">
									                </asp:Label>										                												                
									                </TD>
							                </TR>
						                </TABLE>
					                </ItemTemplate>
				                </asp:TemplateField>
			                </Columns>
                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr> 
                 <tr>
                    <td align=center>
                        <asp:ImageButton ID="imgBtnSubmit" runat="server" ImageUrl="~/Images/jiaojuan.jpg" OnClick="imgBtnSubmit_Click" /></td>
                </tr> 
                 <tr>
                    <td>
                        <asp:ImageButton ID="imgBtnSubmit1" runat="server"  ImageUrl="~/Images/jiaojuan.jpg" OnClick="imgBtnSubmit1_Click" /></td>
                </tr> 

			</table>

    </div>
    <div id="footer"></div>
    </form>
</body>
</html>
