using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare.Hospitals
{
    public partial class AddHospital : System.Web.UI.Page
    {
        public static User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["loggedUser"] != null)
                    {
                        user = (User)Session["loggedUser"];
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

        protected void btnAddHospital_Click(object sender, EventArgs e)
        {
            try
            {
                Hospital hospital = new Hospital();
                hospital.UserId = user.UserId;
                hospital.HospitalName = txtHospitalName.Text.Trim();
                hospital.Address = txtAddress.Text.Trim();
                hospital.Phone1 = txtContact.Text.Trim();
                hospital.Phone2 = txtAlternativeContact.Text.Trim();
                hospital.Email = txtEmail.Text.Trim();
                if (chkSetPrimary.Checked)
                {
                    hospital.IsPrimary = 1;
                }
                else
                {
                    hospital.IsPrimary = 0;
                }

                int added = new BusinessClass().AddHospital(hospital);
                if (added != -1)
                {
                    Response.Redirect("ViewHospitals.aspx?successMessage=New Hospital added.", false);
                }
                else
                {
                    Response.Redirect("AddHospital.aspx?errorMessage=Some error occured. Please try again.", false);
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