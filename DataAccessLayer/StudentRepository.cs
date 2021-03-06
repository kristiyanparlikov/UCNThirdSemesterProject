﻿ using DataAccessLayer.Repository;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentRepository : IStudentRepository
    {
        //private readonly string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private readonly string connString = "Data Source = hildur.ucn.dk; Initial Catalog = dmaj0919_1081489; User ID = dmaj0919_1081489; Password=Password1!;Connect Timeout = 60; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        //using ado.net
        public StudentModel Add(StudentModel student, string hashedPassword)
        {
            var query = "INSERT INTO Students (Email, Password, FirstName, LastName, PhoneNumber, DateOfBirth, Nationality, EducationEndDate) ";
            query += "VALUES (@Email, @Password, @FirstName, @LastName, @PhoneNumber, @DateOfBirth, @Nationality, @EducationEndDate) ";
            query += "SELECT CAST (SCOPE_IDENTITY() as int)";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Email", student.Email));
                        cmd.Parameters.Add(new SqlParameter("@Password", hashedPassword));
                        cmd.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
                        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", student.DateOfBirth));
                        cmd.Parameters.Add(new SqlParameter("@Nationality", student.Nationality));
                        cmd.Parameters.Add(new SqlParameter("@EducationEndDate", student.EducationEndDate));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        var id = cmd.ExecuteScalar();
                        student.Id = (int)id;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return student;

        }

        public StudentModel FindByEmail(string email)
        {
            string query = "SELECT * FROM Students WHERE Email=@Email";
            StudentModel student = new StudentModel();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", email));

                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                student.Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id"));
                                student.Email = dr.GetFieldValue<string>(dr.GetOrdinal("Email"));
                                student.FirstName = dr.GetFieldValue<string>(dr.GetOrdinal("FirstName"));
                                student.LastName = dr.GetFieldValue<string>(dr.GetOrdinal("LastName"));
                                student.PhoneNumber = dr.GetFieldValue<string>(dr.GetOrdinal("PhoneNumber"));
                                student.DateOfBirth = dr.GetFieldValue<DateTime>(dr.GetOrdinal("DateOfBirth"));
                                student.Nationality = dr.GetFieldValue<string>(dr.GetOrdinal("Nationality"));
                                student.EducationEndDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("EducationEndDate"));
                                return student;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
            }
            return null;
        }
        public StudentModel FindById(int id)
        {
            string query = "SELECT * FROM Students WHERE Id=@Id";
            StudentModel student = new StudentModel();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                student.Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id"));
                                student.Email = dr.GetFieldValue<string>(dr.GetOrdinal("Email"));
                                student.FirstName = dr.GetFieldValue<string>(dr.GetOrdinal("FirstName"));
                                student.LastName = dr.GetFieldValue<string>(dr.GetOrdinal("LastName"));
                                student.PhoneNumber = dr.GetFieldValue<string>(dr.GetOrdinal("PhoneNumber"));
                                student.DateOfBirth = dr.GetFieldValue<DateTime>(dr.GetOrdinal("DateOfBirth"));
                                student.Nationality = dr.GetFieldValue<string>(dr.GetOrdinal("Nationality"));
                                student.EducationEndDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("EducationEndDate"));
                                return student;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
            }
            return null;
        }

        public List<StudentModel> GetAll()
        {
            string query = "SELECT * FROM Students";
            List<StudentModel> students = new List<StudentModel>();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (dr.Read())
                        {
                            students.Add(new StudentModel
                            {
                                Id = dr.GetFieldValue<int>(dr.GetOrdinal("Id")),
                                FirstName = dr.GetFieldValue<string>(dr.GetOrdinal("FirstName")),
                                LastName = dr.GetFieldValue<string>(dr.GetOrdinal("LastName")),
                                PhoneNumber = dr.GetFieldValue<string>(dr.GetOrdinal("PhoneNumber")),
                                Email = dr.GetFieldValue<string>(dr.GetOrdinal("Email")),
                                DateOfBirth = dr.GetFieldValue<DateTime>(dr.GetOrdinal("DateOfBirth")),
                                Nationality = dr.GetFieldValue<string>(dr.GetOrdinal("Nationality")),
                                EducationEndDate = dr.GetFieldValue<DateTime>(dr.GetOrdinal("EducationEndDate")),

                            });
                        }
                    }
                }
            }
            return students;
        }

        public int Remove(int id)
        {
            string query = "DELETE * FROM Students WHERE Id = '@Id'";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cnn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public bool Update(StudentModel studentModel)
        {
            var sql = "UPDATE Students SET FirstName = @FirstName ,LastName = @LastName," +
                    "PhoneNumber = @PhoneNumber ,Email = @Email," +
                    "DateOfBirth = @DateOfBirth ,Nationality = @Nationality," +
                    " EducationEndDate = @EducationEndDates WHERE Id = @Id";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@FirstName", studentModel.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", studentModel.LastName));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", studentModel.PhoneNumber));
                        cmd.Parameters.Add(new SqlParameter("@Email", studentModel.Email));
                        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", studentModel.DateOfBirth));
                        cmd.Parameters.Add(new SqlParameter("@Nationality", studentModel.Nationality));
                        cmd.Parameters.Add(new SqlParameter("@EducationEndDate", studentModel.EducationEndDate));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        var rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public bool VerifyStudent(string email, string hashedPassword)
        {
            string query = "SELECT * FROM Students WHERE Email=@Email AND Password=@Password";

            using(SqlConnection cnn = new SqlConnection(connString))
            {
                using(SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Password", hashedPassword));

                    cnn.Open();

                    var result = cmd.ExecuteScalar();

                    if (result != null)
                        return true;
                    else { return false; }
                }
            }
        }

        public string GetStudentPassword(string email)
        {
            string password = null;
            var sql = "SELECT [Password] FROM [Students] WHERE Email =@Email ";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Email", email));

                        // Set CommandType
                        cmd.CommandType = CommandType.Text;

                        // Open connection
                        cnn.Open();

                        // Execute the first statement
                        password = (string)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return password;
        }

        public StudentModel FindByBookingId(int bookingId)
        {
            string query = "SELECT StudentId, FirstName, LastName, Email FROM Students ";
            query += "Join StudentBooking ON Students.Id = StudentBooking.StudentId WHERE BookingId = @BookingId";
            StudentModel student = new StudentModel();
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    cmd.Parameters.Add(new SqlParameter("@BookingId", bookingId));

                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                student.Id = dr.GetFieldValue<int>(dr.GetOrdinal("StudentId"));
                                student.Email = dr.GetFieldValue<string>(dr.GetOrdinal("Email"));
                                student.FirstName = dr.GetFieldValue<string>(dr.GetOrdinal("FirstName"));
                                student.LastName = dr.GetFieldValue<string>(dr.GetOrdinal("LastName"));
                                return student;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                        return student;
                    }
                }
            }
        }
    }


    //using dapper
    /*
    public StudentModel Add(StudentModel student)
    {
        v
        var sql =
            "INSERT INTO Students (FirstName, LastName, PhoneNumber, Email, DateOfBirth, Nationality, EducationEndDate) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @DateOfBirth, @Nationality, @EducationEndDate);" +
            "SELECT CAST(SCOPE_INDENTITY() as int)";
        var id = this.db.Query<int>(sql, student).Single();
        student.Id = id;
        return student;
    }

    public StudentModel Find(int id)
    {
        return this.db.Query<StudentModel>("SELECT * FROM Students WHERE Id =@Id", new { id }).SingleOrDefault();
    }

    public StudentModel GetSingleStudent(int id)
    {
        return db.Query<StudentModel>("SELECT[id],[FirstName],[LastName] FROM [Students] WHERE Id =@id", new { Id = id }).SingleOrDefault();
    }

    public List<StudentModel> GetAll()
    {
        return this.db.Query<StudentModel>("SELECT * FROM Students").ToList();
    }

    public bool Remove(int id)
    {
        int rowsAffected = this.db.Execute(@"DELETE FROM [Students] WHERE Id = @Id",
            new { Id = id });

        if (rowsAffected > 0)
        {
            return true;
        }

        return false;
    }

    public bool Update(StudentModel student)
    {
        int rowsAffected = this.db.Execute(
                    "UPDATE [Students] SET [FirstName] = @FirstName ,[LastName] = @LastName," +
                    "[PhoneNumber] = @PhoneNumber ,[Email] = @Email," +
                    "[DateOfBirth] = @DateOfBirth ,[Nationality] = @Nationality," +
                    " [EducationEndDate] = @EducationEndDate WHERE Id = " +
                    student.Id, student);

        if (rowsAffected > 0)
        {
            return true;
        }

        return false;
    }

    */
}