using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Questions;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public partial class JudgeQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelAdd.Visible = true;
        Label1.Text = "添加试题";
        PanelView.Visible = false;

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Questions.Questions question = new Questions.Questions();
        if (Label1.Text == "添加试题")
        {
            string strError = question.AddJudgeQuestion(txtDes.Text.ToString(), Convert.ToBoolean(rblKey.SelectedValue));
            if (strError == "1")
            {
                Response.Write("<script>alert('添加试题成功！');location='JudgeQuestion.aspx'</script>");
                GridView1.DataBind();
            }
            else
                lblTest.Text = strError;
        }
        else if (Label1.Text == "修改试题")
        {
            string strError = question.EditJudgeQuestion(Convert.ToInt32(GridView1.SelectedDataKey.Value), txtDes.Text.ToString(),Convert.ToBoolean(rblKey.SelectedValue));
            if (strError == "1")
            {
                Response.Write("<script>alert('修改试题成功！');location='JudgeQuestion.aspx'</script>");
                GridView1.DataBind();

            }
            else
                lblTest.Text = strError;
        }
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        panelAdd.Visible = true;
        Label1.Text = "修改试题";
        PanelView.Visible = false;

        Questions.Questions question = new Questions.Questions();
        JudgeQuestionDetail myQestion = question.GetJudgeQuestion(Convert.ToInt32(GridView1.SelectedDataKey.Value));
        txtDes.Text = myQestion.QesDescription;
       rblKey.SelectedValue = GridView1.SelectedRow.Cells[2].Text.ToString();
        //rblAnswer.SelectedValue = judgeproblem.Answer.ToString();
       // rblKey.SelectedValue = Convert.ToBoolean(myQestion.QesKey);
      
    }
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        txtDes.Text = "";
        rblKey.SelectedIndex = -1;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        panelAdd.Visible = false;
        PanelView.Visible = true;
    }
    protected void btnQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("Question.aspx");
    }
    protected void btnJudgeQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("JudgeQuestion.aspx");
    }
    protected void btnFillBlankQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("FillBlankQuestion.aspx");
    }
    protected void btnMultiSelectQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("MultiSelectQuestion.aspx");
    }
}
