﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using DataAccess;
using DataModels;
using System.Data;

namespace BusinessLayer
{
    public class ConfirmRegistration
    {
        public int Added { get; set; }
        public int Otp { get; set; }
    }
    public class FileData
    {
        public List<String> FileName = new List<string>();
        public List<String> Extension = new List<string>();
        public List<String> FilePath = new List<string>();
        public List<String> IssueDate = new List<string>();
        public List<String> HospitalName = new List<string>();
        public List<String> DoctorName = new List<string>();
        public List<String> RecordType = new List<string>();
    }
    public class BusinessClass
    {
        public ConfirmRegistration CreateUser(User user)
        {
            Random random = new Random();
            int otp = random.Next(1999, 9999);

            String mailHead = "Complete your registration at Healthcare.";
            String mailBody = "Please enter <strong> "+ otp.ToString() + " </strong> to confirm your membership";
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("7c73e9fdbcbfbf", "4708f0b90c37e9"),
                EnableSsl = true
            };
            client.Send("bibhu@demomail.com", user.Email, mailHead, mailBody);

            return new ConfirmRegistration() { Added = new DataAccessClass().SaveUserToDB(user), Otp = otp};
        }
        public int ActivateUser(User user)
        {
            return new DataAccessClass().ActivaeUserToDB(user);
        }
        public User Login(String email, String password)
        {
            return new DataAccessClass().LoginFromDB(email, password);
        }
        public User EditUserDetails(User user)
        {
            return new DataAccessClass().UpdateUserToDB(user);
        }
        public User updatePassword(User user)
        {
            return new DataAccessClass().UpdatePasswordToDB(user);
        }

        public int AddHospital(Hospital hospital)
        {
            return new DataAccessClass().AddHospitalToDB(hospital);
        }
        public DataTable GetHospitals()
        {
            return new DataAccessClass().GetHospitalsFromDB();
        }
        public DataTable GetSpecialities()
        {
            return new DataAccessClass().GetSpecialitiesFromDB();
        }
        public DataTable GetDoctors(int doctorid)
        {
            return new DataAccessClass().GetDoctorsFromDB(doctorid);
        }
        public int DeleteHospital(int hospitalid)
        {
            return new DataAccessClass().DeleteHospitalFromDB(hospitalid);
        }
        public int DeleteDoctor(int doctorid)
        {
            return new DataAccessClass().DeleteDoctorFromDB(doctorid);
        }
        public Hospital GetHospitalDetails(int id)
        {
            return new DataAccessClass().GetHospitalDetailsFromDB(id);
        }
        public DataTable GetDoctorDetails(int id)
        {
            return new DataAccessClass().GetDoctorDetailsFromDB(id);
        }
        public DataTable GetDoctorsByHospital(int hospitalid)
        {
            return new DataAccessClass().GetDoctorsByHospitalFromDB(hospitalid);
        }
        public Hospital EditHospitalDetails(Hospital hospital)
        {
            return new DataAccessClass().UpdateHospitalToDB(hospital);
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            return new DataAccessClass().AddDoctorToDB(doctor);
        }
        public Doctor EditDoctor(Doctor doctor)
        {
            return new DataAccessClass().UpdateDoctorToDB(doctor);
        }
        public DataTable GetRecordTypes()
        {
            return new DataAccessClass().GetRecordTypesFromDB();
        }
        public Document SaveDocument(Document document, List<String> allFiles)
        {
            return new DataAccessClass().SaveDocumentToDB(document, allFiles);
        }
        public FileData GetFiles(int userid)
        {
            DataTable dt = new DataAccessClass().GetFilesFromDB(userid);
            FileData fileData = new FileData();
            foreach (DataRow row in dt.Rows)
            {
                String file = row["filepath"].ToString();
                String fName = file.Substring(file.LastIndexOf("/"), file.Length - file.LastIndexOf("/")).Substring(1);
                String extension = fName.Substring(fName.LastIndexOf(".")).Substring(1); ;
                fileData.FileName.Add(fName.Replace("." + extension, ""));
                fileData.Extension.Add(extension);
                fileData.FilePath.Add(row["filepath"].ToString());
                fileData.IssueDate.Add(row["issuedate"].ToString());
                fileData.HospitalName.Add(row["hospitalname"].ToString());
                fileData.DoctorName.Add(row["firstname"].ToString());
                fileData.RecordType.Add(row["recordid"].ToString());
            }
            return fileData;
        }
    }
}
