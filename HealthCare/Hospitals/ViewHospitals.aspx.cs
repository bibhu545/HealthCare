using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;
using BusinessLayer;
using System.Data;

namespace HealthCare.Hospitals
{
    public partial class ViewHospitals : System.Web.UI.Page
    {
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
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
                    Response.Redirect("ConfirmRegistration.aspx?errorMessage=Your account is not activated yet.");
                }
                else
                {
                    Response.Redirect("../Login.aspx?errorMessage=You have to login first.");
                }
            }
        }
        public String ViewPrimaryHospital(String isPrimary, String name)
        {
            int primary = Convert.ToInt32(isPrimary);
            if(primary == 1)
            {
                return name + "<br /> (Primary)";
            }
            else
            {
                return name;
            }
        }
        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHospitals.PageIndex = e.NewPageIndex;
            this.BindDataGrid();
        }

        protected void OnSorting(object sender, GridViewSortEventArgs e)
        {
            this.BindDataGrid(e.SortExpression);
        }
        private void BindDataGrid(String sortExpression = null)
        {
            BusinessClass businessClass = new BusinessClass();
            DataTable dt = businessClass.GetHospitals();
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
                gvHospitals.DataSource = dvData;
            }
            else
            {
                gvHospitals.DataSource = dt;
            }
            gvHospitals.DataBind();
        }
    }
}