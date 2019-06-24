using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;
using DataModels;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare.Vault
{
    public partial class ViewDocumentsV2 : System.Web.UI.Page
    {
        public User user = null;
        public FileData fileData = null;
        DateTime fromDateTime;
        DateTime toDateTime;
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
                        ViewState["status"] = 0;
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
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }
        public String GetFileName(String filepath)
        {
            try
            {
                String fName = filepath.Substring(filepath.LastIndexOf("/"), filepath.Length - filepath.LastIndexOf("/")).Substring(1);
                String extension = fName.Substring(fName.LastIndexOf(".")).Substring(1);
                return fName.Replace("." + extension, "");
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
            return null;
        }
        public String GetFormattedDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return dt.ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
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
                gvFiles.PageIndex = e.NewPageIndex;
                BindDataGrid();
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }

        protected void OnSorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                BindDataGrid(e.SortExpression);
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }
        private void BindDataGrid(String sortExpression = null)
        {
            try
            {
                BusinessClass businessClass = new BusinessClass();
                DataTable dt = businessClass.GetFilesV2(((User)Session["loggedUser"]).UserId);
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
                    gvFiles.DataSource = dvData;
                }
                else
                {
                    gvFiles.DataSource = dt;
                }
                gvFiles.DataBind();
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }
        private void BindFilteredDataGrid(String sortExpression = null)
        {
            try
            {
                BusinessClass businessClass = new BusinessClass();
                DataTable dt = businessClass.GetFilteredFilesV2(((User)Session["loggedUser"]).UserId, fromDateTime, toDateTime);
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
                    gvFiles.DataSource = dvData;
                }
                else
                {
                    gvFiles.DataSource = dt;
                }
                gvFiles.DataBind();
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }

        protected void btnFilterDocument_Click(object sender, EventArgs e)
        {
            try
            {
                String fromDate = txtFromDate.Text.Trim();
                String toDate = txtToDate.Text.Trim();
                String[] from = fromDate.Split('/');
                String[] to = toDate.Split('/');
                if (from.Length != 3 || to.Length != 3)
                {
                    Response.Redirect("ViewDocumentsV2.aspx?errorMessage=Start and end date combination is not valid.");
                }
                else if (from.Length == 3 & to.Length == 3)
                {
                    if (from[2].Length != 4 || (Convert.ToInt32(from[0]) <= 0 && Convert.ToInt32(from[0]) > 12) || (Convert.ToInt32(from[1]) <= 0 && Convert.ToInt32(from[1]) > 31))
                    {
                        Response.Redirect("ViewDocumentsV2.aspx?errorMessage=Start and end date combination is not valid.");
                    }
                }
                else
                {
                    fromDateTime = new DateTime(Convert.ToInt32(from[2]), Convert.ToInt32(from[0]), Convert.ToInt32(from[1]));
                    toDateTime = new DateTime(Convert.ToInt32(to[2]), Convert.ToInt32(to[0]), Convert.ToInt32(to[1]));
                    if (fromDateTime < toDateTime)
                    {
                        BindFilteredDataGrid();
                    }
                    else
                    {
                        Response.Redirect("ViewDocumentsV2.aspx?errorMessage=Start and end date combination is not valid.");
                    }
                }
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }
    }
}