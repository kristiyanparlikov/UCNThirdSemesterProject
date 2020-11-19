﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelLayer
{
    public class StudentModel : UserModel
    {
        public DateTime DateOfBirth { get; set; }

        public string Nationality { get; set; }

        public DateTime EducationEndDate { get; set; }

        //private Address address;

        public StudentModel() : base() { }

        public StudentModel(string firstName, string lastName, string phoneNumber, string email, DateTime dateOfBirth, string nationality, DateTime educationEndDate) : base(firstName, lastName, phoneNumber, email)
        {
            DateOfBirth = dateOfBirth;
            EducationEndDate = educationEndDate;
            Nationality = nationality;

        }

        

    }
}
