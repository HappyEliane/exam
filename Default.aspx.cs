using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;
using StuExam;
public partial class _Default : System.Web.UI.Page 
{
    private StudentExam stuexam;
    protected void Page_Load(object sender, EventArgs e)
    {
        stuexam = new StudentExam();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (UserName.Text != "" || UserPassword.Text != "")
        {
            SqlDataReader dr;
            dr = stuexam.lognIn(UserName.Text, UserPassword.Text);
            if (dr.Read())
            {
                Response.Cookies["UserID"].Value = dr["UsrID"].ToString();
                Response.Cookies["UserName"].Value = dr["UsrName"].ToString();
                int usertype = (int)dr["UsrPrivilege"];
                switch (usertype)
                {
                    case 0: Labelerr.Text = "您的身份为管理员"; Response.Redirect("Administer.aspx"); break;//不做处理
                    case 1: Labelerr.Text = "您的身份为老师"; Response.Redirect("MenuForTeacher.aspx"); break;
                    case 2: Labelerr.Text = "您的身份为学生"; Response.Redirect("stuDefault.aspx"); break;
                }
            }
            else
            {
                Labelerr.Text = "请输入正确的用户名和密码";
            }
        }
        else
            Labelerr.Text = "用户帐号和密码都不能为空！";
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        UserName.Text = "";
        UserPassword.Text = "";
        Labelerr.Text = "";
        UserName.Focus();
    }
}