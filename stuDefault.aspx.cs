using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using StuExam;
public partial class stuDefault : System.Web.UI.Page
{
    private StudentExam stuexam = new StudentExam();
    protected void Page_Load(object sender, EventArgs e)
    {
        Info.Text = "你好," + Request.Cookies["UserID"].Value +"号" + Request.Cookies["UserName"].Value + "同学,请查看考试信息：";
        string[] str = new string[6];
        str = stuexam.ExamInfo();
        Label3.Text = str[0];
        Label4.Text = str[1];
        Label5.Text = str[2];
        Label6.Text = str[3];
        Label7.Text = str[4];
        Label8.Text = str[5];
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (stuexam.isfinshed(Request.Cookies["UserID"].Value))
            Response.Redirect("finishedSend.aspx");
        else
        {
            stuexam.insertExamInfo(Request.Cookies["UserID"].Value, Label3.Text);
            Session.Add("unfinishedanswer",stuexam.getAnswer(Request.Cookies["UserID"].Value.ToString()));
            for (int i = 0; i < 50;i++ )
                Session.Add("answer"+i.ToString(), "");
            Response.Cookies["time"].Value = stuexam.getTime(Request.Cookies["UserID"].Value);
            Response.Redirect("UserTest.aspx");
        }
    }
    protected void btnpassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditPassword.aspx");
    }
}