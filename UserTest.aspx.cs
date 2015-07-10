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
using System.Data.SqlClient;
using StuExam;
using System.IO;
using System.Text;
using System.Data.OleDb;


public partial class Web_UserTest : System.Web.UI.Page
{
    private StudentExam stuInfo = new StudentExam();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        timebox.Text = Request.Cookies["time"].Value;
        Label9.Text = "你好," + Request.Cookies["UserID"].Value + "号" + Request.Cookies["UserName"].Value + "同学，现在开始做题，";

        if (!IsPostBack)
        {
            InitData();
        }

    }
 
    protected void InitData()
    {
        SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        conn.Open();

        SqlCommand objcmd = new SqlCommand(" select PapID from Examination where ExaNow='1'", conn);
        int m = Convert.ToInt32(objcmd.ExecuteScalar());
        conn.Close();
        SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        objconn.Open();
        SqlDataAdapter adp = new SqlDataAdapter();
        adp.SelectCommand = new SqlCommand("select * from QesPapConn,Question where QesPapConn.PapID = '" + m + "' and QesPapConn.QesID = Question.QesID and QesType='选择题'order by newid()", objconn);
        DataSet ds = new DataSet();
        adp.Fill(ds); //填充DataSet内存数扰库
        objconn.Close();
        Response.Write(ds.Tables[0].DefaultView.Count); //显增当前查询结果的总行数
        this.GridView1.DataSource = ds.Tables[0]; //绑定到gridview数据源
        this.GridView1.DataBind();

        SqlConnection objconn2 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        objconn2.Open();
        SqlDataAdapter adp2 = new SqlDataAdapter();
        adp2.SelectCommand = new SqlCommand("select * from QesPapConn,MultiSelectQuestion where QesPapConn.PapID = '" + m + "' and QesPapConn.QesID = MultiSelectQuestion.QesID and QesType='多选题'order by newid()", objconn2);
        DataSet ds2 = new DataSet();
        adp2.Fill(ds2); //填充DataSet内存数扰库
        objconn2.Close();
        Response.Write(ds2.Tables[0].DefaultView.Count); //显增当前查询结果的总行数
        this.GridView2.DataSource = ds2.Tables[0]; //绑定到gridview数据源
        this.GridView2.DataBind();

        SqlConnection objconn1 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        objconn1.Open();
        SqlDataAdapter adp1 = new SqlDataAdapter();
        adp1.SelectCommand = new SqlCommand("select * from QesPapConn,JudgeQuestion where QesPapConn.PapID = '" + m + "' and QesPapConn.QesID = JudgeQuestion.JudgeID and QesType='判断题' order by newid()", objconn1);
        DataSet ds1 = new DataSet();
        adp1.Fill(ds1); //填充DataSet内存数扰库
        Response.Write(ds1.Tables[0].DefaultView.Count); //显增当前查询结果的总行数
        this.GridView3.DataSource = ds1.Tables[0]; //绑定到gridview数据源
        this.GridView3.DataBind();
        objconn1.Close();

       SqlConnection objconn3 = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        objconn3.Open();
        SqlDataAdapter adp3 = new SqlDataAdapter();
        adp3.SelectCommand = new SqlCommand("select * from QesPapConn,FillBlankQuestion where QesPapConn.PapID = '" + m + "' and QesPapConn.QesID = FillBlankQuestion.FillBlankQuestionID and QesType='填空题'order by newid()", objconn3);
        DataSet ds3 = new DataSet();
        adp3.Fill(ds3); //填充DataSet内存数扰库
        objconn3.Close();
        Response.Write(ds3.Tables[0].DefaultView.Count); //显增当前查询结果的总行数
        this.GridView4.DataSource = ds3.Tables[0]; //绑定到gridview数据源
        this.GridView4.DataBind();

    }
    protected void InitData1()
    {
        string kk = GetIDSequence();
        string kk1 = GetKeySequence();
        stuInfo.alertIDSequence(kk, Request.Cookies["UserID"].Value);
        stuInfo.alertKeySequence(kk1, Request.Cookies["UserID"].Value);
    }

    protected string GetIDSequence()
    {
        string mm = "";
        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView1.Rows)
            {
                mm += ((Label)dr.FindControl("Label50")).Text.Trim() + " ";
            }
        }
        if (GridView2.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView2.Rows)
            {
                mm += ((Label)dr.FindControl("Label51")).Text.Trim() + " ";
            }
        }
        if (GridView3.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView3.Rows)
            {
                mm += ((Label)dr.FindControl("Label52")).Text.Trim() + " ";
            }
        }
        if (GridView4.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView4.Rows)
            {
                mm += ((Label)dr.FindControl("Label53")).Text.Trim() + " ";
            }
        }
        return mm;
    }
    protected string GetKeySequence()
    {
        string mm = "";
        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView1.Rows)
            {
                mm += ((Label)dr.FindControl("Label3")).Text.Trim() + " ";
            }
        }
        if (GridView2.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView2.Rows)
            {
                mm += ((Label)dr.FindControl("Label7")).Text.Trim() + " ";
            }
        }
        if (GridView3.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView3.Rows)
            {
                mm += ((Label)dr.FindControl("Label11")).Text.Trim() + " ";
            }
        }
        if (GridView4.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView4.Rows)
            {
                mm += ((Label)dr.FindControl("Label16")).Text.Trim() + " ";
            }
        }
        return mm;
    }
    protected string GetUserSequence()
    {
        string mm = "";
        if (GridView1.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView1.Rows)
            {
                if (((RadioButton)dr.FindControl("RadioButton1")).Checked == true)
                {
                    mm += "A ";
                }
                else if (((RadioButton)dr.FindControl("RadioButton2")).Checked == true)
                {
                    mm += "B ";
                }
                else if (((RadioButton)dr.FindControl("RadioButton3")).Checked == true)
                {
                    mm += "C ";
                }
                else if (((RadioButton)dr.FindControl("RadioButton4")).Checked == true)
                {
                    mm += "D ";
                }
                else
                {
                    mm += "* ";
                }
            }
        }
        if (GridView2.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView2.Rows)
            {
                if (((CheckBox)dr.FindControl("CheckBox1")).Checked == true)
                {
                    mm += "A ";
                }
                else if (((CheckBox)dr.FindControl("CheckBox2")).Checked == true)
                {
                    mm += "B ";
                }
                else if (((CheckBox)dr.FindControl("CheckBox3")).Checked == true)
                {
                    mm += "C ";
                }
                else if (((CheckBox)dr.FindControl("CheckBox4")).Checked == true)
                {
                    mm += "D ";
                }
                else
                {
                    mm += "* ";
                }
            }
        }
        if (GridView3.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView3.Rows)
            {
                if (((CheckBox)dr.FindControl("CheckBox5")).Checked == true)
                {
                    mm += "True ";
                }
                else mm += "False ";

            }
        }
        if (GridView4.Rows.Count > 0)
        {
            foreach (GridViewRow dr in GridView4.Rows)
            {
                string str = ((TextBox)dr.FindControl("TextBox1")).Text.Trim();
                if (str!="")
                {
                    mm += str+" ";
                }
                else mm += "* ";
                
            }
        }
        return mm;

    }
    //提交试卷，生成成绩
    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        int score = 0;
        if (GridView1.Rows.Count > 0)
        {
            int singlemark = int.Parse(((Label)GridView1.Rows[0].FindControl("Label4")).Text);//取出单选题的每题分值
            foreach (GridViewRow dr in GridView1.Rows)//对单选题每题进行判断用户选择答案
            {
                string str = "";
                if (((RadioButton)dr.FindControl("RadioButton1")).Checked == true)
                {
                    str = "A";
                }
                else if (((RadioButton)dr.FindControl("RadioButton2")).Checked == true)
                {
                    str = "B";
                }
                else if (((RadioButton)dr.FindControl("RadioButton3")).Checked == true)
                {
                    str = "C";
                }
                else if (((RadioButton)dr.FindControl("RadioButton4")).Checked == true)
                {
                    str = "D";
                }
                if (((Label)dr.FindControl("Label3")).Text.Trim() == str)//将用户选择结果和答案进行比较
                {
                    score = score + singlemark;
                }
            }
        }
        if (GridView2.Rows.Count > 0)
        {
            int multimark = int.Parse(((Label)GridView2.Rows[0].FindControl("Label8")).Text);//取出多选题每题分值
            foreach (GridViewRow dr in GridView2.Rows)//对多选题每题进行判断用户选择答案
            {
                string str = "";
                if (((CheckBox)dr.FindControl("CheckBox1")).Checked)
                {
                    str += "A";
                }
                if (((CheckBox)dr.FindControl("CheckBox2")).Checked)
                {
                    str += "B";
                }
                if (((CheckBox)dr.FindControl("CheckBox3")).Checked)
                {
                    str += "C";
                }
                if (((CheckBox)dr.FindControl("CheckBox4")).Checked)
                {
                    str += "D";
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == str)//将用户选择结果和答案进行比较
                {
                    score = score + multimark;
                }
            }
        }
        if (GridView3.Rows.Count > 0)
        {
            int judgemark = int.Parse(((Label)GridView3.Rows[0].FindControl("Label12")).Text);//取出判断题每题分值
            foreach (GridViewRow dr in GridView3.Rows)//对判断题每题进行判断用户选择答案
            {
                bool j = false;
                if (((CheckBox)dr.FindControl("CheckBox5")).Checked == true)
                {
                    j = true;
                }
                if (j == bool.Parse(((Label)dr.FindControl("Label11")).Text.Trim()))
                {
                    score = score + judgemark;
                }
            }
        }
        if (GridView4.Rows.Count > 0)
        {
            int fillmark = int.Parse(((Label)GridView4.Rows[0].FindControl("Label17")).Text);//取出填空题每题分值
            foreach (GridViewRow dr in GridView4.Rows)
            {
                string str = "";
                str = ((TextBox)dr.FindControl("TextBox1")).Text.Trim();
                if (str == ((Label)dr.FindControl("Label16")).Text.Trim())
                {
                    score = score + fillmark;
                }
            }
        }
        String h_UserID = Request.Cookies["UserID"].Value;
        StudentExam myStudentExam = new StudentExam();
        InitData1();
        string strError = myStudentExam.setSingleScore(h_UserID, score);
        if (strError == "1")
        {
            string userSequence = GetUserSequence();
            stuInfo.alertData(userSequence, Request.Cookies["UserID"].Value);
            stuInfo.finshed(Request.Cookies["UserID"].Value);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "updateScript", "var flag= window.confirm('确认交卷？点击确认后就不能继续答题，请慎重选择！');if(flag||!flag)location.href = 'sendBlank.aspx';", true);
        }
        else Response.Write("<script language=javascript>alert('自动评分失败，请等待老师公布成绩！')</script>");

    }
    //抢卷
    protected void imgBtnSubmit1_Click(object sender, ImageClickEventArgs e)

    {
        int score = 0;
        if (GridView1.Rows.Count > 0)
        {
            int singlemark = int.Parse(((Label)GridView1.Rows[0].FindControl("Label4")).Text);//取出单选题的每题分值
            foreach (GridViewRow dr in GridView1.Rows)//对单选题每题进行判断用户选择答案
            {
                string str = "";
                if (((RadioButton)dr.FindControl("RadioButton1")).Checked == true)
                {
                    str = "A";
                }
                else if (((RadioButton)dr.FindControl("RadioButton2")).Checked == true)
                {
                    str = "B";
                }
                else if (((RadioButton)dr.FindControl("RadioButton3")).Checked == true)
                {
                    str = "C";
                }
                else if (((RadioButton)dr.FindControl("RadioButton4")).Checked == true)
                {
                    str = "D";
                }
                if (((Label)dr.FindControl("Label3")).Text.Trim() == str)//将用户选择结果和答案进行比较
                {
                    score = score + singlemark;
                }
            }
        }
        if (GridView2.Rows.Count > 0)
        {
            int multimark = int.Parse(((Label)GridView2.Rows[0].FindControl("Label8")).Text);//取出多选题每题分值
            foreach (GridViewRow dr in GridView2.Rows)//对多选题每题进行判断用户选择答案
            {
                string str = "";
                if (((CheckBox)dr.FindControl("CheckBox1")).Checked)
                {
                    str += "A";
                }
                if (((CheckBox)dr.FindControl("CheckBox2")).Checked)
                {
                    str += "B";
                }
                if (((CheckBox)dr.FindControl("CheckBox3")).Checked)
                {
                    str += "C";
                }
                if (((CheckBox)dr.FindControl("CheckBox4")).Checked)
                {
                    str += "D";
                }
                if (((Label)dr.FindControl("Label7")).Text.Trim() == str)//将用户选择结果和答案进行比较
                {
                    score = score + multimark;
                }
            }
        }
        if (GridView3.Rows.Count > 0)
        {
            int judgemark = int.Parse(((Label)GridView3.Rows[0].FindControl("Label12")).Text);//取出判断题每题分值
            foreach (GridViewRow dr in GridView3.Rows)//对判断题每题进行判断用户选择答案
            {
                bool j = false;
                if (((CheckBox)dr.FindControl("CheckBox5")).Checked == true)
                {
                    j = true;
                }
                if (j == bool.Parse(((Label)dr.FindControl("Label11")).Text.Trim()))
                {
                    score = score + judgemark;
                }
            }
        }
        if (GridView4.Rows.Count > 0)
        {
            int fillmark = int.Parse(((Label)GridView4.Rows[0].FindControl("Label17")).Text);//取出填空题每题分值
            foreach (GridViewRow dr in GridView4.Rows)
            {
                string str = "";
                str = ((TextBox)dr.FindControl("TextBox1")).Text.Trim();
                if (str == ((Label)dr.FindControl("Label16")).Text.Trim())
                {
                    score = score + fillmark;
                }
            }
        }
        String h_UserID = Request.Cookies["UserID"].Value;
        StudentExam myStudentExam = new StudentExam();
        InitData1();
        string strError = myStudentExam.setSingleScore(h_UserID, score);
        if (strError == "1")
        {
            string userSequence = GetUserSequence();
            stuInfo.alertData(userSequence, Request.Cookies["UserID"].Value);
            stuInfo.finshed(Request.Cookies["UserID"].Value);
            Response.Redirect("sendBlank.aspx");
        }
        else Response.Write("<script language=javascript>alert('自动评分失败，请等待老师公布成绩！')</script>");

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色
        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色
        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色
        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", e.Row.ClientID.ToString() + ".checked=true;selectx(this)");//点击行变色
        }
    }

}
