﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFClient.Models
{
    public class AdminUserHelper
    {
        public AdministratorCast admin { get; set; }
        private static readonly AdminUserHelper instance = new AdminUserHelper();

        public static AdminUserHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public AdministratorCast getAdministrator()
        {
            return admin;
        }
    }
}