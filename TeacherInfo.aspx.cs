using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StuExam;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;




public partial class TeacherInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        panelAdd.Visible = true;
        Label1.Text = "修改教师信息";
        PanelView.Visible = false;

        StuExam.StudentExam studentExam = new StuExam.StudentExam();
        StudentDetail myStudent = studentExam.GetStudent(Convert.ToString(GridView1.SelectedDataKey.Value));
        TextUsrID.Text = GridView1.SelectedDataKey.Value.ToString();
        txtPrivilege.Text = (myStudent.UsrPrivilege).ToString();
        txtName.Text = myStudent.UsrName;
        txtPassword.Text = myStudent.UsrPassword;
        txtClass.Text = myStudent.UsrClass;
        TextDept.Text = myStudent.UsrDept;

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        StuExam.StudentExam studentExam = new StuExam.StudentExam();
        if (Label1.Text == "添加教师信息")
        {
            string UserID = TextUsrID.Text.ToString();
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand(" select * from UserInfo where UsrID='" + UserID + "'", objconn);
            SqlDataReader dr = objcmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
                Response.Write("<script>alert('存在ID！')</script>");
            }
            else
            {
                string strError = studentExam.AddStudent(TextUsrID.Text.ToString(), Convert.ToInt32(txtPrivilege.Text.ToString()), txtName.Text.ToString(), txtPassword.Text.ToString(), txtClass.Text.ToString(), TextDept.Text.ToString());

                if (strError == "1")
                {
                    Response.Write("<script>alert('添加教师信息成功！');location='StuInfo.aspx'</script>");
                    GridView1.DataBind();
                }
            }

        }
        else if (Label1.Text == "修改教师信息" || Label1.Text == "查看 / 修改教师信息")
        {
            string strError = studentExam.EditStudent(GridView1.SelectedDataKey.Value.ToString(), Convert.ToInt32(txtPrivilege.Text.ToString()), txtName.Text.ToString(), txtPassword.Text.ToString(), txtClass.Text.ToString(), TextDept.Text.ToString());
            if (strError == "1")
            {
                Response.Write("<script>alert('修改信息成功！');location='StuInfo.aspx'</script>");
                GridView1.DataBind();

            }
        }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        panelAdd.Visible = true;
        Label1.Text = "添加教师信息";
        PanelView.Visible = false;
        txtPrivilege.DataBind();
        txtPrivilege.Items[1].Selected = true;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        objconn.Open();
        string strTemp = TextBox1.Text;  //需要查寻的数据，从TextBox中读取
        string cmdtext = "select *  from UserInfo WHERE UsrID='" + strTemp + "'";
        SqlCommand sqlcmd = new SqlCommand(cmdtext, objconn);
        int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
        if (count != 0)
        {
            panelAdd.Visible = true;
            Label1.Text = "查看/修改教师信息";
            PanelView.Visible = false;
            TextUsrID.Enabled = false;
            StuExam.StudentExam studentExam = new StuExam.StudentExam();
            StudentDetail myStudent = studentExam.GetStudent(Convert.ToString(TextBox1.Text));
            TextUsrID.Text = TextBox1.Text;
            txtPrivilege.Text = (myStudent.UsrPrivilege).ToString();
            txtName.Text = myStudent.UsrName;
            txtPassword.Text = myStudent.UsrPassword;
            txtClass.Text = myStudent.UsrClass;
            TextDept.Text = myStudent.UsrDept;
        }
        else
        {
            Response.Write("<script>alert('ID不存在')</script> ");
            return;//当无文件时,返回
        }

    }

    public DataSet ExecleDs(string filenameurl, string table)
    {
        string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filenameurl + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
        OleDbConnection conn = new OleDbConnection(strConn);
        conn.Open();
        DataSet ds = new DataSet();
        OleDbDataAdapter odda = new OleDbDataAdapter("select * from [Sheet1$]", conn);
        odda.Fill(ds, table);
        return ds;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile == false)//HasFile用来检查FileUpload是否有指定文件
        {
            Response.Write("<script>alert('请您选择Excel文件')</script> ");
            return;//当无文件时,返回
        }
        string IsXls = System.IO.Path.GetExtension(FileUpload1.FileName).ToString().ToLower();//System.IO.Path.GetExtension获得文件的扩展名
        if (IsXls != ".xls")
        {
            Response.Write("<script>alert('只可以选择Excel文件')</script>");
            return;//当选择的不是Excel文件时,返回
        }
        SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        cn.Open();
        string filename = DateTime.Now.ToString("yyyymmddhhMMss") + FileUpload1.FileName;              //获取Execle文件名  DateTime日期函数
        string savePath = Server.MapPath(("~\\upfiles\\") + filename);//Server.MapPath 获得虚拟服务器相对路径
        FileUpload1.SaveAs(savePath);                        //SaveAs 将上传的文件内容保存在服务器上
        DataSet ds = ExecleDs(savePath, filename);           //调用自定义方法
        DataRow[] dr = ds.Tables[0].Select();            //定义一个DataRow数组
        int rowsnum = ds.Tables[0].Rows.Count;
        if (rowsnum == 0)
        {
            Response.Write("<script>alert('Excel表为空表,无数据!')</script>");   //当Excel表为空时,对用户进行提示
        }
        else
        {
            for (int i = 0; i < dr.Length; i++)
            {
                string h_UsrID = dr[i]["ID"].ToString();//日期 excel列名【名称不能变,否则就会出错】
                string h_UsrPrivilege = dr[i]["权限号"].ToString();//编号 列名 以下类似
                string h_UsrName = dr[i]["姓名"].ToString();
                string h_UsrPassword = dr[i]["密码"].ToString();
                string h_UsrClass = dr[i]["班级"].ToString();
                string h_UsrDept = dr[i]["专业"].ToString();

                string sqlcheck = "select count(*) from UserInfo where UsrID='" + h_UsrID + "'";  //检查用户是否存在
                SqlCommand sqlcmd = new SqlCommand(sqlcheck, cn);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count < 1)
                {
                    string insertstr = "insert into UserInfo (UsrID,UsrPrivilege,UsrName,UsrPassword,UsrClass,UsrDept) values('" + h_UsrID + "','" + h_UsrPrivilege + "','" + h_UsrName + "','" + h_UsrPassword + "','" + h_UsrClass + "','" + h_UsrDept + "')";

                    SqlCommand cmd = new SqlCommand(insertstr, cn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (MembershipCreateUserException ex)       //捕捉异常
                    {
                        Response.Write("<script>alert('导入内容:" + ex.Message + "')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('内容重复！禁止导入');location='default.aspx'</script></script> ");
                    continue;
                }
            }
            Response.Write("<script>alert('Excle表导入成功!');location='StuInfo.aspx'</script>");
        }

        cn.Close();

    }
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        TextUsrID.Text = "";
        txtName.Text = "";
        txtPassword.Text = "";
        txtClass.Text = "";
        TextDept.Text = "";

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        panelAdd.Visible = false;
        PanelView.Visible = true;
    }
}
