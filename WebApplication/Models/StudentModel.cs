﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class StudentRegisterModel
    {
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirmation password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public string DateOfBirth { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Education end date")]
        [DataType(DataType.Date)]
        public string EducationEndDate { get; set; }

        public string Nationality { get; set; }

    }

    public class StudentLoginModel 
    {
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}