using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Questions;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public partial class MultiSelectQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Questions.Questions question = new Questions.Questions();
        if (Label1.Text == "添加试题")
        {
            string answer = "";
            for (int i = 0; i < cblKey.Items.Count; i++)
            {
                if (cblKey.Items[i].Selected)
                {
                    answer += cblKey.Items[i].Text;
                }
            }
            string strError = question.AddMultiSelectQuestion(txtDes.Text.ToString(), answer, txtAnswser1.Text.ToString(), txtAnswser2.Text.ToString(),
                txtAnswser3.Text.ToString(), txtAnswser4.Text.ToString());
            if (strError == "1")
            {
                Response.Write("<script>alert('添加试题成功！');location='MultiSelectQuestion.aspx'</script>");
                GridView1.DataBind();
            }
            else
                lblTest.Text = strError;
        }
        else if (Label1.Text == "修改试题")
        {
            string strError = question.EditMultiSelectQuestion(Convert.ToInt32(GridView1.SelectedDataKey.Value), txtDes.Text.ToString(), cblKey.SelectedValue.ToString(), txtAnswser1.Text.ToString(), txtAnswser2.Text.ToString(),
                txtAnswser3.Text.ToString(), txtAnswser4.Text.ToString());
            if (strError == "1")
            {
                Response.Write("<script>alert('修改试题成功！');location='MultiSelectQuestion.aspx'</script>");
                GridView1.DataBind();

            }
            else
                lblTest.Text = strError;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelAdd.Visible = true;
        Label1.Text = "添加试题";
        PanelView.Visible = false;

    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        panelAdd.Visible = true;
        Label1.Text = "修改试题";
        PanelView.Visible = false;

        Questions.Questions question = new Questions.Questions();
        MultiSelectQuestionDetail myQestion = question.GetMultiSelectQuestion(Convert.ToInt32(GridView1.SelectedDataKey.Value));
        txtDes.Text = myQestion.QesDescription;
        txtAnswser1.Text = myQestion.QesAnswer1;
        txtAnswser2.Text = myQestion.QesAnswer2;
        txtAnswser3.Text = myQestion.QesAnswer3;
        txtAnswser4.Text = myQestion.QesAnswer4;
        //cblKey.SelectedValue = GridView1.SelectedRow.Cells[2].Text.ToString();
        string answer = myQestion.QesKey;
        string answer1 = answer.Trim();
        for (int i = 0; i < answer1.Length; i++)
        {
            string item = answer[i].ToString();
            for (int j = 0; j < cblKey.Items.Count; j++)
            {
                if (item == cblKey.Items[i].Text)
                {
                    cblKey.Items[i].Selected = true;
                }
            }
        }
    }
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        txtDes.Text = "";
        txtAnswser1.Text = "";
        txtAnswser2.Text = "";
        txtAnswser3.Text = "";
        txtAnswser4.Text = "";
        cblKey.SelectedIndex = -1;
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
