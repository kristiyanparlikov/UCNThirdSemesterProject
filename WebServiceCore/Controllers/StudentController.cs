﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using BusinessLayer;
using ModelLayer;
using BC = BCrypt.Net.BCrypt;

namespace WebServiceCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentHandler studentHandler = new StudentHandler();

        [HttpPost]
        [Route("api/Student/Register")]
        public IActionResult Register(StudentLoginUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                //student info
                var student = new StudentModel()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    DateOfBirth = model.DateOfBirth,
                    EducationEndDate = model.EducationEndDate,
                    Nationality = model.Nationality

                };
                //password hash
                string mySalt = BC.GenerateSalt();
                var hashedPassword = BC.HashPassword(model.Password, mySalt);
                var result = studentHandler.Create(student, hashedPassword);
                return Ok("Success");
            }
            catch (Exception)
            {
                return Ok("Something went wrong");
            }
        }
        //public HttpResponseMessage Login(LogInUser model)
        //{
        //    //hash incoming password
        //    string mySalt = BCryptHelper.GenerateSalt();
        //    string hashedPassword = BCryptHelper.HashPassword(model.Password, mySalt);
        //    if (studentHandler.VerifyStudentCredentials(model.Email, hashedPassword))
        //    {
        //        var user = studentHandler.Get(model.Email);
        //        return Request.CreateResponse(HttpStatusCode.OK, TokenGenerator.CreateToken(user.Email));
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "Email or password is invalid");
        //    }
        //}

        /*[HttpPost]
        [Route("api/Student/LogIn")]
        public StudentModel Login([FromBody] LogInUser logInUser)
        {
            string realPassword = studentHandler.GetStudentPassword(logInUser.Email);
            if (realPassword == null)
            {
                return null;
            }
            bool doesPasswordsMatch = BC.Verify(logInUser.Password, realPassword);
            if (doesPasswordsMatch)
            {
                StudentModel loggedInStudentInformation = studentHandler.GetByEmail(logInUser.Email);
                return loggedInStudentInformation;
            }
            else return null;
        }*/
    }
}
