using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDinMVC.Models
{
    public class StudentModel
    {
        [Display(Name="Id")]
        public Int32 Id
        {
            get;
            set;
        }

        [Required(ErrorMessage="Name is required.")]
        public String Name
        {
            get;
            set;
        }

        [Required(ErrorMessage = "City is required.")]
        public String City
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Address is required.")]
        public String Address
        {
            get;
            set;
        }
    }
}