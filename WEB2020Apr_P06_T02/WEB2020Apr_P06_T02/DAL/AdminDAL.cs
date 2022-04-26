using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WEB2020Apr_P06_T02.Models;

namespace WEB2020Apr_P06_T02.DAL
{
    public class AdminDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        public AdminDAL()
        {
            //Read ConnectionString from appsettings.json file
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string strConn = Configuration.GetConnectionString(
            "NPBookConnectionString");
            //Instantiate a SqlConnection object with the
            //Connection String read.
            conn = new SqlConnection(strConn);
        }

        public bool IsAccExist(string email, string pass)
        {
            bool accFound = false;
            //Create a SqlCommand object and specify the SQL statement
            //to get a staff record with the email address to be validated
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT *
            FROM Staff";
            //Open a database connection and excute the SQL statement
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            { //Records found
                while (reader.Read())
                {
                    if (reader.GetString(5) == email && reader.GetString(6) == pass && reader.GetString(4) == "Administrator")
                        //The email address is used by another staff
                        accFound = true;
                }
            }
            else
            { //No record
                accFound = false; // The email address given does not exist
            }
            reader.Close();
            conn.Close();

            return accFound;
        }
        public Staff GetDetails(string loginId)
        {

            Staff ad = new Staff();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM Staff
                                WHERE EmailAddr = @selectedLoginID";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “staffId”.
            cmd.Parameters.AddWithValue("@selectedLoginID", loginId);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {
                    // Fill staff object with values from the data reader
                    ad.StaffId = reader.GetInt32(0);
                    ad.StaffName = reader.GetString(1);
                    //ad.Gender = reader.GetChar(2);
                    ad.Gender = !reader.IsDBNull(2) ?
 reader.GetString(2)[0] : (char)0;
                    ad.DateEmployed = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null;
                    ad.Vocation = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                    ad.Email = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                    ad.Password = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                }
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return ad;
        }

