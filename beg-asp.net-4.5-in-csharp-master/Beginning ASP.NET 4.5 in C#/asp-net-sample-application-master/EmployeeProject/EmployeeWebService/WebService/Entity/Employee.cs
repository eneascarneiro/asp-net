using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Entity
{
    public class Employee
    {
        // public static string filePath = "Avatar//";

        public string id { get; set; }
        public string title { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string designation { get; set; }
        public string dob { get; set; }
        public string father_name { get; set; }
        public string department { get; set; }
        public string gender { get; set; }
        public string spouse_name { get; set; }
        public string permanent_address { get; set; }
        public string temporary_address { get; set; }
        public string avatar_path { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        
    }
}