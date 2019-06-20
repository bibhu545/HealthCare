using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModels;

namespace HealthCare
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        public User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loggedUser"] != null)
            {
                user = (User)Session["loggedUser"];
            }
            else if (Session["inactiveUser"] != null)
            {
                user = (User)Session["inactiveUser"];
                user.Profile = "/files/profiles/default-profile.png";
            }

        }
    }
}