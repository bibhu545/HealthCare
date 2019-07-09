using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataModels;
using LogAndErrors;

namespace HealthCare.Vault
{
    public partial class AddNewDocumentsV2 : System.Web.UI.Page
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

                        ddlHospitals.DataSource = new BusinessClass().GetHospitals(user.UserId);
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
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }
    }
}