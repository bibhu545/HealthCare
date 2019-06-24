using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare.Hospitals
{
    public partial class DeleteHospital : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int hospitalid = Convert.ToInt32(Request.QueryString["id"]);
                    int deleted = new BusinessClass().DeleteHospital(hospitalid);
                    if (deleted == -1)
                    {
                        Response.Redirect("ViewHospitals.aspx?errorMessage=Some error occured. Please try again.", false);
                    }
                    else
                    {
                        Response.Redirect("ViewHospitals.aspx?successMessage=Record Deleted.", false);
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