using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataModels;
using BusinessLayer;
using LogAndErrors;


namespace HealthCare.Doctors
{
    public partial class AddDoctor : System.Web.UI.Page
    {
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["loggedUser"] != null)
                    {
                        user = (User)Session["loggedUser"];

                        ddlHospitals.DataSource = new BusinessClass().GetHospitals(user.UserId);
                        ddlHospitals.DataTextField = "hospitalname";
                        ddlHospitals.DataValueField = "hospitalid";
                        ddlHospitals.DataBind();

                        ddlSpecialities.DataSource = new BusinessClass().GetSpecialities();
                        ddlSpecialities.DataTextField = "speciality";
                        ddlSpecialities.DataValueField = "specialityid";
                        ddlSpecialities.DataBind();
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

        protected void btnAddDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                Doctor doctor = new Doctor();
                doctor.UserId = Convert.ToInt32(((User)Session["loggedUser"]).UserId);
                doctor.HospitalId = Convert.ToInt32(ddlHospitals.SelectedItem.Value.ToString());
                doctor.FirstName = txtFirstName.Text.Trim();
                doctor.LastName = txtLastName.Text.Trim();
                doctor.Speciality = Convert.ToInt32(ddlSpecialities.SelectedItem.Value);
                doctor.Address = txtAddress.Text.Trim();
                doctor.Phone1 = txtContact.Text.Trim();
                doctor.Phone2 = txtAlternativeContact.Text.Trim();
                doctor.Email = txtEmail.Text.Trim();
                if (chkSetPrimary.Checked)
                {
                    doctor.IsPrimary = 1;
                }
                else
                {
                    doctor.IsPrimary = 0;
                }

                doctor = new BusinessClass().AddDoctor(doctor);
                if (doctor.status == -1)
                {
                    Response.Redirect("AddDoctor.aspx?errorMessage=Some error occured. Please try again.", false);
                }
                else
                {
                    Response.Redirect("ViewDoctors.aspx?successMessage=New doctor added.", false);
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