using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
/// <summary>
/// StuExam 的摘要说明
/// </summary>
/// 
namespace StuExam
{
    public class StuScore
    {
        public string stuID;
        public string answer;
        public int score;
    }
    public class StudentDetail
    {
        public string UsrID;
        public int UsrPrivilege;
        public string UsrName;
        public string UsrPassword;
        public string UsrClass;
        public string UsrDept;
    }
    public class StudentExam
    {

        public StudentExam()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public SqlDataReader lognIn(string name, string password)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("UserLogin", objconn);//登录存储过程
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramUserName = new SqlParameter("@UserID", SqlDbType.NVarChar, 10);
            paramUserName.Value = name;
            objcmd.Parameters.Add(paramUserName);
            SqlParameter paramUserPwd = new SqlParameter("@UserPwd", SqlDbType.NVarChar, 10);
            paramUserPwd.Value = password;
            objcmd.Parameters.Add(paramUserPwd);
            SqlDataReader dr = objcmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }
        public string[] ExamInfo()
        {
            string[] strInfo;

            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_info", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = objcmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())//读取数据库信息
            {
                strInfo = new string[6];
                for (int i = 0; i < 6; i++)
                {
                    strInfo[i] = dr[i].ToString();
                }
            }
            else
            {
                strInfo = new string[1];
                strInfo[0] = "没找到考试数据信息！";
            }
            objconn.Close();
            return strInfo;
        }