        public void Add(Staff staff)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated StaffID after insertion
            cmd.CommandText = @"INSERT INTO Staff ( StaffName , Gender, DateEmployed, Vocation,
             EmailAddr, Password, Status)
            VALUES(@name, @gender, @dateemployed, @vocation,
            @email, @password, @status)";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@name", staff.StaffName);
            cmd.Parameters.AddWithValue("@gender", staff.Gender);
            cmd.Parameters.AddWithValue("@dateemployed", staff.DateEmployed);
            cmd.Parameters.AddWithValue("@vocation", staff.Vocation);
            cmd.Parameters.AddWithValue("@email", staff.Email);
            cmd.Parameters.AddWithValue("@password", staff.Password);
            cmd.Parameters.AddWithValue("@status", staff.Status);
            //A connection to database must be opened before any operations made.
            conn.Open();
            //ExecuteScalar is used to retrieve the auto-generated
            //StaffID after executing the INSERT SQL statement
            cmd.ExecuteNonQuery();
            //A connection should be closed after operations.
            conn.Close();

        }

        public List<Staff> GetAllStaff()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all flight routes
            cmd.CommandText = @"SELECT * FROM Staff";
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a flight route list
            List<Staff> staffList = new List<Staff>();
            while (reader.Read())
            {
                staffList.Add(
                    new Staff
                    {
                        StaffId = reader.GetInt32(0), // 0 - 1st column
                        StaffName = reader.GetString(1), // 1 - 2nd column
                        Gender = /*reader.GetChar(2)*/!reader.IsDBNull(2) ?
                        reader.GetString(2)[0] : (char?)0, // 2 - 3rd column
                        DateEmployed = reader.GetDateTime(3), // 2 - 3rd column
                        Vocation = reader.GetString(4), // 2 - 3rd column
                        Email = reader.GetString(5), // 2 - 3rd column
                        Password = reader.GetString(6),
                        Status = reader.GetString(7),

                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return staffList;
        }

        public List<FlightCrew> GetAllFlightCrew()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all flight routes
            cmd.CommandText = @"SELECT * FROM FlightCrew";
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a flight route list
            List<FlightCrew> flightcrewList = new List<FlightCrew>();
            while (reader.Read())
            {
                flightcrewList.Add(
                    new FlightCrew
                    {
                        ScheduleID = reader.GetInt32(0), // 0 - 1st column
                        StaffID = reader.GetInt32(1),
                        Role = reader.GetString(2), // 1 - 2nd column
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return flightcrewList;
        }
        public int UpdateStatus(Staff Staff)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an UPDATE SQL statement
            cmd.CommandText = @"UPDATE Staff SET Status=@Status WHERE StaffID = @StaffId";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@StaffId", Staff.StaffId);
            cmd.Parameters.AddWithValue("@Status", Staff.Status);
            //Open a database connection
            conn.Open();
            //ExecuteNonQuery is used for UPDATE and DELETE
            int count = cmd.ExecuteNonQuery();
            //Close the database connection
            conn.Close();
            return count;
        }
        public Staff GetDetail(string staffId)
        {
            Staff ad = new Staff();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM Staff
                                WHERE staffId = @selectedstaffID";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “staffId”.
            cmd.Parameters.AddWithValue("@selectedstaffID", staffId);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {
                    // Fill staff object with values from the data reader
                    ad.StaffId = reader.GetInt32(0);
                    ad.StaffName = reader.GetString(1);
                    //ad.Gender = reader.GetChar(2);
                    ad.Gender = !reader.IsDBNull(2) ?
 reader.GetString(2)[0] : (char)0;
                    ad.DateEmployed = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null;
                    ad.Vocation = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                    ad.Email = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                    ad.Password = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                    return ad;
                }
            }
            conn.Close();
            return ad;
        }

        public List<FlightCrew> GetScheduleStaff(int ScheduleId)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all branches
            cmd.CommandText = @"SELECT * FROM FlightCrew WHERE ScheduleID = @selectedscheduleId";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “branchNo”.
            cmd.Parameters.AddWithValue("@selectedscheduleId", ScheduleId);

            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            List<FlightCrew> FlightCrewList = new List<FlightCrew>();
            while (reader.Read())
            {
                FlightCrewList.Add(
                new FlightCrew
                {
                    ScheduleID = reader.GetInt32(0), //0: 1st colum
                    StaffID = reader.GetInt32(1),
                    Role = reader.GetString(2)

                }
                );
            }
            //Close DataReader
            reader.Close();
            //Close database connection
            conn.Close();
            return FlightCrewList;
        }

        public List<FlightCrew> GetScheduleCrew(int StaffId)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all branches
            cmd.CommandText = @"SELECT * FROM FlightCrew WHERE StaffID = @selectedstaffId";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “branchNo”.
            cmd.Parameters.AddWithValue("@selectedstaffID", StaffId);

            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            List<FlightCrew> FlightCrewList = new List<FlightCrew>();
            while (reader.Read())
            {
                FlightCrewList.Add(
                new FlightCrew
                {
                    ScheduleID = reader.GetInt32(0), //0: 1st colum
                    StaffID = reader.GetInt32(1),
                    Role = reader.GetString(2)

                }
                );
            }
            //Close DataReader
            reader.Close();
            //Close database connection
            conn.Close();
            return FlightCrewList;
        }

        public List<ScheduleView> GetAllFlightSchedule()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all flight schedules
            cmd.CommandText = @"SELECT FlightSchedule.ScheduleId, FlightSchedule.FlightNumber, FlightSchedule.Status FROM FlightSchedule";
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a flight schedule list
            List<ScheduleView> ScheduleList = new List<ScheduleView>();
            while (reader.Read())
            {
                ScheduleList.Add(
                     new ScheduleView
                     {
                         ScheduleId = reader.GetInt32(0),
                         FlightNumber = reader.GetString(1),
                         Status = reader.GetString(2),
                     }
                 );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return ScheduleList;
        }


        public int Change(FlightCrew flightCrew)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an UPDATE SQL statement
            cmd.CommandText = @"UPDATE FlightCrew SET Role=@Role WHERE StaffID = @StaffID";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@StaffID", flightCrew.StaffID);
            cmd.Parameters.AddWithValue("@Role", flightCrew.Role);
            //Open a database connection
            conn.Open();
            //ExecuteNonQuery is used for UPDATE and DELETE
            int count = cmd.ExecuteNonQuery();
            //Close the database connection
            conn.Close();
            return count;
        }



    }
}
