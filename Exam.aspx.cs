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
using Questions;
using System.Data.SqlClient;
using System.Data.OleDb;
using StuExam;


public partial class Exam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Questions.Questions question = new Questions.Questions();
        string strTest= question.AddExam(Convert.ToInt32(ddlPap.SelectedValue), txtDes.Text);
        if (strTest == "1")
        {
            GridView1.DataBind();
            ddlActive.DataBind();
            panelNew.Visible = false;
        }
        else
            lblTest.Text = strTest;
        
    }
    protected void btnNow_Click(object sender, EventArgs e)
    {
        Questions.Questions question = new Questions.Questions();
        question.SetExamActive(Convert.ToInt32(ddlActive.SelectedValue));
        FormView1.DataBind();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        panelNew.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        panelNew.Visible = false;
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {
        DataSourceSelectArguments ee = new DataSourceSelectArguments();
        DataView tmp = (DataView)this.SqlDataSource4.Select(ee);
        Response.Cookies["PapID"].Value = tmp[0][1].ToString();   //从sqldatasource获得列值
        Response.Redirect("Paper.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DataSourceSelectArguments ee = new DataSourceSelectArguments();
        DataView tmp = (DataView)this.SqlDataSource4.Select(ee);
        Response.Cookies["PapID"].Value = tmp[0][1].ToString();   //从sqldatasource获得列值
        Response.Redirect("Paper.aspx");
    }
    protected void btnDeleteExam_Click(object sender, EventArgs e)
    {
        //删除试卷
        Questions.Questions myQuestion = new Questions.Questions();
        //SqlCommand objcmd = new SqlCommand(" select UsrPassword from UserInfo where UsrID='" + h_UserID + "'", objconn);
        //String m = objcmd.ExecuteScalar().ToString();
       // m = m.Trim();
        //SqlDataReader dr = objcmd.ExecuteReader(CommandBehavior.CloseConnection);
        for (int index = 0; index < GridView1.Rows.Count; index++)
        {
            CheckBox checkSelect = GridView1.Rows[index].Cells[0].FindControl("checkSelect") as CheckBox;
            if (checkSelect.Checked)
            {
                string strError = myQuestion.DelExam(Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()));

                if (strError == "1")
                    Response.Write("<script>alert('删除试卷成功！');location='Exam.aspx'</script>");
            }
        }
    }
}
