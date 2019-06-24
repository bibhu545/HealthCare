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
    public partial class ViewDoctors : System.Web.UI.Page
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
                        ViewState["SortDirection"] = "ASC";
                        BindDataGrid();
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
        public String ViewPrimaryDoctor(String isPrimary, String name)
        {
            try
            {
                int primary = Convert.ToInt32(isPrimary);
                if (primary == 1)
                {
                    return name + "<br /> (Primary)";
                }
                else
                {
                    return name;
                }
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
            return null;
        }
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvDoctors.PageIndex = e.NewPageIndex;
                this.BindDataGrid();
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }

        protected void OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                this.BindDataGrid(e.SortExpression);
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }
        private void BindDataGrid(String sortExpression = null)
        {
            try
            {
                BusinessClass businessClass = new BusinessClass();
                DataTable dt = businessClass.GetDoctors(0);
                if (sortExpression != null)
                {
                    if (ViewState["SortDirection"].ToString() == "ASC")
                    {
                        ViewState["SortDirection"] = "DESC";
                    }
                    else
                    {
                        ViewState["SortDirection"] = "ASC";
                    }
                    DataView dvData = new DataView(dt);
                    dvData.Sort = sortExpression + " " + ViewState["SortDirection"];
                    gvDoctors.DataSource = dvData;
                }
                else
                {
                    gvDoctors.DataSource = dt;
                }
                gvDoctors.DataBind();
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
                Response.Redirect("/ErrorPage.aspx", false);
            }
        }
    }
}