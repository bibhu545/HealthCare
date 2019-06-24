using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataModels;
using LogAndErrors;

namespace HealthCare.Profile
{
    public partial class ConfirmRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["loggedUser"] == null && Session["inactiveUser"] == null)
                {
                    Response.Redirect("../Register.aspx?errorMessage=Please register to continue.", false);
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
                String otp = txtOtp.Text.Trim();
                if (Session["otp"] != null)
                {
                    if (otp.Equals(Session["otp"].ToString()))
                    {
                        int activated = new BusinessClass().ActivateUser((User)Session["inactiveUser"]);
                        if (activated != -1)
                        {
                            Response.Redirect("../Login.aspx?successMessage=Account Activated. Please login to continue.", false);
                        }
                        else
                        {
                            Response.Redirect("ConfirmRegistration.aspx?errorMessage=Some error occured. Please try again.", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("ConfirmRegistration.aspx?errorMessage=Invalid OTP. Please try again.", false);
                    }
                }
                else
                {
                    Response.Redirect("../Register.aspx?errorMessage=Seesion expired. Please try again.", false);
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