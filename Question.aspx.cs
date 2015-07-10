using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Questions;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        Questions.Questions question = new Questions.Questions();
        if (Label1.Text == "添加试题")
        {
            string strError = question.AddQuestion(txtDes.Text.ToString(), rblKey.SelectedValue.ToString(), txtAnswser1.Text.ToString(), txtAnswser2.Text.ToString(),
                txtAnswser3.Text.ToString(), txtAnswser4.Text.ToString());
            if (strError == "1")
            {
                Response.Write("<script>alert('添加试题成功！');location='Question.aspx'</script>");
                GridView1.DataBind();
            }
            else
                lblTest.Text = strError;
        }
        else if (Label1.Text == "修改试题")
        {
            string strError = question.EditQuestion(Convert.ToInt32( GridView1.SelectedDataKey.Value),txtDes.Text.ToString(), rblKey.SelectedValue.ToString(), txtAnswser1.Text.ToString(), txtAnswser2.Text.ToString(),
                txtAnswser3.Text.ToString(), txtAnswser4.Text.ToString());
            if (strError =="1")
            {
                Response.Write("<script>alert('修改试题成功！');location='Question.aspx'</script>");
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
         QuestionDetail myQestion = question.GetQuestion(Convert.ToInt32( GridView1.SelectedDataKey.Value));
         txtDes.Text = myQestion.QesDescription;
         txtAnswser1.Text = myQestion.QesAnswer1;
         txtAnswser2.Text = myQestion.QesAnswer2;
         txtAnswser3.Text = myQestion.QesAnswer3;
         txtAnswser4.Text = myQestion.QesAnswer4;
         rblKey.SelectedValue = GridView1.SelectedRow.Cells[2].Text.ToString();
         
    }
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        txtDes.Text = "";
        txtAnswser1.Text = "";
        txtAnswser2.Text = "";
        txtAnswser3.Text = "";
        txtAnswser4.Text = "";
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
