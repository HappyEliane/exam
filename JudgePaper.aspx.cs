using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Questions;
using System.Data.SqlClient;
using System.Data.OleDb;
using StuExam;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public partial class JudgePaper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Questions.Questions myQuestion = new Questions.Questions();
        /*
         *这里是测试代码
         * string strError = myQuestion.AddQuestionTopaper(3, 2);
        lblTest.Text = strError;
        GridView2.DataBind();*/

        for (int index = 0; index < GridView1.Rows.Count; index++)
        {
            CheckBox checkSelect = GridView1.Rows[index].Cells[0].FindControl("checkSelect") as CheckBox;
            if (checkSelect.Checked)
            {

                string h_PapID = Request.Cookies["papID"].Value.ToString();
                SqlConnection objconn1 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                objconn1.Open();
                //string h_PapID = "2";
                SqlCommand objcmd1 = new SqlCommand(" select JudgePapPnt from Paper where papID='" + h_PapID + "'", objconn1);
                String point1 = objcmd1.ExecuteScalar().ToString();
                string strError = myQuestion.AddJudgeQuestionTopaper(Convert.ToInt32(Request.Cookies["papID"].Value), Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()), Convert.ToInt32(point1));
                //string strError = myQuestion.AddQuestionTopaper(3, 5);
                lblTest.Text = strError;
                GridView2.DataBind();

            }

        }


    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Questions.Questions myQuestion = new Questions.Questions();
        /*
         *这里是测试代码
         * string strError = myQuestion.AddQuestionTopaper(3, 2);
        lblTest.Text = strError;
        GridView2.DataBind();*/

        for (int index = 0; index < GridView2.Rows.Count; index++)
        {
            CheckBox checkSelect = GridView2.Rows[index].Cells[0].FindControl("checkSelect") as CheckBox;
            if (checkSelect.Checked)
            {
                //string strError = myQuestion.DelPaper(Convert.ToInt32(Request.Cookies["papID"].Value));
                string strError = myQuestion.DelJudgeQesFromPaper(Convert.ToInt32(Request.Cookies["papID"].Value), Convert.ToInt32(GridView2.Rows[index].Cells[2].Text.ToString()));
                //string strError = myQuestion.AddQuestionTopaper(3, 5);
                lblTest.Text = strError;


            }


        }
        GridView2.DataBind();
        GridView2.Visible = true;

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelQesOfPap.Visible = false;
        panelAdd.Visible = true;
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        panelQesOfPap.Visible = true;
        panelAdd.Visible = false;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Questions.Questions myQuestion = new Questions.Questions();
        /*
         *这里是测试代码
         * string strError = myQuestion.AddQuestionTopaper(3, 2);
        lblTest.Text = strError;
        GridView2.DataBind();*/

        for (int index = 0; index < GridView1.Rows.Count; index++)
        {
            CheckBox checkSelect = GridView1.Rows[index].Cells[0].FindControl("checkSelect") as CheckBox;
            if (checkSelect.Checked)
            {
                string h_PapID = Request.Cookies["papID"].Value.ToString();
                
                SqlConnection objconn1 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                objconn1.Open();
                SqlCommand objcmd1 = new SqlCommand(" select JudgePapPnt from Paper where papID='" + h_PapID + "'", objconn1);
                int point1 = Convert.ToInt32(objcmd1.ExecuteScalar());
                string strError = myQuestion.AddJudgeQuestionTopaper(Convert.ToInt32(Request.Cookies["papID"].Value), Convert.ToInt32(GridView1.DataKeys[index].Value.ToString()), Convert.ToInt32(point1));
                //string strError = myQuestion.AddQuestionTopaper(3, 5);
                lblTest.Text = strError;
            }
            GridView2.DataBind();

        }
    }
    protected void btnQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("SelectPaper.aspx");
    }
    protected void btnJudgeQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("JudgePaper.aspx");
    }
    protected void btnMultiSelectQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("MultiSelectPaper.aspx");
    }
    protected void btnFillBlankQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("FillBlankPaper.aspx");
    }
}
