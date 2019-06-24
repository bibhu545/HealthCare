using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();

                user.FirstName = txtFirstName.Text.Trim();
                user.LastName = txtLastName.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.Password = txtPassword.Text.Trim();

                ConfirmRegistration cr = new BusinessClass().CreateUser(user);
                Session["otp"] = cr.Otp;
                Session["inactiveUser"] = user;
                if (cr.Added != -1)
                {
                    Response.Redirect("Profile/ConfirmRegistration.aspx");
                }
                else
                {
                    Response.Redirect("ConfirmRegistration.aspx?errorMessage=Some Error occured. Please try again.");
                }

            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }
    }
}