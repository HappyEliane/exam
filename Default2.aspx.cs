using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using StuExam;
using System.Data.OleDb;
using MyExam.DataAccessLayer;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
     
       SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
       conn.Open();
        SqlCommand objcmd = new SqlCommand(" select PapID from Examination where ExaNow='1'", conn);
        int m = Convert.ToInt32(objcmd.ExecuteScalar());
        SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        objconn.Open();
        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = new SqlCommand("select * from QesPapConn,Question where QesPapConn.PapID = '" + m + "' and QesPapConn.QesID = Question.QesID and QesType='选择题' order by newid()", objconn);
        DataSet ds = new DataSet();
        adp.Fill(ds); //填充DataSet内存数扰库
        Response.Write(ds.Tables[0].DefaultView.Count); //显增当前查询结果的总行数
        this.GridView1.DataSource = ds.Tables[0]; //绑定到gridview数据源
        this.GridView1.DataBind();

        SqlConnection objconn1 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        objconn1.Open();
        SqlDataAdapter adp1 = new SqlDataAdapter();
        adp1.SelectCommand = new SqlCommand("select * from QesPapConn,JudgeQuestion where QesPapConn.PapID = '" + m + "' and QesPapConn.QesID = JudgeQuestion.JudgeID and QesType='判断题' order by newid()", objconn1);
        DataSet ds1 = new DataSet();
        adp1.Fill(ds1); //填充DataSet内存数扰库
        Response.Write(ds1.Tables[0].DefaultView.Count); //显增当前查询结果的总行数
        this.GridView3.DataSource = ds1.Tables[0]; //绑定到gridview数据源
        this.GridView3.DataBind();
        
    }




        
}
