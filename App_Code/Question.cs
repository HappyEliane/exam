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

/// <summary>
/// Question 的摘要说明
/// </summary>
namespace Questions
{

    //试题信息结构体
    public class QuestionDetail
    {
        public string QesDescription;
        public char QesKey;
        public string QesAnswer1;
        public string QesAnswer2;
        public string QesAnswer3;
        public string QesAnswer4;
    }
    //试卷信息结构体
    public class PaperDetail
    {
        public Int32 PapID;
        public Int32 PapDuration;
        public DateTime PapSubmitTime;
        public string TcrID;
        public string PapName;
        public string PapRmk;
    }
    public class JudgeQuestionDetail
    {
        public string QesDescription;
        public bool QesKey;
    }
    public class FillBlankQuestionDetail
    {
        public string QesDescription;
        public string QesKey;
    }
    public class MultiSelectQuestionDetail
    {
        public string QesDescription;
        public string QesKey;
        public string QesAnswer1;
        public string QesAnswer2;
        public string QesAnswer3;
        public string QesAnswer4;
    }
    public class Questions
    {
        public Questions()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        //为题库添加一道试题
        //定义Connection 和Command实例
        public string AddQuestion(string QesDescription, string QesKey, string QesAnswer1, string QesAnswer2, string QesAnswer3,
            string QesAnswer4)
        {
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_question_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Char, 1);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);

            SqlParameter prmQesAnswer1 = new SqlParameter("@QesAnswer1", SqlDbType.Char, 100);
            prmQesAnswer1.Value = QesAnswer1;
            myCommand.Parameters.Add(prmQesAnswer1);

            SqlParameter prmQesAnswer2 = new SqlParameter("@QesAnswer2", SqlDbType.Char, 100);
            prmQesAnswer2.Value = QesAnswer2;
            myCommand.Parameters.Add(prmQesAnswer2);

            SqlParameter prmQesAnswer3 = new SqlParameter("@QesAnswer3", SqlDbType.Char, 100);
            prmQesAnswer3.Value = QesAnswer3;
            myCommand.Parameters.Add(prmQesAnswer3);

