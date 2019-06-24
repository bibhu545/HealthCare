using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataModels;
using LogAndErrors;

namespace HealthCare
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new BusinessClass().Login(txtEmail.Text.Trim(), txtPassword.Text.Trim());
                if (user.status == 1)
                {
                    Session["loggedUser"] = user;
                    Response.Redirect("Profile/UserHome.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx?errorMessage=Some Error occured. Please try again.");
                }
            }
            catch(Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }
    }
}