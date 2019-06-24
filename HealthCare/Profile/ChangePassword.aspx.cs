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
    public partial class ChangePassword : System.Web.UI.Page
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

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                user = (User)Session["loggedUser"];
                if (user.Password.Equals(txtCurrentPassword.Text.Trim()))
                {
                    if (txtNewPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
                    {
                        user.Password = txtNewPassword.Text.Trim();
                        user = new BusinessClass().updatePassword(user);
                        if (user.status == 1)
                        {
                            Session["loggedUser"] = user;
                            Response.Redirect("ViewProfile.aspx?successMessage=Password updated.", false);
                        }
                        else
                        {
                            Response.Redirect("ChangePassword.aspx?errorMessage=Some error occured. Please try again.", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("ChangePassword.aspx?errorMessage=Passwords do not match.", false);
                    }
                }
                else
                {
                    Response.Redirect("ChangePassword.aspx?errorMessage=Current Password is not correct.", false);
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