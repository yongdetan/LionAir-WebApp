using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using WEB2020Apr_P06_T02.Models;
using Microsoft.AspNetCore.Http;

namespace WEB2020Apr_P06_T02.DAL
{
    public class CustDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        //Constructor
        public CustDAL()
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

        public void Add(Customer cust)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            cmd.CommandText = @"INSERT INTO Customer (CustomerName, Nationality, BirthDate, TelNo,
            EmailAddr)
            VALUES(@name, @nationality, @dob, @telno,
            @email)";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@name", cust.Name);

            //Check if values are null
            if (string.IsNullOrEmpty(cust.Nationality))
                cmd.Parameters.AddWithValue("@nationality", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@nationality", cust.Nationality);

            if (!cust.DOB.HasValue)
                cmd.Parameters.AddWithValue("@dob", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@dob", cust.DOB);

            if (string.IsNullOrEmpty(cust.TelNo))
                cmd.Parameters.AddWithValue("@telno", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@telno", cust.TelNo);

            cmd.Parameters.AddWithValue("@email", cust.Email);
            //A connection to database must be opened before any operations made.
            conn.Open();
            cmd.ExecuteNonQuery();
            //A connection should be closed after operations.
            conn.Close();
        }

        public bool IsEmailExist(string email, int custId)
        {
            bool emailFound = false;
            //Create a SqlCommand object and specify the SQL statement
            //to get a customer record with the email address to be validated
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT CustomerID FROM Customer
            WHERE EmailAddr=@selectedEmail";
            cmd.Parameters.AddWithValue("@selectedEmail", email);
            //Open a database connection and excute the SQL statement
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            { //Records found
                while (reader.Read())
                {
                    if (reader.GetInt32(0) != custId)
                        //The email address is used by another customer
                        emailFound = true;
                }
            }
            else
            { //No record
                emailFound = false; // The email address given does not exist
            }
            reader.Close();
            conn.Close();
            return emailFound;
        }
        public bool IsPassportExist(string passportNo, int scheduleId)
        {
            bool passportExist = false;
            //Create a SqlCommand object and specify the SQL statement
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Booking";
            //Open a database connection and excute the SQL statement
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            { //Records found
                while (reader.Read())
                {
                    if (reader.GetString(4) == passportNo && reader.GetInt32(2) == scheduleId)
                        passportExist = true;
                }
            }
            else
            { //No record
                passportExist = false; 
            }
            reader.Close();
            conn.Close();
            return passportExist;
        }

        public bool IsAccExist(string email, string pass)
        {
            bool accFound = false;
            //Create a SqlCommand object and specify the SQL statement
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT *
            FROM Customer";
            //Open a database connection and execute the SQL statement
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            { //Records found
                while (reader.Read())
                {
                    if (reader.GetString(5) == email && reader.GetString(6) == pass)
                        accFound = true;
                }
            }
            else
            { //No record
                accFound = false; 
            }
            reader.Close();
            conn.Close();

            return accFound;
        }
        public Customer GetDetails(string loginId)
        {

            Customer cust = new Customer();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a customer record.
            cmd.CommandText = @"SELECT * FROM Customer
                                WHERE EmailAddr = @selectedLoginID";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “loginid (email)”.
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
                    // Fill customer object with values from the data reader
                    cust.CustId = reader.GetInt32(0);
                    cust.Name = reader.GetString(1);
                    cust.Nationality = !reader.IsDBNull(2) ? reader.GetString(2) : null;
                    cust.DOB = !reader.IsDBNull(3) ? reader.GetDateTime(3) : (DateTime?)null;
                    cust.TelNo = !reader.IsDBNull(4) ? reader.GetString(4) : null;
                    cust.Email = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                    cust.Password = !reader.IsDBNull(6) ? reader.GetString(6) : null;
                }
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return cust;
        }

        public List<Booking> GetAllBookings()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all bookings
            cmd.CommandText = @"SELECT * FROM Booking";
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a booking list
            List<Booking> bookingList = new List<Booking>();
            while (reader.Read())
            {
                bookingList.Add(
                    new Booking
                    {
                        BookingId = reader.GetInt32(0), 
                        CustId = reader.GetInt32(1), 
                        ScheduleId = reader.GetInt32(2), 
                        PassengerName = reader.GetString(3), 
                        PassportNumber = reader.GetString(4), 
                        Nationality = reader.GetString(5),
                        SeatClass = reader.GetString(6), 
                        AmtPayable = reader.GetDecimal(7),
                        Remarks = !reader.IsDBNull(8) ? reader.GetString(8) : null,
                        DateTimeCreated = reader.GetDateTime(9), 
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return bookingList;
        }

        public void ChangePass(Customer cust, string pass)
        {
            //Create a SqlCommand object and specify the SQL statement
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE Customer SET Password=@pass
                                WHERE CustomerID=@custId";
            //Open a database connection and excute the SQL statement
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.Parameters.AddWithValue("@custId", cust.CustId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Book(Booking booking)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            cmd.CommandText = @"INSERT INTO Booking (CustomerID, ScheduleID, PassengerName, PassportNumber,
            Nationality, SeatClass, AmtPayable, Remarks, DateTimeCreated)
            VALUES(@customerId, @scheduleId, @passengerName, @passportNo,
            @nationality, @seatClass, @amtPayable, @remarks, @dateTimeCreated)";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@customerId", booking.CustId);
            cmd.Parameters.AddWithValue("@scheduleId", booking.ScheduleId);
            cmd.Parameters.AddWithValue("@passengerName", booking.PassengerName);
            cmd.Parameters.AddWithValue("@passportNo", booking.PassportNumber);
            cmd.Parameters.AddWithValue("@nationality", booking.Nationality);
            cmd.Parameters.AddWithValue("@seatClass", booking.SeatClass);
            cmd.Parameters.AddWithValue("@amtPayable", booking.AmtPayable);
            if (string.IsNullOrEmpty(booking.Remarks))
                cmd.Parameters.AddWithValue("@remarks", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@remarks", booking.Remarks);
            cmd.Parameters.AddWithValue("@dateTimeCreated", DateTime.Now);
            //A connection to database must be opened before any operations made.
            conn.Open();
            cmd.ExecuteNonQuery();
            //A connection should be closed after operations.
            conn.Close();
        }
    }
}
