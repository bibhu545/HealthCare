using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataModels;
using BusinessLayer;

namespace HealthCare.Doctors
{
    public partial class DoctorDetails : System.Web.UI.Page
    {
        public User user = null;
        public DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loggedUser"] != null)
                {
                    user = (User)Session["loggedUser"];
                    if (Request.QueryString["id"] == null)
                    {
                        Response.Redirect("ViewDoctors.aspx?errorMessage=Please select a Hospital to edit.");
                    }
                    else
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        dt = new BusinessClass().GetDoctors(id);
                        if (dt.Rows.Count <= 0)
                        {
                            Response.Redirect("ViewDoctors.aspx?errorMessage=Please select a valid Hospital to edit.");
                        }
                    }
                }
                else if (Session["inactiveUser"] != null)
                {
                    user = (User)Session["inactiveUser"];
                    Response.Redirect("ConfirmRegistration.aspx?errorMessage=Your account is not activated yet.");
                }
                else
                {
                    Response.Redirect("../Login.aspx?errorMessage=You have to login first.");
                }
            }
        }
    }
}