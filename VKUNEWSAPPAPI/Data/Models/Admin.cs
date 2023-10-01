using Microsoft.VisualBasic;
using System;

namespace VKUNEWSAPPAPI.Data.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Age { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string FatherKula { get; set; }
        public string MotherKula { get; set; }
        public string Education { get; set; } 
        public string MyCast { get; set; }
        public string Employment { get; set; }
        public string Marriage { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string Taluk { get; set; }
        public string Hobli { get; set; }
        public string Village { get; set; }
        public int PinCode { get; set; }
        public string God { get; set; }
        public string Place { get; set; }
        public string GodTaluk { get; set; }
        public string Goddesses { get; set; }
        public string GoddessesPlace { get; set; }
        public string GoddessesTaluk { get;set; }
        public string Photo { get; set; }
        public string AadharNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Otp { get; set; }
    }
}
