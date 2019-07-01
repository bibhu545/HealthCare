using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using DataModels;
using BusinessLayer;
using System.Web.Script.Serialization;

namespace HealthCare
{
    /// <summary>
    /// Summary description for GetFiles
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GetFiles : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetUserFiles()
        {
            List<Document> documents = new List<Document>();
            DataTable dt = new BusinessClass().GetFilesV2(1);
            foreach (DataRow row in dt.Rows)
            {
                Document d = new Document();
                d.DocumentId = Convert.ToInt32(row["documentid"]);
                String filepath = row["filepath"].ToString();
                String fName = filepath.Substring(filepath.LastIndexOf("/"), filepath.Length - filepath.LastIndexOf("/")).Substring(1);
                String extension = fName.Substring(fName.LastIndexOf(".")).Substring(1);
                d.Path = fName.Replace("." + extension, "");
                DateTime date = DateTime.Parse(row["issuedate"].ToString());
                d.IssueDate = date.ToString("MM/dd/yyyy");
                d.HospitalName = row["hospitalname"].ToString();
                d.DocumentTypeName = row["recordtype"].ToString();
                d.DoctorName = row["firstname"].ToString();
                documents.Add(d);
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(documents));
        }

        [WebMethod]
        public void DeleteUserFiles(String documentid)
        {
            int status = new BusinessClass().DeleteDocument(Convert.ToInt32(documentid));
            Context.Response.Write(status);
        }
    }
}
