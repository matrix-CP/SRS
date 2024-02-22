using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SRS.Models
{
    public class tblStudent
    {
         [Display(Name = "Student ID")]
        public int c_studentid { get; set; }

        [Display(Name = "Student Name:")]
        [Required(ErrorMessage = "Name can't be blank!")]
        public string c_name { get; set; }

        [Display(Name = "Student Date Of Birth:")]
        [Required(ErrorMessage = "DOB can't be blank")]
        public DateTime c_birthdate { get; set; }


        [Display(Name = "Student Gender :")]
        [Required(ErrorMessage = "Gender can't be blank!")]
        public string c_gender { get; set; }


        [Display(Name = "Address :")]
        public string c_address { get; set; }


        [Display(Name = "Select Language :")]
        [Required(ErrorMessage = "Language can't be blank!")]
        public List<string> c_language { get; set; }


        // public int c_courseid { get; set; }
        [Display(Name = "Course Name :")]
        public int c_course { get; set; }

        [Display(Name = "Course Name :")]
        public string c_coursename { get; set; }

        [Display(Name = "Upload Photo")]
        [Required(ErrorMessage = "Upload photo!")]
        public string c_profile {get; set;}

        [Display(Name = "Upload Document")]
        [Required(ErrorMessage = "Upload Document!")]
        public string c_document {get; set;}

        [Display(Name = "Student Mobile Number :")]
        public long c_mobile { get; set; }
    

    }
}