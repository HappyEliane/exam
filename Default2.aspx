<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
    <div>
<table cellSpacing="0" style="FONT-SIZE: 16px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellPadding="0" width=700 align="center"
				bgColor="#ffffff" border="1" bordercolor=gray>
			<tr>
				    <td colspan=4>
                        <asp:Panel ID="Panel1" runat="server" Width=100% Visible="True">
                            <table cellSpacing="0" style="FONT-SIZE: 12px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellPadding="0" width=100%	bgColor="#ffffff" border="1" bordercolor=gray>
				                <tr>
				                    <td>
				                        <asp:GridView ID="GridView1" runat="server" Width=100% AutoGenerateColumns="False">
                                            <Columns>
								                <asp:TemplateField HeaderText="一、选择题">
									                <ItemTemplate>
										                <TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											                <TR>
												                <TD colSpan="3">
													                <asp:Label id=Label1 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label2 runat="server" Text='<%# Eval("QesDescription","、{0}") %>'>
													                </asp:Label>
													                <asp:Label id=Label3 runat="server" Text='<%# Eval("QesID") %>' Visible="False">
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
				                        <asp:GridView ID="GridView3" runat="server" Width=100% AutoGenerateColumns="False">
                                            <Columns>
								                <asp:TemplateField HeaderText="二、判断题">
									                <ItemTemplate>
										                <TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											                <TR>
												                <TD width="85%">
													                <asp:Label id=Label19 runat="server" Text='<%# Container.DataItemIndex+1 %>'>
													                </asp:Label>
													                <asp:Label id=Label20 runat="server" Text='<%# Eval("QesDescription","、{0}") %>'>
													                </asp:Label>
													                <asp:Label id=Label7 runat="server" Text='<%# Eval("QesID") %>' Visible="False">
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
				    
				         </asp:Panel>
				    </td>
				</tr>
			</table>
		</div>
    </form>
</body>
</html>
