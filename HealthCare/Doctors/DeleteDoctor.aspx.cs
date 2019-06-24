using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare.Doctors
{
    public partial class DeleteDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["loggedUser"] != null)
                    {
                        int doctorid = Convert.ToInt32(Request.QueryString["id"]);
                        int deleted = new BusinessClass().DeleteDoctor(doctorid);
                        if (deleted == -1)
                        {
                            Response.Redirect("ViewDoctors.aspx?errorMessage=Some error occured. Please try again.", false);
                        }
                        else
                        {
                            Response.Redirect("ViewDoctors.aspx?successMessage=Record Deleted.", false);
                        }
                    }
                    else
                    {
                        Response.Redirect("Login.aspx?errorMessage=You have to login first.", false);
                    }
                }
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx");
            }
        }
    }
}