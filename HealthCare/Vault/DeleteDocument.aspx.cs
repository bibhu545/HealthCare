using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using LogAndErrors;

namespace HealthCare.Vault
{
    public partial class DeleteDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int documentid = Convert.ToInt32(Request.QueryString["id"]);
                int deleted = new BusinessClass().DeleteDocument(documentid);
                if (deleted == -1)
                {
                    Response.Redirect("ViewDocumentsV2.aspx?errorMessage=Some error occured. Please try again.");
                }
                else
                {
                    Response.Redirect("ViewDocumentsV2.aspx?successMessage=Record Deleted.");
                }
            }
            catch (Exception ex)
            {
                new LogAndErrorsClass().CatchException(ex);
            }
        }
    }
}