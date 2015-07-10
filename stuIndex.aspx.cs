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
public partial class stuIndex : System.Web.UI.Page
{
    private StudentExam stuInfo = new StudentExam();
    private RadioButton[] buttonarray = new RadioButton[4];
    protected void Page_Load(object sender, EventArgs e)
    {
        timebox.Text = Request.Cookies["time"].Value;
        Label9.Text = "你好," + Request.Cookies["UserID"].Value + "号" + Request.Cookies["UserName"].Value + "同学，现在开始做题，";
        for (int i = 1; i <= 4; i++)
            buttonarray[i - 1] = DetailsView1.FindControl("RadioButton" + i.ToString()) as RadioButton;
        int len = DetailsView1.PageCount;
        int[] str = new int[len];
        for (int i = 0; i < len; i++)
            str[i] = i + 1;
        CheckBoxList1.DataSource = str;
        CheckBoxList1.DataBind();
    }
    protected void DetailsView1_PageIndexChanged(object sender, EventArgs e)
    {
        int questionIndex = DetailsView1.PageIndex + 1;
        RadioButtonList2.SelectedIndex = DetailsView1.PageIndex;
        Label7.Text = "题目" + questionIndex.ToString() + "：";
        string key = Session["answer" + DetailsView1.PageIndex.ToString()].ToString();
        if (key.Equals("A") || key.Equals("B") || key.Equals("C") || key.Equals("D"))
        {
            Label1.Text = "该题你已做过，你的选择是：";
            Label10.Text = key;
           (DetailsView1.FindControl("RadioButton1") as RadioButton).Checked = true;
        }
        else
        {
            Label1.Text = "";
            Label10.Text = "";
            buttoninit();
        }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DetailsView1.PageIndex = RadioButtonList2.SelectedIndex;
        int questionIndex = DetailsView1.PageIndex+1;
        Label7.Text = "题目" + questionIndex.ToString() + ":";
        string key = Session["answer" + DetailsView1.PageIndex.ToString()].ToString();
        if (key.Equals("A") || key.Equals("B") || key.Equals("C") || key.Equals("D"))
        {
            Label1.Text = "该题你已做过，你的选择是："; 
            Label10.Text = key;
        }
        else
        {
            Label1.Text = "";
            Label10.Text = "";
            buttoninit();
        }
    }
    protected void RadioButtonList2_DataBound(object sender, EventArgs e)
    {
        int lenth = RadioButtonList2.Items.Count;
        for (int i = 0; i < lenth; i++)
        {
            string temp = RadioButtonList2.Items[i].Text;
            int len = temp.Length;
            if (len > 8)
                RadioButtonList2.Items[i].Text = temp.Substring(0, 5) + "……";
            else
                RadioButtonList2.Items[i].Text = temp.Substring(0, len);
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (DetailsView1.PageIndex < DetailsView1.PageCount-1)
        {
            DetailsView1.PageIndex++;
        }
        else
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('已经是最后一题！');", true);
        RadioButtonList2.SelectedIndex = DetailsView1.PageIndex;
        string key = Session["answer" + DetailsView1.PageIndex.ToString()].ToString();
        if (key.Equals("A") || key.Equals("B") || key.Equals("C") || key.Equals("D"))
        {
            Label1.Text = "该题你已做过，你的选择是：";
            Label10.Text = key;
        }
        else
        {
            Label1.Text = "";
            Label10.Text = "";
            buttoninit();
        }
        int questionIndex = DetailsView1.PageIndex + 1;
        Label7.Text = "题目" + questionIndex.ToString() + "：";
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (DetailsView1.PageIndex > 0)
        {
            DetailsView1.PageIndex--;
        }
        else
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "alert('已经是第一题！');", true);
        RadioButtonList2.SelectedIndex = DetailsView1.PageIndex;
        string key = Session["answer" + DetailsView1.PageIndex.ToString()].ToString();
        if (key.Equals("A") || key.Equals("B") || key.Equals("C") || key.Equals("D"))
        {
            Label1.Text = "该题你已做过，你的选择是：";
            Label10.Text = key;
        }
        else
        {
            Label1.Text = "";
            buttoninit();
        }
        int questionIndex = DetailsView1.PageIndex + 1;
        Label7.Text = "题目" + questionIndex.ToString() + "：";
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string finalkey = this.Label18.Text;
        stuInfo.alertData(finalkey, Request.Cookies["UserID"].Value);
        stuInfo.finshed(Request.Cookies["UserID"].Value);
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "updateScript", "var flag= window.confirm('确认交卷？点击确认后就不能继续答题，请慎重选择！');if(flag)location.href = 'sendBlank.aspx';", true);
    }
    protected void btnWord_Click(object sender, EventArgs e)
    {
        ToWord(this.Label18);
    }
    public void ToWord(System.Web.UI.Control ctl)
  {
      HttpContext.Current.Response.Clear();
      HttpContext.Current.Response.Charset = "";
      HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=DocLibrary.doc");
      HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
      //更改ContentType的值为ms-word即可实现导出到Word   
      HttpContext.Current.Response.ContentType = "application/ms-word";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword
      ctl.Page.EnableViewState = false;
      System.IO.StringWriter tw = new System.IO.StringWriter();
      System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
      ctl.RenderControl(hw);
      string html = checkStr(tw.ToString());//过滤字符串
      HttpContext.Current.Response.Write(html);
      //HttpContext.Current.Response.Write(tw);
      HttpContext.Current.Response.End();
  }
