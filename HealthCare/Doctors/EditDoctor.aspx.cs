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
    public partial class EditDoctor : System.Web.UI.Page
    {
        public User user = null;
        public Doctor doctor = null;
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
                        DataTable dt = new BusinessClass().GetDoctorDetails(id);
                        if (dt.Rows.Count <= 0)
                        {
                            Response.Redirect("ViewDoctors.aspx?errorMessage=Please select a valid Hospital to edit.");
                        }
                        else
                        {
                            doctor = new Doctor();
                            doctor.DoctorId = Convert.ToInt32(dt.Rows[0]["doctorid"]);
                            doctor.FirstName = dt.Rows[0]["firstname"].ToString();
                            doctor.LastName = dt.Rows[0]["lastname"].ToString();
                            doctor.Address = dt.Rows[0]["address"].ToString();
                            doctor.Phone1 = dt.Rows[0]["phone1"].ToString();
                            doctor.Phone2 = dt.Rows[0]["phone2"].ToString();
                            doctor.Email = dt.Rows[0]["email"].ToString();
                            doctor.IsPrimary = Convert.ToInt32(dt.Rows[0]["isprimary"]);

                            txtFirstName.Text = doctor.FirstName;
                            txtLastName.Text = doctor.LastName;
                            txtAddress.Text = doctor.Address;
                            txtContactNumber.Text = doctor.Phone1;
                            txtAlternativeNumber.Text = doctor.Phone2;
                            txtEmail.Text = doctor.Email;
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

        protected void btnEditDoctor_Click(object sender, EventArgs e)
        {

        }
    }
}