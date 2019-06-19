using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataModels;

namespace HealthCare.Profile
{
    public partial class ConfirmRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["loggedUser"] == null && Session["inactiveUser"] == null)
            {
                Response.Redirect("../Register.aspx?errorMessage=Please register to continue.");
            }
        }

        protected void btnAddHospital_Click(object sender, EventArgs e)
        {
            String otp = txtOtp.Text.Trim();
            if (Session["otp"] != null)
            {
                if (otp.Equals(Session["otp"].ToString()))
                {
                    int activated = new BusinessClass().ActivateUser((User) Session["inactiveUser"]);
                    if (activated != -1)
                    {
                        Response.Redirect("../Login.aspx?successMessage=Account Activated. Please login to continue.");
                    }
                    else
                    {
                        Response.Redirect("ConfirmRegistration.aspx?errorMessage=Some error occured. Please try again.");
                    }
                }
                else
                {
                    Response.Redirect("ConfirmRegistration.aspx?errorMessage=Invalid OTP. Please try again.");
                }
            }
            else
            {
                Response.Redirect("../Register.aspx?errorMessage=Seesion expired. Please try again.");
            }
        }
    }
}