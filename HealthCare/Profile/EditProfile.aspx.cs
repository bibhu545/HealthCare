﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DataModels;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare.Profile
{
    public partial class EditProfile : System.Web.UI.Page
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
                        txtFirstName.Text = user.FirstName;
                        txtLastName.Text = user.LastName;
                        txtEmail.Text = user.Email;
                        txtPhone.Text = user.Phone;
                        txtAddress.Text = user.Address;
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

        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            try
            {
                user = (User)Session["loggedUser"];

                String fileName = fileProfilePicture.PostedFile.FileName;
                String extension = Path.GetExtension(fileName);
                String rootPath = Server.MapPath("~");
                String path = rootPath + @"/files/profiles/";
                String completePath = path + "profile_" + user.UserId + extension;
                String databasePath = @"/files/profiles/profile_" + user.UserId + extension;
                fileProfilePicture.SaveAs(completePath);

                user.FirstName = txtFirstName.Text.Trim();
                user.LastName = txtLastName.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                user.Phone = txtPhone.Text.Trim();
                user.Address = txtAddress.Text.Trim();
                if (fileName.Equals(""))
                {
                    user.Profile = "/files/profiles/default-profile.png";
                }
                else
                {
                    user.Profile = databasePath;
                }

                user = new BusinessClass().EditUserDetails(user);
                if (user.status == 1)
                {
                    Session["loggedUser"] = user;
                    Response.Redirect("ViewProfile.aspx?successMessage=Profile details updated.", false);
                }
                else
                {
                    Response.Redirect("EditProfile.aspx?errorMessage=Some error occured. Please try again.", false);
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