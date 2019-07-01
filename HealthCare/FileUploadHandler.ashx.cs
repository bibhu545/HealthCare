using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModels;
using Newtonsoft.Json.Linq;
using BusinessLayer;
using System.IO;

namespace HealthCare
{
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                string jsonString = HttpContext.Current.Request.Form["model"];
                dynamic data = JObject.Parse(jsonString);
                Document document = new Document();
                document.UserId = ((User)context.Session["loggedUser"]).UserId;
                document.HospitalId = Convert.ToInt32(data.HospitalId);
                document.DoctorId = Convert.ToInt32(data.DoctorId);
                document.DocumentType = Convert.ToInt32(data.RecordId);
                document.IssueDate = data.IssueDate;

                String path = context.Server.MapPath(@"~/files/uploads/");
                String folder = path + document.UserId.ToString() + @"\";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                List<String> allFiles = new List<string>();
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    String fileName = file.FileName.Replace("'","''");
                    String randomPrefix = new BusinessClass().RandomAlphaNumericString();
                    allFiles.Add(@"/files/uploads/" + document.UserId + @"/" + randomPrefix + "_" + fileName);
                    file.SaveAs(folder + randomPrefix + "_" + fileName);
                }
                document = new BusinessClass().SaveDocument(document, allFiles);
                if(document.status == -1)
                {
                    context.Response.Write("Some error occured. Please try again.");
                }
                else
                {
                    context.Response.Write("File Uploaded Successfully!");
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}