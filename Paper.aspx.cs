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

public partial class Paper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         
        //这里是调试信息
        /*
        Response.Cookies["papID"].Value = "3";*/
       /* if (Request.Cookies["papID"].Value != "")
        {
            panelAdd.Visible = true;
            panelStart.Visible = false;
        }*/
          
        
    }

    protected void btnBegain_Click(object sender, EventArgs e)
    {
      
        Questions.Questions myQuestion = new Questions.Questions();
        string strError= myQuestion.AddPaper(Convert.ToInt32( txtPapDuration.Text.ToString()),Convert.ToInt32( Request.Cookies["UserID"].Value.ToString()),
            txtPapName.Text.ToString(), txtPapRmk.Text.ToString(), txtPoint.Text.ToString(), txtMultiSelectPoint.Text.ToString(), txtJudgePoint.Text.ToString(), txtFillBlankPoint.Text.ToString());
        if (strError == "1")
        {
            Response.Redirect("Paper.aspx");
        }
        else
            lblTest1.Text = strError;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void btnDeletePaper_Click(object sender, EventArgs e)
    {
        //删除试卷
        Questions.Questions myQuestion = new Questions.Questions();
        for (int index = 0; index < GridView3.Rows.Count; index++)
        {
            CheckBox checkSelect = GridView3.Rows[index].Cells[0].FindControl("checkSelect") as CheckBox;
            if (checkSelect.Checked)
            {
                string strError = myQuestion.DelPaper(Convert.ToInt32(GridView3.DataKeys[index].Value.ToString()));
                if (strError == "1")
                    Response.Write("<script>alert('删除试卷成功！');location='Paper.aspx'</script>");
                

            }
        }
    }
    protected void btnAddPaper_Click(object sender, EventArgs e)
    {
        panelStart.Visible = true;
        
    }
    protected void btnAddCancel_Click(object sender, EventArgs e)
    {
        panelStart.Visible = false;
        panelPaper.Visible = true;
    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Cookies["PapID"].Value = GridView3.SelectedDataKey.Value.ToString();
        Session.Add("PapID", GridView3.SelectedDataKey.Value.ToString());
        Response.Redirect("SelectPaper.aspx");
    }
    protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        Response.Cookies.Clear();
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("SelectPaper.aspx");
    }
    protected void btnJudgeQuestion_Click(object sender, EventArgs e)
    {
        Response.Redirect("JudgePaper.aspx");
    }
    
}