            SqlParameter prmQesAnswer4 = new SqlParameter("@QesAnswer4", SqlDbType.Char, 100);
            prmQesAnswer4.Value = QesAnswer4;
            myCommand.Parameters.Add(prmQesAnswer4);


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
        //修改试题

        
        public string EditQuestion(int QesID, string QesDescription, string QesKey, string QesAnswer1, string QesAnswer2, string QesAnswer3,
            string QesAnswer4)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_question_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Char, 1);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);

            SqlParameter prmQesAnswer1 = new SqlParameter("@QesAnswer1", SqlDbType.Char, 100);
            prmQesAnswer1.Value = QesAnswer1;
            myCommand.Parameters.Add(prmQesAnswer1);

            SqlParameter prmQesAnswer2 = new SqlParameter("@QesAnswer2", SqlDbType.Char, 100);
            prmQesAnswer2.Value = QesAnswer2;
            myCommand.Parameters.Add(prmQesAnswer2);

            SqlParameter prmQesAnswer3 = new SqlParameter("@QesAnswer3", SqlDbType.Char, 100);
            prmQesAnswer3.Value = QesAnswer3;
            myCommand.Parameters.Add(prmQesAnswer3);

            SqlParameter prmQesAnswer4 = new SqlParameter("@QesAnswer4", SqlDbType.Char, 100);
            prmQesAnswer4.Value = QesAnswer4;
            myCommand.Parameters.Add(prmQesAnswer4);


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


        //返回一道题目的详细信息
        public QuestionDetail GetQuestion(Int32 QesID)
        {
            //定义Command和sqlConnection的对象实例
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_get_question_details", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //将command对象的类型指定为一个sql存储过程

            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);


            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Char,1);
            prmQesKey.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesKey);


            SqlParameter prmQesAnswer1 = new SqlParameter("@QesAnswer1", SqlDbType.Char, 100);
            prmQesAnswer1.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer1);

            SqlParameter prmQesAnswer2 = new SqlParameter("@QesAnswer2", SqlDbType.Char, 100);
            prmQesAnswer2.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer2);

            SqlParameter prmQesAnswer3 = new SqlParameter("@QesAnswer3", SqlDbType.Char, 100);
            prmQesAnswer3.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer3);

            SqlParameter prmQesAnswer4 = new SqlParameter("@QesAnswer4", SqlDbType.Char, 100);
            prmQesAnswer4.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer4);

            

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            //定义QuestionDetail结构体
            QuestionDetail questionDetails = new QuestionDetail();
            questionDetails.QesDescription = prmQesDescription.Value.ToString();
            questionDetails.QesAnswer1 = prmQesAnswer1.Value.ToString();
            questionDetails.QesAnswer2 = prmQesAnswer2.Value.ToString();
            questionDetails.QesAnswer3 = prmQesAnswer3.Value.ToString();
            questionDetails.QesAnswer4 = prmQesAnswer4.Value.ToString();
            questionDetails.QesKey = Convert.ToChar( prmQesKey.Value);
            return questionDetails;
        }

         //将题库的一道题加入到试卷中
        public string AddQuestionTopaper(Int32 PapID, Int32 QesID, Int32 Mark)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_paper_question_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);

            //SqlParameter prmQesType = new SqlParameter("@QesType", SqlDbType.BigInt);
            //prmPapID.Value = PapID;
            //myCommand.Parameters.Add(prmPapID);

            SqlParameter prmMark = new SqlParameter("@Mark", SqlDbType.BigInt);
            prmMark.Value = Mark;
            myCommand.Parameters.Add(prmMark);
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

        //从试卷中删除一道试题
        public string DelQesFromPaper(Int32 PapID, Int32 QesID
        )
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_pap_qes_dap", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);
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
        //删除一张试卷
        public string DelPaper(Int32 PapID)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_pap_dap", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);
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
        //创建一张试卷
        public string AddPaper(Int32 PapDuration, Int32 TcrID, string PapName, string PapRmk, string Pappnt, string MultiSelectPapPnt, string JudgePappnt, string FillBlankPapPnt)
        {
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_paper_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmPapDuration = new SqlParameter("@PapDuration", SqlDbType.BigInt);
            prmPapDuration.Value = PapDuration;
            myCommand.Parameters.Add(prmPapDuration);

            SqlParameter prmTcrID = new SqlParameter("@TcrID", SqlDbType.VarChar, 10);
            prmTcrID.Value = TcrID;
            myCommand.Parameters.Add(prmTcrID);

            SqlParameter prmPapName = new SqlParameter("@PapName", SqlDbType.VarChar, 255);
            prmPapName.Value = PapName;
            myCommand.Parameters.Add(prmPapName);

            SqlParameter prmPapRmk = new SqlParameter("@PapRmk", SqlDbType.VarChar,255);
            prmPapRmk.Value = PapRmk;
            myCommand.Parameters.Add(prmPapRmk);

            SqlParameter prmPappnt = new SqlParameter("@Pappnt", SqlDbType.Int);
            prmPappnt.Value =Convert.ToInt32(Pappnt);
            myCommand.Parameters.Add(prmPappnt);

            SqlParameter prmJudgePappnt = new SqlParameter("@JudgePappnt", SqlDbType.Int);
            prmJudgePappnt.Value = Convert.ToInt32(JudgePappnt);
            myCommand.Parameters.Add(prmJudgePappnt);

            SqlParameter prmFillBlankPapPnt = new SqlParameter("@FillBlankPapPnt", SqlDbType.Int);
            prmFillBlankPapPnt.Value = Convert.ToInt32(FillBlankPapPnt);
            myCommand.Parameters.Add(prmFillBlankPapPnt);

            SqlParameter prmMultiSelectPapPnt = new SqlParameter("@MultiSelectPapPnt", SqlDbType.Int);
            prmMultiSelectPapPnt.Value = Convert.ToInt32(MultiSelectPapPnt);
            myCommand.Parameters.Add(prmMultiSelectPapPnt);

            SqlParameter prmPapSubmitTime = new SqlParameter("@PapSubmitTime", SqlDbType.DateTime);
            prmPapSubmitTime.Value = DateTime.Now;
            myCommand.Parameters.Add(prmPapSubmitTime);
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
        public string DelExam(Int32 ExaID)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_exam_dap", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmExaID = new SqlParameter("@ExaID", SqlDbType.BigInt);
            prmExaID.Value = ExaID;
            myCommand.Parameters.Add(prmExaID);
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

        //创建一次考试
        public string AddExam(Int32 PapID, string ExaDescription)
        {
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_exam_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);


            SqlParameter prmExaDescription = new SqlParameter("@ExaDescription", SqlDbType.VarChar, 255);
            prmExaDescription.Value = ExaDescription;
            myCommand.Parameters.Add(prmExaDescription);

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

        //将一次考试设定为当前的考试
        public string SetExamActive(Int32 ExaID)
        {
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_exam_now", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmExaID = new SqlParameter("@ExaID", SqlDbType.BigInt);
            prmExaID.Value = ExaID;
            myCommand.Parameters.Add(prmExaID);
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
public string AddJudgeQuestion(string QesDescription, bool QesKey)//增加判断题
        {
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_judgequestion_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Bit);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);

            
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
        //修改判断试题

        
        public string EditJudgeQuestion(int JudgeID, string QesDescription, bool QesKey)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_judgequestion_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmJudgeID = new SqlParameter("@JudgeID", SqlDbType.BigInt);
            prmJudgeID.Value = JudgeID;
            myCommand.Parameters.Add(prmJudgeID);

            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Bit);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);

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
        //返回一道判断题目的详细信息
        public JudgeQuestionDetail GetJudgeQuestion(Int32 JudgeID)
        {
            //定义Command和sqlConnection的对象实例
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_get_judgequestion_details", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //将command对象的类型指定为一个sql存储过程

            SqlParameter prmJudgeID = new SqlParameter("@JudgeID", SqlDbType.BigInt);
            prmJudgeID.Value = JudgeID;
            myCommand.Parameters.Add(prmJudgeID);


            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Bit);
            prmQesKey.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesKey);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            //定义JudgeQuestionDetail结构体
            JudgeQuestionDetail judgequestionDetails = new JudgeQuestionDetail();
            judgequestionDetails.QesDescription = prmQesDescription.Value.ToString();
            if (prmQesKey.Value != System.DBNull.Value)
            {
                judgequestionDetails.QesKey = Convert.ToBoolean(prmQesKey.Value);//执行转换跟下面的代码
            }
            //judgequestionDetails.QesKey = Convert.ToBoolean(prmQesKey.Value);
            return judgequestionDetails;
        }

        public string AddJudgeQuestionTopaper(Int32 PapID, Int32 QesID, Int32 Mark)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_paper_judgequestion_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);

            //SqlParameter prmQesType = new SqlParameter("@QesType", SqlDbType.BigInt);
            //prmPapID.Value = PapID;
            //myCommand.Parameters.Add(prmPapID);

            SqlParameter prmMark = new SqlParameter("@Mark", SqlDbType.BigInt);
            prmMark.Value = Mark;
            myCommand.Parameters.Add(prmMark);
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

        //从试卷中删除一道试题
        public string DelJudgeQesFromPaper(Int32 PapID, Int32 QesID
        )
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_pap_judgeqes_dap", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);
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
        public string AddFillBlankQuestion(string QesDescription, string QesKey)//增加填空题
        {
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_fillblankquestion_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 500);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.VarChar, 200);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);


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
        //修改填空试题


        public string EditFillBlankQuestion(int FillBlankQuestionID, string QesDescription, string QesKey)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_fillblankquestion_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmFillBlankQuestionID = new SqlParameter("@FillBlankQuestionID", SqlDbType.BigInt);
            prmFillBlankQuestionID.Value = FillBlankQuestionID;
            myCommand.Parameters.Add(prmFillBlankQuestionID);

            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 500);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.VarChar, 200);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);

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
        //返回一道填空题目的详细信息
        public FillBlankQuestionDetail GetFillBlankQuestion(Int32 FillBlankQuestionID)
        {
            //定义Command和sqlConnection的对象实例
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_get_fillblankquestion_details", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //将command对象的类型指定为一个sql存储过程

            SqlParameter prmFillBlankQuestionID = new SqlParameter("@FillBlankQuestionID", SqlDbType.BigInt);
            prmFillBlankQuestionID.Value = FillBlankQuestionID;
            myCommand.Parameters.Add(prmFillBlankQuestionID);


            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 500);
            prmQesDescription.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.VarChar, 200);
            prmQesKey.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesKey);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            //定义JudgeQuestionDetail结构体
            FillBlankQuestionDetail fillblankquestionDetails = new FillBlankQuestionDetail();
            fillblankquestionDetails.QesDescription = prmQesDescription.Value.ToString();
            fillblankquestionDetails.QesKey = prmQesKey.Value.ToString();
            return fillblankquestionDetails;
        }
        public string AddFillBlankQuestionTopaper(Int32 PapID, Int32 QesID, Int32 Mark)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_paper_fillblankquestion_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);

            //SqlParameter prmQesType = new SqlParameter("@QesType", SqlDbType.BigInt);
            //prmPapID.Value = PapID;
            //myCommand.Parameters.Add(prmPapID);

            SqlParameter prmMark = new SqlParameter("@Mark", SqlDbType.BigInt);
            prmMark.Value = Mark;
            myCommand.Parameters.Add(prmMark);
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

        //从试卷中删除一道试题
        public string DelFillBlankQesFromPaper(Int32 PapID, Int32 QesID)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_pap_fillblankqes_dap", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);
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
        //为题库添加一道多选试题
        //定义Connection 和Command实例
        public string AddMultiSelectQuestion(string QesDescription, string QesKey, string QesAnswer1, string QesAnswer2, string QesAnswer3,
            string QesAnswer4)
        {
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_multiselectquestion_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Char, 50);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);

            SqlParameter prmQesAnswer1 = new SqlParameter("@QesAnswer1", SqlDbType.Char, 100);
            prmQesAnswer1.Value = QesAnswer1;
            myCommand.Parameters.Add(prmQesAnswer1);

            SqlParameter prmQesAnswer2 = new SqlParameter("@QesAnswer2", SqlDbType.Char, 100);
            prmQesAnswer2.Value = QesAnswer2;
            myCommand.Parameters.Add(prmQesAnswer2);

            SqlParameter prmQesAnswer3 = new SqlParameter("@QesAnswer3", SqlDbType.Char, 100);
            prmQesAnswer3.Value = QesAnswer3;
            myCommand.Parameters.Add(prmQesAnswer3);

            SqlParameter prmQesAnswer4 = new SqlParameter("@QesAnswer4", SqlDbType.Char, 100);
            prmQesAnswer4.Value = QesAnswer4;
            myCommand.Parameters.Add(prmQesAnswer4);


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
        //修改多选试题


        public string EditMultiSelectQuestion(int QesID, string QesDescription, string QesKey, string QesAnswer1, string QesAnswer2, string QesAnswer3,
            string QesAnswer4)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_multiselectquestion_usp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Value = QesDescription;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Char, 50);
            prmQesKey.Value = QesKey;
            myCommand.Parameters.Add(prmQesKey);

            SqlParameter prmQesAnswer1 = new SqlParameter("@QesAnswer1", SqlDbType.Char, 100);
            prmQesAnswer1.Value = QesAnswer1;
            myCommand.Parameters.Add(prmQesAnswer1);

            SqlParameter prmQesAnswer2 = new SqlParameter("@QesAnswer2", SqlDbType.Char, 100);
            prmQesAnswer2.Value = QesAnswer2;
            myCommand.Parameters.Add(prmQesAnswer2);

            SqlParameter prmQesAnswer3 = new SqlParameter("@QesAnswer3", SqlDbType.Char, 100);
            prmQesAnswer3.Value = QesAnswer3;
            myCommand.Parameters.Add(prmQesAnswer3);

            SqlParameter prmQesAnswer4 = new SqlParameter("@QesAnswer4", SqlDbType.Char, 100);
            prmQesAnswer4.Value = QesAnswer4;
            myCommand.Parameters.Add(prmQesAnswer4);


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


        //返回一道多选题目的详细信息
        public MultiSelectQuestionDetail GetMultiSelectQuestion(Int32 QesID)
        {
            //定义Command和sqlConnection的对象实例
            SqlConnection myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_get_multiselectquestion_details", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            //将command对象的类型指定为一个sql存储过程

            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);


            SqlParameter prmQesDescription = new SqlParameter("@QesDescription", SqlDbType.VarChar, 300);
            prmQesDescription.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesDescription);

            SqlParameter prmQesKey = new SqlParameter("@QesKey", SqlDbType.Char, 50);
            prmQesKey.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesKey);


            SqlParameter prmQesAnswer1 = new SqlParameter("@QesAnswer1", SqlDbType.Char, 100);
            prmQesAnswer1.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer1);

            SqlParameter prmQesAnswer2 = new SqlParameter("@QesAnswer2", SqlDbType.Char, 100);
            prmQesAnswer2.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer2);

            SqlParameter prmQesAnswer3 = new SqlParameter("@QesAnswer3", SqlDbType.Char, 100);
            prmQesAnswer3.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer3);

            SqlParameter prmQesAnswer4 = new SqlParameter("@QesAnswer4", SqlDbType.Char, 100);
            prmQesAnswer4.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(prmQesAnswer4);



            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();

            //定义QuestionDetail结构体
            MultiSelectQuestionDetail questionDetails = new MultiSelectQuestionDetail();
            questionDetails.QesDescription = prmQesDescription.Value.ToString();
            questionDetails.QesAnswer1 = prmQesAnswer1.Value.ToString();
            questionDetails.QesAnswer2 = prmQesAnswer2.Value.ToString();
            questionDetails.QesAnswer3 = prmQesAnswer3.Value.ToString();
            questionDetails.QesAnswer4 = prmQesAnswer4.Value.ToString();
            questionDetails.QesKey = prmQesKey.Value.ToString();
            return questionDetails;
        }
        //将题库的一道多选题加入到试卷中
        public string AddMultiSelectQuestionTopaper(Int32 PapID, Int32 QesID, Int32 Mark)
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_paper_multiselectquestion_isp", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);

            SqlParameter prmMark = new SqlParameter("@Mark", SqlDbType.BigInt);
            prmMark.Value = Mark;
            myCommand.Parameters.Add(prmMark);
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

        //从试卷中删除一道多选试题
        public string DelMultiSelectQesFromPaper(Int32 PapID, Int32 QesID
        )
        {
            //定义Connection 和Command实例
            //SqlConnection myConnecttion = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["testConnectionString"].ToString());
            SqlConnection myConnecttion = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            SqlCommand myCommand = new SqlCommand("sp_pap_multiselectqes_dap", myConnecttion);
            //将command对象的类型指定为一个sql存储过程
            myCommand.CommandType = CommandType.StoredProcedure;
            //为存储过程设置参数
            SqlParameter prmQesID = new SqlParameter("@QesID", SqlDbType.BigInt);
            prmQesID.Value = QesID;
            myCommand.Parameters.Add(prmQesID);

            SqlParameter prmPapID = new SqlParameter("@PapID", SqlDbType.BigInt);
            prmPapID.Value = PapID;
            myCommand.Parameters.Add(prmPapID);
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
    }
}
        
    
