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
    public class FlightDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        public FlightDAL()
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

        public List<FlightRoute> GetAllFlightRoute()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all flight routes
            cmd.CommandText = @"SELECT * FROM FlightRoute";
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a flight route list
            List<FlightRoute> routeList = new List<FlightRoute>();
            while (reader.Read())
            {
                routeList.Add(
                    new FlightRoute
                    {
                        RouteId = reader.GetInt32(0), // 0 - 1st column
                        DepartureCity = reader.GetString(1), // 1 - 2nd column
                        DepartureCountry = reader.GetString(2), // 2 - 3rd column
                        ArrivalCity = reader.GetString(3), // 2 - 3rd column
                        ArrivalCountry = reader.GetString(4), // 2 - 3rd column
                        FlightDuration = reader.GetInt32(5), // 2 - 3rd column
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return routeList;
        }

        public List<FlightSchedule> GetAllFlightSchedule()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all flight schedules
            cmd.CommandText = @"SELECT * FROM FlightSchedule";
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a flight schedule list
            List<FlightSchedule> scheduleList = new List<FlightSchedule>();
            while (reader.Read())
            {
               scheduleList.Add(
                    new FlightSchedule
                    {
                        ScheduleId = reader.GetInt32(0), 
                        FlightNumber = reader.GetString(1), 
                        RouteId = reader.GetInt32(2), 
                        AircraftId = reader.GetInt32(3), 
                        DepartureDateTime = reader.GetDateTime(4),
                        ArrivalDateTime = reader.GetDateTime(5), 
                        EconomyClassPrice = reader.GetDecimal(6),
                        BusinessClassPrice = reader.GetDecimal(7), 
                        Status = reader.GetString(8)
                    }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return scheduleList;
        }

        public int getRoute(string origin, string destination)
        {
            int getRoute = -1;
            //Create a SqlCommand object and specify the SQL statement
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM FlightRoute";
            //Open a database connection and excute the SQL statement
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            { //Records found
                while (reader.Read())
                {
                    if (reader.GetString(2) == origin && reader.GetString(4) == destination)
                        getRoute = reader.GetInt32(0);
                }
            }
            else
            { //No record
                getRoute = -1; // The email address given does not exist
            }
            reader.Close();
            conn.Close();

            return getRoute;
        }

        public FlightSchedule GetFlightSchedule(int routeId)
        {
            FlightSchedule flightSchedule = new FlightSchedule();
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement that
            //retrieves all attributes of a flightschedule record.
            cmd.CommandText = @"SELECT * FROM FlightSchedule
                                WHERE RouteID = @selectedRouteID";
            //Define the parameter used in SQL statement, value for the
            //parameter is retrieved from the method parameter “routeid".
            cmd.Parameters.AddWithValue("@selectedRouteID", routeId);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                //Read the record from database
                while (reader.Read())
                {
                    flightSchedule.ScheduleId = reader.GetInt32(0);
                    flightSchedule.FlightNumber = reader.GetString(1);
                    flightSchedule.RouteId = reader.GetInt32(2);
                    flightSchedule.AircraftId = reader.GetInt32(3);
                    flightSchedule.DepartureDateTime = reader.GetDateTime(4);
                    flightSchedule.ArrivalDateTime = reader.GetDateTime(5);
                    flightSchedule.EconomyClassPrice = reader.GetDecimal(6);
                    flightSchedule.BusinessClassPrice = reader.GetDecimal(7);
                    flightSchedule.Status = reader.GetString(8);
                }
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return flightSchedule;
        }




    }
}
