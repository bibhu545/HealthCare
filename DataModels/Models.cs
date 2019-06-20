﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class User
    {
        public int status = -1;
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Profile { get; set; }
        public Boolean IsActive { get; set; }
    }
    public class Hospital
    {
        public int status = -1;
        public int HospitalId { get; set; }
        public int UserId { get; set; }
        public String HospitalName { get; set; }
        public String Address { get; set; }
        public String Phone1 { get; set; }
        public String Phone2 { get; set; }
        public String Email { get; set; }
        public int IsPrimary { get; set; }
    }
}
