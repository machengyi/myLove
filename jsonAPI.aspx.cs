using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class jsonAPI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "text/plain";
        HttpContext.Current.Response.Write(getJsonData());
        HttpContext.Current.Response.End();
    }

    //如果文件不存在，则创建；存在则覆盖
    protected string getJsonData()
    {
        string strJson = "";
        string addJson = "{\"datetime\":\"" + Request.QueryString["date"].ToString().Trim() + "\",\"content\":\"" + Request.QueryString["content"].ToString().Trim() + "\"},";
        strJson = System.IO.File.ReadAllText(Server.MapPath(@"~\data\manData.txt") ).Replace("[", "").Replace("]", "");
        strJson = addJson + strJson;
        strJson = "[" + strJson + "]";
        try
        {
            System.IO.File.WriteAllText(Server.MapPath(@"~\data\manData.txt"), strJson, System.Text.Encoding.UTF8);
            return "true";
        }
        catch (Exception)
        {
            return "false";
        }
    }
}