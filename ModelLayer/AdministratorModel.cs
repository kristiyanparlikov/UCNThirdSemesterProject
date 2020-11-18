﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class AdministratorModel : UserModel
    {
        public int EmployeeNumber { get; set; }

        //blank constructor
        public AdministratorModel()
        {

        }

        public AdministratorModel(string firstName, string lastName, string phoneNumber, string email, int employeeNumber) : base(firstName, lastName, phoneNumber, email)
        {
            EmployeeNumber = employeeNumber;

        }



    }
}
