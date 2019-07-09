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
    public partial class EditDoctor : System.Web.UI.Page
    {
        public User user = null;
        public Doctor doctor = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["loggedUser"] != null)
                    {
                        user = (User)Session["loggedUser"];
                        if (Request.QueryString["id"] == null)
                        {
                            Response.Redirect("ViewDoctors.aspx?errorMessage=Please select a Hospital to edit.", false);
                        }
                        else
                        {
                            int id = Convert.ToInt32(Request.QueryString["id"]);
                            DataTable dt = new BusinessClass().GetDoctorDetails(id);
                            if (dt.Rows.Count <= 0)
                            {
                                Response.Redirect("ViewDoctors.aspx?errorMessage=Please select a valid Hospital to edit.", false);
                            }
                            else
                            {
                                doctor = new Doctor();
                                doctor.DoctorId = Convert.ToInt32(dt.Rows[0]["doctorid"]);
                                doctor.FirstName = dt.Rows[0]["firstname"].ToString();
                                doctor.LastName = dt.Rows[0]["lastname"].ToString();
                                doctor.HospitalId = Convert.ToInt32(dt.Rows[0]["hospitalid"]);
                                doctor.Speciality = Convert.ToInt32(dt.Rows[0]["speciality"]);
                                doctor.Address = dt.Rows[0]["address"].ToString();
                                doctor.Phone1 = dt.Rows[0]["phone1"].ToString();
                                doctor.Phone2 = dt.Rows[0]["phone2"].ToString();
                                doctor.Email = dt.Rows[0]["email"].ToString();
                                doctor.IsPrimary = Convert.ToInt32(dt.Rows[0]["isprimary"]);
                                Session["doctorid"] = doctor.DoctorId;

                                ddlHospitals.DataSource = new BusinessClass().GetHospitals(user.UserId);
                                ddlHospitals.DataTextField = "hospitalname";
                                ddlHospitals.DataValueField = "hospitalid";
                                ddlHospitals.DataBind();

                                ddlSpecialities.DataSource = new BusinessClass().GetSpecialities();
                                ddlSpecialities.DataTextField = "speciality";
                                ddlSpecialities.DataValueField = "specialityid";
                                ddlSpecialities.DataBind();

                                txtFirstName.Text = doctor.FirstName;
                                txtLastName.Text = doctor.LastName;
                                ddlHospitals.Items.FindByValue(doctor.HospitalId.ToString()).Selected = true;
                                ddlSpecialities.Items.FindByValue(doctor.Speciality.ToString()).Selected = true;
                                txtAddress.Text = doctor.Address;
                                txtContact.Text = doctor.Phone1;
                                txtAlternativeContact.Text = doctor.Phone2;
                                txtEmail.Text = doctor.Email;
                                if (doctor.IsPrimary == 1)
                                {
                                    chkSetPrimary.Checked = true;
                                }
                            }
                        }
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

        protected void btnEditDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                doctor = new Doctor();
                doctor.DoctorId = Convert.ToInt32(Session["doctorid"].ToString());
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

                doctor = new BusinessClass().EditDoctor(doctor);
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