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
using System.IO;
using System.Text;
using System.Data.OleDb;

public partial class newGrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        panelView.Visible = true;
        Panel1.Visible = false;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {

        string style = @"<style> .text { mso-number-format:\@; } </script> ";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        this.GridView2.RenderControl(htw);
        sw.Close();
        Response.AddHeader("Content-Disposition", "attachment; filename=test.xls");
        Response.ContentType = "application/ms-excel";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.Write(style);
        Response.Write(sw);
        Response.End();
    }
    protected void btnImport_Click(object sender, EventArgs e)
    {
        panelView.Visible = false;
        Panel1.Visible = true;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        StudentExam myStudentExam = new StudentExam();
        myStudentExam.getScore(Convert.ToInt32(GridView1.SelectedDataKey.Value));
        GridView2.DataBind();
    }
}
