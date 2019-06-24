using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using BusinessLayer;
using System.IO;
using LogAndErrors;

namespace HealthCare.Vault
{
    public partial class AddNewDocument : System.Web.UI.Page
    {
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["loggedUser"] != null)
                    {
                        user = (User)Session["loggedUser"];

                        ddlHospitals.DataSource = new BusinessClass().GetHospitals();
                        ddlHospitals.DataTextField = "hospitalname";
                        ddlHospitals.DataValueField = "hospitalid";
                        ddlHospitals.DataBind();
                        ddlHospitals.Items.Insert(0, new ListItem("Select Hospital", "0"));
                        ddlDoctors.Items.Insert(0, new ListItem("Select Doctor", "0"));
                        ddlDoctors.Enabled = false;

                        ddlRecordTypes.DataSource = new BusinessClass().GetRecordTypes();
                        ddlRecordTypes.DataTextField = "recordtype";
                        ddlRecordTypes.DataValueField = "recordid";
                        ddlRecordTypes.DataBind();
                        ddlRecordTypes.Items.Insert(0, new ListItem("Select Document Type", "0"));

                    }
                    else if (Session["inactiveUser"] != null)
                    {
                        user = (User)Session["inactiveUser"];
                        Response.Redirect("ConfirmRegistration.aspx?errorMessage=Your account is not activated yet.", false);
                    }
                    else
                    {
                        Response.Redirect("../Login.aspx?errorMessage=You have to login first.", false);
                    }
                }
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }

        protected void hospitalSelected(Object sender, EventArgs e)
        {
            try
            {
                ddlDoctors.Enabled = false;
                ddlDoctors.Items.Clear();
                ddlDoctors.Items.Insert(0, new ListItem("Select Doctor", "0"));
                int hospitalId = Convert.ToInt32(ddlHospitals.SelectedItem.Value);
                if (hospitalId > 0)
                {
                    ddlDoctors.DataSource = new BusinessClass().GetDoctorsByHospital(hospitalId);
                    ddlDoctors.DataTextField = "firstname";
                    ddlDoctors.DataValueField = "doctorid";
                    ddlDoctors.DataBind();
                    ddlDoctors.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }

        protected void btnAddDocument_Click(object sender, EventArgs e)
        {
            try
            {
                Document document = new Document();
                document.UserId = ((User)Session["loggedUser"]).UserId;
                document.HospitalId = Convert.ToInt32(ddlHospitals.SelectedItem.Value);
                document.DoctorId = Convert.ToInt32(ddlDoctors.SelectedItem.Value);
                document.DocumentType = Convert.ToInt32(ddlRecordTypes.SelectedItem.Value);
                document.IssueDate = txtIssueDate.Text.Trim();

                String path = Server.MapPath(@"~/files/uploads/");
                String folder = path + document.UserId.ToString() + @"\";
                List<String> ext = new List<string>() { ".png", ".jpg", ".doc", ".docx", ".pdf" };
                List<String> allFiles = new List<string>();
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                Boolean fileStatus = true;
                foreach (HttpPostedFile file in fileDocuments.PostedFiles)
                {
                    String fileName = file.FileName;
                    String extension = Path.GetExtension(fileName);
                    if (ext.IndexOf(extension) < 0)
                    {
                        fileStatus = false;
                    }
                    else
                    {
                        file.SaveAs(folder + file.FileName);
                        allFiles.Add(@"/files/uploads/" + document.UserId + @"/" + file.FileName);
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
            catch(Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }
    }
}