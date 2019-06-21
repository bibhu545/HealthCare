﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using DataModels;

namespace HealthCare.Hospitals
{
    public partial class HospitalDetails : System.Web.UI.Page
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
                    if(Request.QueryString["id"] == null)
                    {
                        Response.Redirect("ViewHospitals.aspx?errorMessage=Please select a Hospital to edit.");
                    }
                    else
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        hospital = new BusinessClass().GetHospitalDetails(id);
                        if(hospital.status == -1)
                        {
                            Response.Redirect("ViewHospitals.aspx?errorMessage=Please select a valid Hospital to edit.");
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