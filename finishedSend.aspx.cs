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
using System.Data.SqlClient;
public partial class finishedSend : System.Web.UI.Page
{
    private StudentExam update = new StudentExam();
    protected void Page_Load(object sender, EventArgs e)
    {
        String h_UserID = Request.Cookies["UserID"].Value;
        update.finshed(h_UserID);
        SqlConnection h_conn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        h_conn.Open();
        SqlCommand h_objcmd = new SqlCommand(" select FinalScore from StuExaConn where StuID='" + h_UserID + "'", h_conn);
        int m1 = Convert.ToInt32(h_objcmd.ExecuteScalar());
        h_conn.Close();
        Label1.Text = Request.Cookies["UserID"].Value + "号" + Request.Cookies["UserName"].Value + "同学，你已经提交了试卷，你的客观题的得分为" + m1 + "分，请尽快退出考场!";
        //Response.Buffer = true;
        //Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1);
        //Response.Expires = 0;
        //Response.CacheControl = "no-cache "; 
    }
}
