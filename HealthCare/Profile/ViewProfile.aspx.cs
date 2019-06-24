using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using LogAndErrors;

namespace HealthCare.Profile
{
    public partial class ViewProfile : System.Web.UI.Page
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
    }
}