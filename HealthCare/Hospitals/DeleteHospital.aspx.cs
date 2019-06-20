using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace HealthCare.Hospitals
{
    public partial class DeleteHospital : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int hospitalid = Convert.ToInt32(Request.QueryString["id"]);
                int deleted = new BusinessClass().DeleteHospital(hospitalid);
                if(deleted == -1)
                {
                    Response.Redirect("ViewHospitals.aspx?errorMessage=Some error occured. Please try again.");
                }
                else
                {
                    Response.Redirect("ViewHospitals.aspx?successMessage=Record Deleted.");
                }
            }
        }
    }
}