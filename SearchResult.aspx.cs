using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 百度网盘soso
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<a href='   HomePage.aspx  '> 返回首页 </a> <br/>");
            string sosoContent = Request.QueryString["SC"];

            // Response.Write("this is the string that database wirite out" + sosoContent);         
          //  string sosoContent = "photoshop";

                string MyConString = "DRIVER={MySQL ODBC 5.3 ANSI Driver};" +
                                     "SERVER=localhost;" +
                                     "DATABASE=pan_soso;" +
                                     "UID=root;" +
                                      "PASSWORD=cjy373;" +
                                     "OPTION=3";

                OdbcConnection MyConnection = new OdbcConnection(MyConString);
                MyConnection.Open();

                 Response.Write("success, connected successfully !<br/>");


            // string query = "select * from share_file where title like '%" + sosoContent + "%' ";
               string query = "Select * from share_file where title  like '%" + sosoContent + "%'";
            OdbcCommand cmd = new OdbcCommand(query, MyConnection);
                //处理异常：插入重复记录有异常
                try
                {
                //Response.Write("try<br/>");
                cmd.ExecuteNonQuery();
                string Result_title = null;
                string Result_Size = null;
                string Result_ext = null;

                string Result_shareid = null;
                string Result_uk = null;


                OdbcDataReader reader;
                    reader = cmd.ExecuteReader();
  
              // Response.Write("before if<br/>");
                while (reader.Read())
                {
                    
                    Result_title = reader[1].ToString();
                    Result_Size = reader[5].ToString();
                    Result_ext = reader[10].ToString();
                    if (Result_ext == "0")
                        continue;

                      Result_shareid = reader[7].ToString();
                   Result_uk = reader[2].ToString();
                    // Response.Write("http://yun.baidu.com/share/link?shareid=" + Result_shareid + "&uk=" + Result_uk + "&errno=0&errmsg=Auth%20Login%20Sucess&&bduss=&ssnerror=0#list/path=%2F<br/>");
                    //string url1 = "http://yun.baidu.com/share/link?shareid=" + Result_shareid + "&uk=" + Result_uk + "&errno=0&errmsg=Auth%20Login%20Sucess&&bduss=&ssnerror=0#list/path=%2F<br/>";
                    string url1 = "http://yun.baidu.com/share/link?shareid=" + Result_shareid + "&uk=" + Result_uk +"?noreferer\"" ;
                    //string url2= ' rel = "noreferrer" target = "_blank"';
                    string url2 = "rel = \"noreferrer\" target = \"_blank\"";

                    //   < a href = "http://blog.geekli.cn/test/index.php?noreferer" rel = "noreferrer" target = "_blank" > noreferrer </ a >
                    Response.Write("资源名：<a href=\"   "+url1+"   "+url2+"     \">" + Result_title+"</a> <br/>");
                 //   Response.Write("资源名：<a href='    " + url1 + "  '>" + Result_title + "</a> <br/>");
                    Response.Write(Result_Size + "<br>");
                    Response.Write(Result_ext + "<br>");

                }
                //if (reader.Read())
                //{
                //    Result_title = reader[1].ToString();
                //    Result_Size = reader[5].ToString();
                //    Result_ext= reader[10].ToString();

                //    Response.Write("read<br/>");
                //    Response.Write("<br/>01" + Result_title);
                //    Response.Write("<br/>02" + Result_Size);
                //    Response.Write("<br/>03" + Result_ext);
                //}
                //else
                //{
                //    Response.Write("no data<br/>");
                //}


            }
                catch (Exception ex)
                {
                    Console.WriteLine("record duplicate.");
                }
                finally
                {
                    cmd.Dispose();
                }
            

           
        }
    }
}