public string checkStr(string html)
  {

      System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" no[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      html = regex1.Replace(html, ""); //过滤<script></script>标记

      html = regex2.Replace(html, ""); //过滤href=Javascript: (<A>) 属性

      html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件

      html = regex4.Replace(html, ""); //过滤iframe

      html = regex5.Replace(html, ""); //过滤frameset

      html = regex6.Replace(html, ""); //过滤frameset

      html = regex7.Replace(html, ""); //过滤frameset

      html = regex8.Replace(html, ""); //过滤frameset

      html = regex9.Replace(html, "");

      html = html.Replace(" ", "");

      html = html.Replace("</strong>", "");

      html = html.Replace("<strong>", "");

      return html;

  }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        buttonchecked(0);
        sendinfo("A");
    }
    
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        buttonchecked(1);
        sendinfo("B");
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        buttonchecked(2);
        sendinfo("C");
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        buttonchecked(3);
        sendinfo("D");
    }

    public void sendinfo(string useranswer)
   {
       Session["answer" + DetailsView1.PageIndex.ToString()] = useranswer;
        answercolor(useranswer);
        string sendInfo = "";
        string key1 = Session["answer" + DetailsView1.PageIndex.ToString()].ToString();
        if (key1.Equals("A") || key1.Equals("B") || key1.Equals("C") || key1.Equals("D"))
        {
            Label1.Text = "该题你已做过，你的选择是：";
           Label10.Text = key1;
           CheckBoxList1.Items[DetailsView1.PageIndex].Selected = true;
        }
        for (int i = 0; i < 50; i++)
        {
            string key2 = Session["answer" + i.ToString()].ToString();
            if (key2.Equals("A") || key2.Equals("B") || key2.Equals("C") || key2.Equals("D"))
                sendInfo += key2;
            else
                sendInfo += "*";
        }
        Label18.Text = sendInfo;
       //stuInfo.alertData(sendInfo, Request.Cookies["UserID"].Value);
       if (CheckBox1.Checked)
       {
           Label1.Text = "";
           Label10.Text = "";
           if (DetailsView1.PageIndex < DetailsView1.PageCount-1)
               DetailsView1.PageIndex++;
           buttoninit();
           RadioButtonList2.SelectedIndex = DetailsView1.PageIndex;
           string key = Session["answer" + DetailsView1.PageIndex.ToString()].ToString();
           if (key.Equals("A") || key.Equals("B") || key.Equals("C") || key.Equals("D"))
           {
               Label1.Text = "该题你已做过，你的选择是：";
               Label10.Text = key;
               CheckBoxList1.Items[DetailsView1.PageIndex].Selected = true;
           }
           int questionIndex = DetailsView1.PageIndex + 1;
           Label7.Text = "题目" + questionIndex.ToString() + "：";
       }
   }
    private void buttoninit()
    {
        for (int i = 0; i < 4; i++)
        {
            buttonarray[i].Checked = false;
        }
    }

    private void buttonchecked(int index)
    {
        for (int i = 0; i < 4; i++)
        {
            buttonarray[i].Checked = false;
        }
        buttonarray[index].Checked = true;
    }

    private void answercolor(string answer)
    {
        int index=3;
        if (answer.Equals("A"))
            index = 3;
        if (answer.Equals("B"))
            index = 4;
        if (answer.Equals("C"))
            index = 5;
        if (answer.Equals("D"))
            index = 6;
        for (int i = 3; i < 7; i++)
        {
            (DetailsView1.FindControl("Label" + i.ToString()) as Label).ForeColor = System.Drawing.Color.Black;
        }
        (DetailsView1.FindControl("Label" + index.ToString()) as Label).ForeColor = System.Drawing.Color.Red;
    }
    protected void CheckBoxList1_DataBound(object sender, EventArgs e)
    {
        string str = Session["unfinishedanswer"].ToString();
         if (str.Length == 50)
         {
             string temp = "";
             int len = CheckBoxList1.Items.Count;
             int count = 0;
             for (int i = 0; i < len; i++)
             {
                 temp = str.Substring(i, 1);
                 if (!temp.Equals("*"))
                 {
                     Session["answer" + i.ToString()] = temp;
                     CheckBoxList1.Items[i].Selected = true;
                     count++;
                 }
             }
             Label1.Text = "你已做了" + count + "道题，请注意查看！";
             Session["unfinishedanswer"] ="";
             
         }
         for (int i = 0; i < 50; i++)
         {
             string key = Session["answer" + i.ToString()].ToString();
             if (key.Equals("A") || key.Equals("B") || key.Equals("C") || key.Equals("D"))
                 CheckBoxList1.Items[i].Selected = true;
         }
    }
    private void setTime()
    {
        if (!Request.Cookies["Cookie1"].Value.Equals(""))
        {
            string str = Request.Cookies["Cookie1"].Value;
            string str_time = str.Substring(0, 2);
            int time = int.Parse(str_time);//方式是将数字内容的字符串转为int类型
            stuInfo.setTime(time, Request.Cookies["UserID"].Value);
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        setTime();
    }
}