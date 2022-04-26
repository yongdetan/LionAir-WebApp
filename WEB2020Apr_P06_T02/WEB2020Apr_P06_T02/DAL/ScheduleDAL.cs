using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using WEB2020Apr_P06_T02.Models;

namespace WEB2020Apr_P06_T02.DAL
{
    public class ScheduleDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        public ScheduleDAL()
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

        public List<ScheduleView> GetAllFSchedule()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all flight schedules
            cmd.CommandText = @"SELECT FlightSchedule.* ,COUNT(Booking.ScheduleID) AS 'Number of Tickets Booked' FROM Booking RIGHT JOIN FlightSchedule ON Booking.ScheduleID = FlightSchedule.ScheduleID GROUP BY Booking.ScheduleID, FlightSchedule.AircraftID, FlightSchedule.ArrivalDateTime, FlightSchedule.BusinessClassPrice, FlightSchedule.DepartureDateTime, FlightSchedule.EconomyClassPrice, FlightSchedule.FlightNumber,FlightSchedule.RouteID,FlightSchedule.ScheduleID,FlightSchedule.Status";
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a flight schedule list
            List<ScheduleView> schList = new List<ScheduleView>();
            while (reader.Read())
            {
                schList.Add(
                     new ScheduleView
                     {
                         ScheduleId = reader.GetInt32(0),
                         FlightNumber = reader.GetString(1),
                         RouteId = reader.GetInt32(2),
                         AircraftId = !reader.IsDBNull(3) ? reader.GetInt32(3) : (int?)null,
                         DepartureDateTime = reader.GetDateTime(4),
                         ArrivalDateTime = reader.GetDateTime(5),
                         EconomyClassPrice = reader.GetDecimal(6),
                         BusinessClassPrice = reader.GetDecimal(7),
                         Status = reader.GetString(8),
                         Ticket = reader.GetInt32(9)
                     }
                 );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return schList;
        }

        public ScheduleView GetDetails(int ScheduleId)
        {
            ScheduleView Schedule = new ScheduleView();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify the SELECT SQL statement that
            //retrieves all attributes of a schedule record.
            cmd.CommandText = @"SELECT * FROM FlightSchedule
 WHERE ScheduleID = @selectedScheduleId";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “staffId”.
            cmd.Parameters.AddWithValue("@selectedScheduleId", ScheduleId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {
                    // Fill schedule object with values from the data reader
                    Schedule.ScheduleId = ScheduleId;
                    Schedule.FlightNumber = reader.GetString(1);
                    // (char) 0 - ASCII Code 0 - null value
                    Schedule.RouteId = reader.GetInt32(2);
                    Schedule.AircraftId = !reader.IsDBNull(3) ? reader.GetInt32(3) : (int?)null;
                    Schedule.DepartureDateTime = !reader.IsDBNull(4) ? reader.GetDateTime(4) : (DateTime?)null;
                    Schedule.ArrivalDateTime = !reader.IsDBNull(5) ? reader.GetDateTime(5) : (DateTime?)null;
                    Schedule.EconomyClassPrice = reader.GetDecimal(6);
                    Schedule.BusinessClassPrice = reader.GetDecimal(7);
                    Schedule.Status = !reader.IsDBNull(8) ? reader.GetString(8) : null;
                }
            }
            reader.Close();
            conn.Close();
            return Schedule;


        }

        public int Update(ScheduleView Schedule)
        {
            //create command
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE FlightSchedule SET Status = @status WHERE ScheduleID = @selectedScheduleId";
            cmd.Parameters.AddWithValue("@status", Schedule.Status);
            cmd.Parameters.AddWithValue("@selectedScheduleId", Schedule.ScheduleId);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            //Close the database connection
            conn.Close();
            return count;
        }

        public int Add(ScheduleView Schedule)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated ScheduleID after insertion
            cmd.CommandText = @"INSERT INTO FlightSchedule (FlightNumber, RouteID, AircraftID,
 DepartureDateTime, ArrivalDateTime, EconomyClassPrice, BusinessClassPrice, Status)
OUTPUT INSERTED.ScheduleID
VALUES(@FlightNumber, @RouteId, @AircraftId,
@DepartureDateTime, @ArrivalDateTime, @EconomyClassPrice, @BusinessClassPrice, 'Opened')";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property
            cmd.Parameters.AddWithValue("@FlightNumber", Schedule.FlightNumber);
            cmd.Parameters.AddWithValue("@RouteId", Schedule.RouteId);
            cmd.Parameters.AddWithValue("@DepartureDateTime", Schedule.DepartureDateTime);
            cmd.Parameters.AddWithValue("@ArrivalDateTime", Schedule.ArrivalDateTime);
            cmd.Parameters.AddWithValue("@EconomyClassPrice", Schedule.EconomyClassPrice);
            cmd.Parameters.AddWithValue("@BusinessClassPrice", Schedule.BusinessClassPrice);
            if (Schedule.AircraftId != null & Schedule.AircraftId != 0)
                cmd.Parameters.AddWithValue("@AircraftId", Schedule.AircraftId);
            else
                cmd.Parameters.AddWithValue("@AircraftId", DBNull.Value);
            //A connection to database must be opened before any operations made.
            conn.Open();
            //ExecuteScalar is used to retrieve the auto-generated
            //scheduleID after executing the INSERT SQL statement
            Schedule.ScheduleId = (int)cmd.ExecuteScalar();
            //A connection should be closed after operations.
            conn.Close();
            //Return id when no error occurs.
            return Schedule.ScheduleId;
        }

        public FlightRoute GetDuration(int RouteId)
        {
            FlightRoute Route = new FlightRoute();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();

            //Specify the SELECT SQL statement that
            //retrieves all attributes of a staff record.
            cmd.CommandText = @"SELECT * FROM FlightRoute
 WHERE RouteID = @selectedRouteId";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “staffId”.
            cmd.Parameters.AddWithValue("@selectedRouteId", RouteId);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {
                    Route.RouteId = RouteId; // 0 - 1st column
                    Route.DepartureCity = reader.GetString(1); // 1 - 2nd column
                    Route.DepartureCountry = reader.GetString(2); // 2 - 3rd column
                    Route.ArrivalCity = reader.GetString(3); // 2 - 3rd column
                    Route.ArrivalCountry = reader.GetString(4); // 2 - 3rd column
                    Route.FlightDuration = reader.GetInt32(5); // 2 - 3rd column
                }
            }
            reader.Close();
            conn.Close();
            return Route;
        }
    }


}
