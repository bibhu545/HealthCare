using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DataModels;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare.Vault
{
    public partial class InsertFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Document document = new Document();
                document.UserId = ((User)Session["loggedUser"]).UserId;
                document.HospitalId = Convert.ToInt32(Request.QueryString["hospital"].Trim());
                document.DoctorId = Convert.ToInt32(Request.QueryString["doctor"].Trim());
                document.DocumentType = Convert.ToInt32(Request.QueryString["recordType"].Trim());
                document.IssueDate = Request.QueryString["issueDate"].Trim();

                String path = Server.MapPath(@"~/files/uploads/");
                String folder = path + document.UserId.ToString() + @"\";
                List<String> ext = new List<string>() { ".png", ".jpg", ".doc", ".docx", ".pdf" };
                List<String> allFiles = new List<string>();
                String[] filenames = Request.QueryString["issueDate"].Trim().Split(';');
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                Boolean fileStatus = true;
                foreach (String filename in filenames)
                {
                    String extension = Path.GetExtension(filename);
                    if (ext.IndexOf(extension) < 0)
                    {
                        fileStatus = false;
                    }
                    else
                    {
                        //new File("").SaveAs(folder + file.FileName);
                        allFiles.Add(@"/files/uploads/" + document.UserId + @"/" + filename);
                    }
                }

                if (!fileStatus)
                {
                    Response.Redirect("AddNewDocument.aspx?errorMessage=Please choose any '.doc', '.docx', '.pdf', '.jpg', '.png' only.", false);
                }

                document = new BusinessClass().SaveDocument(document, allFiles);
                if (document.status != -1)
                {
                    Response.Redirect("ViewDocuments.aspx?successMessage=New documents uploaded.", false);
                }
                else
                {
                    Response.Redirect("AddNewDocument.aspx?errorMessage=Some error occured. Please try again.", false);
                }
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }
    }
}