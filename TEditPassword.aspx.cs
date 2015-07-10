using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using StuExam;
public partial class TEditPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Info.Text = Request.Cookies["UserName"].Value + "你好,请确认密码修改信息：";

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuForTeacher.aspx");
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        string h_password = Password1.Text.ToString();
        String h_UserID = Request.Cookies["UserID"].Value;
        SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        objconn.Open();

        SqlCommand objcmd = new SqlCommand(" select UsrPassword from UserInfo where UsrID='" + h_UserID + "'", objconn);
        String m = objcmd.ExecuteScalar().ToString();
        m = m.Trim();
        SqlDataReader dr = objcmd.ExecuteReader(CommandBehavior.CloseConnection);
        if (m.Equals(h_password))
        {
            if ((Password2.Text.ToString() != null) && (Password2.Text.ToString().Equals(Password3.Text.ToString())))
            {
                StuExam.StudentExam studentExam = new StuExam.StudentExam();
                string strError = studentExam.EditPassword(h_UserID, Password2.Text.ToString());
                if (strError == "1")
                {
                    Response.Write("<script>alert('修改密码成功，请重新登录！');location='Default.aspx'</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('两次密码不匹配！')</script>");
                return;
            }

        }
        else
        {
            Response.Write("<script>alert('原密码错误！')</script>");
            return;
        }

    }
}