        public string insertExamInfo(string stuID, string ExaID)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_insert_exam_of_info", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramUserID = new SqlParameter("@stuID", SqlDbType.NVarChar, 10);
            paramUserID.Value = stuID;
            objcmd.Parameters.Add(paramUserID);
            SqlParameter paramExaID = new SqlParameter("@ExaID", SqlDbType.BigInt, 8);
            paramExaID.Value = ExaID;
            objcmd.Parameters.Add(paramExaID);
            try
            {
                objcmd.ExecuteNonQuery();
                objconn.Close();
            }
            catch (SqlException SQLexe)
            {
                return SQLexe.ToString();
            }
            return null;
        }

        public bool alertData(string questionAnswer, string stuID)//提交数据，答案
        {

            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_alertdata", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramUserAnswer = new SqlParameter("@questionAnswer", SqlDbType.NVarChar, 50);
            paramUserAnswer.Value = questionAnswer;
            objcmd.Parameters.Add(paramUserAnswer);
            SqlParameter paramUserID = new SqlParameter("@stuID", SqlDbType.NVarChar, 10);
            paramUserID.Value = stuID;
            objcmd.Parameters.Add(paramUserID);
            int temp = objcmd.ExecuteNonQuery();
            objconn.Close();
            if (temp == 0) return false;
            else return true;
        }

        public string getAnswer(string stuID)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_answer", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramStuID = new SqlParameter("@stuID", SqlDbType.VarChar, 10);
            paramStuID.Value = stuID;
            objcmd.Parameters.Add(paramStuID);
            SqlDataReader dr = objcmd.ExecuteReader();
            string answer = "";
            if (dr.Read())
            {
                answer += dr["AnswerSequence"].ToString();//依次获取每题答案
            }
            dr.Close();
            objconn.Close();
            return answer;
        }

        public string getScore(int ExamID)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd1 = new SqlCommand("sp_get_exam_of_keyanswer", objconn);
            objcmd1.CommandType = CommandType.StoredProcedure;
            SqlParameter paramExamID = new SqlParameter("@ExamID", SqlDbType.BigInt, 8);
            paramExamID.Value = ExamID;
            objcmd1.Parameters.Add(paramExamID);
            SqlDataReader dr1 = objcmd1.ExecuteReader();
            string answer = "";
            string exaID = "";
            int scoreforeach = 0;
            exaID = ExamID.ToString();
            while (dr1.Read())
            {
                answer += dr1["QesKey"].ToString();
                scoreforeach = int.Parse(dr1["PapPnt"].ToString());
            }
            dr1.Close();
            SqlCommand objcmd2 = new SqlCommand("sp_get_exam_of_useranswer", objconn);
            objcmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter paramExaID = new SqlParameter("@exaID", SqlDbType.BigInt, 8);
            paramExaID.Value = exaID;
            objcmd2.Parameters.Add(paramExaID);
            SqlDataReader dr2 = objcmd2.ExecuteReader();
            ArrayList list = new ArrayList();
            string sum = "";
            while (dr2.Read())
            {
                StuScore temp = new StuScore();
                temp.stuID = dr2["StuID"].ToString();
                temp.answer = dr2["AnswerSequence"].ToString();
                int score = 0;
                if (!answer.Equals(""))
                {
                    int length = answer.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (temp.answer.Length < length)
                            continue;
                        if (answer.Substring(i, 1).Equals(temp.answer.Substring(i, 1)))
                            score += scoreforeach;
                        sum += answer.Substring(i, 1) + temp.answer.Substring(i, 1) + " ";
                    }
                    temp.score = score;
                    list.Add(temp);
                }
            }
            dr2.Close();
            int listlen = list.Count;
            for (int i = 0; i < listlen; i++)
            {
                SqlCommand objcmd3 = new SqlCommand("sp_get_exam_of_setscore", objconn);
                objcmd3.CommandType = CommandType.StoredProcedure;
                SqlParameter paramStuID = new SqlParameter("@stuID", SqlDbType.NVarChar, 10);
                paramStuID.Value = ((StuScore)list[i]).stuID;
                objcmd3.Parameters.Add(paramStuID);
                SqlParameter paramStuScore = new SqlParameter("@score", SqlDbType.Int, 4);
                paramStuScore.Value = ((StuScore)list[i]).score;
                objcmd3.Parameters.Add(paramStuScore);
                int count = objcmd3.ExecuteNonQuery();
                sum = sum + count.ToString();
            }
            objconn.Close();
            return sum;
        }
        public string setSingleScore(string StuID, int score)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_setscore", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramStuID = new SqlParameter("@stuID", SqlDbType.VarChar, 10);
            paramStuID.Value = StuID;
            objcmd.Parameters.Add(paramStuID);
            SqlParameter paramscore = new SqlParameter("@score", SqlDbType.VarChar, 10);
            paramscore.Value = score;
            objcmd.Parameters.Add(paramscore);
            try
            {
                objconn.Open();
                objcmd.ExecuteNonQuery();
                objconn.Close();
                return "1";
            }
            catch (SqlException SQLexe)
            {
                return SQLexe.ToString();
            }


        }
        public void setTime(int time, string stuID)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_settime", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramTime = new SqlParameter("@time", SqlDbType.BigInt, 8);
            paramTime.Value = time;
            objcmd.Parameters.Add(paramTime);
            SqlParameter paramStuID = new SqlParameter("@stuID", SqlDbType.VarChar, 10);
            paramStuID.Value = stuID;
            objcmd.Parameters.Add(paramStuID);
            objcmd.ExecuteNonQuery();
            objconn.Close();
        }
        public string getTime(string stuID)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_gettime", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramStuID = new SqlParameter("@stuID", SqlDbType.VarChar, 10);
            paramStuID.Value = stuID;
            objcmd.Parameters.Add(paramStuID);
            SqlDataReader dr = objcmd.ExecuteReader();
            string time = "";
            if (dr.Read())
            {
                time = dr["Remainder"].ToString();
            }
            objconn.Close();
            return time;
        }
        public void finshed(string stuID)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_isfinshed", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramStuID = new SqlParameter("@stuID", SqlDbType.BigInt, 8);
            paramStuID.Value = stuID;
            objcmd.Parameters.Add(paramStuID);
            objcmd.ExecuteNonQuery();
            objconn.Close();
        }
        public bool isfinshed(string stuID)
        {
            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_get_exam_of_selectisfinshed", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramStuID = new SqlParameter("@stuID", SqlDbType.BigInt, 8);
            paramStuID.Value = stuID;
            objcmd.Parameters.Add(paramStuID);
            SqlDataReader dr = objcmd.ExecuteReader();
            string flag = "";
            if (dr.Read())
            {
                flag = dr["IsFinished"].ToString();
            }
            objconn.Close();
            if (flag.Equals("1"))
                return true;
            else
                return false;
        }
        //返回学生的详细信息
        public StudentDetail GetStudent(string UsrID)
        {
            //定义Command和sqlConnection的对象实例
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_get_student_details", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //将command对象的类型指定为一个sql存储过程

            SqlParameter prmUsrID = new SqlParameter("@UsrID", SqlDbType.BigInt);
            prmUsrID.Value = UsrID;
            myCommand.Parameters.Add(prmUsrID);

            //SqlParameter prmUsrID = new SqlParameter("@UsrID", SqlDbType.VarChar, 10);
            // prmUsrID.Direction = ParameterDirection.Output;
            // myCommand.Parameters.Add(prmUsrID);

            SqlParameter prmUsrPrivilege = new SqlParameter("@UsrPrivilege", SqlDbType.Int);
            prmUsrPrivilege.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmUsrPrivilege);

            SqlParameter prmUsrName = new SqlParameter("@UsrName", SqlDbType.VarChar, 10);
            prmUsrName.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmUsrName);


            SqlParameter prmUsrPassword = new SqlParameter("@UsrPassword", SqlDbType.Char, 10);
            prmUsrPassword.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmUsrPassword);

            SqlParameter prmUsrClass = new SqlParameter("@UsrClass", SqlDbType.VarChar, 10);
            prmUsrClass.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmUsrClass);

            SqlParameter prmUsrDept = new SqlParameter("@UsrDept", SqlDbType.Char, 20);
            prmUsrDept.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmUsrDept);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            //定义StudentDetail结构体
            StudentDetail studentDetails = new StudentDetail();
            //studentDetails.UsrID = prmUsrID.Value.ToString();
            //studentDetails.UsrPrivilege = Convert.ToChar(prmUsrPrivilege.Value);
            if (prmUsrPrivilege.Value != System.DBNull.Value)
            {
                studentDetails.UsrPrivilege = Convert.ToInt32(prmUsrPrivilege.Value);//执行转换跟下面的代码
            }

            studentDetails.UsrName = prmUsrName.Value.ToString();
            studentDetails.UsrPassword = prmUsrPassword.Value.ToString();
            studentDetails.UsrClass = prmUsrClass.Value.ToString();
            studentDetails.UsrDept = prmUsrDept.Value.ToString();
            return studentDetails;

        }
        public string EditStudent(string UsrID, int UsrPrivilege, string UsrName, string UsrPassword, string UsrClass, string UsrDept)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_student_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmUsrID = new SqlParameter("@UsrID", SqlDbType.VarChar, 10);
            prmUsrID.Value = UsrID;
            myCommand.Parameters.Add(prmUsrID);

            SqlParameter prmUsrPrivilege = new SqlParameter("@UsrPrivilege", SqlDbType.Int);
            prmUsrPrivilege.Value = UsrPrivilege;
            myCommand.Parameters.Add(prmUsrPrivilege);

            SqlParameter prmUsrName = new SqlParameter("@UsrName", SqlDbType.VarChar, 10);
            prmUsrName.Value = UsrName;
            myCommand.Parameters.Add(prmUsrName);

            SqlParameter prmUsrPassword = new SqlParameter("@UsrPassword", SqlDbType.Char, 10);
            prmUsrPassword.Value = UsrPassword;
            myCommand.Parameters.Add(prmUsrPassword);

            SqlParameter prmUsrClass = new SqlParameter("@UsrClass", SqlDbType.VarChar, 10);
            prmUsrClass.Value = UsrClass;
            myCommand.Parameters.Add(prmUsrClass);

            SqlParameter prmUsrDept = new SqlParameter("@UsrDept", SqlDbType.Char, 20);
            prmUsrDept.Value = UsrDept;
            myCommand.Parameters.Add(prmUsrDept);

            try
            {
                myConnecttion.Open();
                myCommand.ExecuteNonQuery();
                myConnecttion.Close();
                return "1";
            }
            catch (SqlException SQLexe)
            {
                return SQLexe.ToString();
            }

        }
        public string EditPassword(string UsrID, string UsrPassword)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_pasword_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmUsrID = new SqlParameter("@UsrID", SqlDbType.VarChar, 10);
            prmUsrID.Value = UsrID;
            myCommand.Parameters.Add(prmUsrID);

            SqlParameter prmUsrPassword = new SqlParameter("@UsrPassword", SqlDbType.Char, 10);
            prmUsrPassword.Value = UsrPassword;
            myCommand.Parameters.Add(prmUsrPassword);

            try
            {
                myConnecttion.Open();
                myCommand.ExecuteNonQuery();
                myConnecttion.Close();
                return "1";
            }
            catch (SqlException SQLexe)
            {
                return SQLexe.ToString();
            }

        }
        public string AddStudent(string UsrID, int UsrPrivilege, string UsrName, string UsrPassword, string UsrClass, string UsrDept)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_student_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmUsrID = new SqlParameter("@UsrID", SqlDbType.VarChar, 10);
            prmUsrID.Value = UsrID;
            myCommand.Parameters.Add(prmUsrID);

            SqlParameter prmUsrPrivilege = new SqlParameter("@UsrPrivilege", SqlDbType.Int);
            prmUsrPrivilege.Value = UsrPrivilege;
            myCommand.Parameters.Add(prmUsrPrivilege);

            SqlParameter prmUsrName = new SqlParameter("@UsrName", SqlDbType.VarChar, 10);
            prmUsrName.Value = UsrName;
            myCommand.Parameters.Add(prmUsrName);

            SqlParameter prmUsrPassword = new SqlParameter("@UsrPassword", SqlDbType.Char, 10);
            prmUsrPassword.Value = UsrPassword;
            myCommand.Parameters.Add(prmUsrPassword);

            SqlParameter prmUsrClass = new SqlParameter("@UsrClass", SqlDbType.VarChar, 10);
            prmUsrClass.Value = UsrClass;
            myCommand.Parameters.Add(prmUsrClass);

            SqlParameter prmUsrDept = new SqlParameter("@UsrDept", SqlDbType.Char, 20);
            prmUsrDept.Value = UsrDept;
            myCommand.Parameters.Add(prmUsrDept);

            try
            {
                myConnecttion.Open();
                myCommand.ExecuteNonQuery();
                myConnecttion.Close();
                return "1";
            }
            catch (SqlException SQLexe)
            {
                return SQLexe.ToString();
            }

        }
        public bool alertIDSequence(string QesIDSequence, string stuID)//提交数据，答案
        {

            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_insert_exam_of_IDSequence", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramQesIDSequence = new SqlParameter("@QesIDSequence", SqlDbType.NVarChar, 300);
            paramQesIDSequence.Value = QesIDSequence;
            objcmd.Parameters.Add(paramQesIDSequence);
            SqlParameter paramUserID = new SqlParameter("@stuID", SqlDbType.NVarChar, 10);
            paramUserID.Value = stuID;
            objcmd.Parameters.Add(paramUserID);
            int temp = objcmd.ExecuteNonQuery();
            objconn.Close();
            if (temp == 0) return false;
            else return true;
        }
        public bool alertUserSequence(string UserAnswerSequence, string stuID)//提交数据，答案
        {

            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_insert_exam_of_UserSequence", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramUserAnswerSequence = new SqlParameter("@UserAnswerSequence", SqlDbType.NVarChar, 300);
            paramUserAnswerSequence.Value = UserAnswerSequence;
            objcmd.Parameters.Add(paramUserAnswerSequence);
            SqlParameter paramUserID = new SqlParameter("@stuID", SqlDbType.NVarChar, 10);
            paramUserID.Value = stuID;
            objcmd.Parameters.Add(paramUserID);
            int temp = objcmd.ExecuteNonQuery();
            objconn.Close();
            if (temp == 0) return false;
            else return true;
        }
        public bool alertKeySequence(string KeySequence, string stuID)//提交数据，答案
        {

            SqlConnection objconn = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            objconn.Open();
            SqlCommand objcmd = new SqlCommand("sp_insert_exam_of_KeySequence", objconn);
            objcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramKeySequence = new SqlParameter("@KeySequence", SqlDbType.NVarChar, 300);
            paramKeySequence.Value = KeySequence;
            objcmd.Parameters.Add(paramKeySequence);
            SqlParameter paramUserID = new SqlParameter("@stuID", SqlDbType.NVarChar, 10);
            paramUserID.Value = stuID;
            objcmd.Parameters.Add(paramUserID);
            int temp = objcmd.ExecuteNonQuery();
            objconn.Close();
            if (temp == 0) return false;
            else return true;
        }

    }
}