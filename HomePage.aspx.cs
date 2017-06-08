using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;

namespace 百度网盘soso
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //   if(!string.IsNullOrEmpty(Request.Form["IsPostBack"]))
               
                if (!string.IsNullOrEmpty(Request.Form["SearchContent"]))
             {
                string SC = Convert.ToString(Request.Form["SearchContent"]);


                string s_url;
                s_url = "SearchResult.aspx?SC=" + SC;
                Response.Redirect(s_url);



            }
        }
    }
}