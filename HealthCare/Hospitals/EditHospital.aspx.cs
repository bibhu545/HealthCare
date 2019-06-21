using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using BusinessLayer;

namespace HealthCare.Hospitals
{
    public partial class EditHospital : System.Web.UI.Page
    {
        public User user = null;
        public Hospital hospital = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["loggedUser"] != null)
                {
                    user = (User)Session["loggedUser"];
                    if (Request.QueryString["id"] == null)
                    {
                        Response.Redirect("ViewHospitals.aspx?errorMessage=Please select a Hospital to edit.");
                    }
                    else
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        hospital = new BusinessClass().GetHospitalDetails(id);
                        if (hospital.status == -1)
                        {
                            Response.Redirect("ViewHospitals.aspx?errorMessage=Please select a valid Hospital to edit.");
                        }
                        else
                        {
                            txtHospitalName.Text = hospital.HospitalName;
                            txtAddress.Text = hospital.Address;
                            txtContactNumber.Text = hospital.Phone1;
                            txtAlternativeNumber.Text = hospital.Phone2;
                            txtEmail.Text = hospital.Email;
                            Session["hospitalid"] = hospital.HospitalId;
                            if(hospital.IsPrimary == 1)
                            {
                                chkSetPrimary.Checked = true;
                            }
                            else
                            {
                                chkSetPrimary.Checked = false;
                            }
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

        protected void btnEditHospital_Click(object sender, EventArgs e)
        {
            hospital = new Hospital();
            hospital.HospitalId = Convert.ToInt32(Session["hospitalid"]);
            hospital.UserId = Convert.ToInt32(((User)Session["loggedUser"]).UserId);
            hospital.HospitalName = txtHospitalName.Text;
            hospital.Address = txtAddress.Text;
            hospital.Phone1 = txtContactNumber.Text;
            hospital.Phone2 = txtAlternativeNumber.Text;
            hospital.Email = txtEmail.Text;
            if(chkSetPrimary.Checked)
            {
                hospital.IsPrimary = 1;
            }
            else
            {
                hospital.IsPrimary = 0;
            }
            hospital = new BusinessClass().EditHospitalDetails(hospital);
            if(hospital.status == -1)
            {
                Response.Redirect("EditHospital.aspx?id=" + Session["hospitalid"] + "&errorMessage=Some Error occured. Please try again.");
            }
            else
            {
                Response.Redirect("HospitalDetails.aspx?id=" + Session["hospitalid"] + "&successMessage=Hospital details updated.");
            }
        }
    }
}