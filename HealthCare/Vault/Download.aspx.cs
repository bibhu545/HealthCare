using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using LogAndErrors;

namespace HealthCare.Vault
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String filePath = Request.QueryString["fileName"];
            FileInfo file = new FileInfo(Server.MapPath("~") + filePath);
            if (file.Exists)
            {
                Response.Clear();
                String fName = filePath.Substring(filePath.LastIndexOf("/"), filePath.Length - filePath.LastIndexOf("/")).Substring(1);
                String extension = fName.Substring(fName.LastIndexOf(".")).Substring(1);
                if (extension.Equals("doc") || extension.Equals("docx"))
                {
                    Response.ContentType = "Application/msword";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=record.doc");
                }
                else if (extension.Equals("jpg") || extension.Equals("jpeg") || extension.Equals("jpg"))
                {
                    Response.ContentType = "image/jpg";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=record.png");
                }
                else
                {
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=record.pdf");
                }

                Response.TransmitFile(Server.MapPath("~") + filePath);
                Response.End();
            }
        }
    }
}
