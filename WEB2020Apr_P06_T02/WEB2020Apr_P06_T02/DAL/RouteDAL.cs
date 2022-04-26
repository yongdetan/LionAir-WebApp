using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;
using WEB2020Apr_P06_T02.Models;
using Microsoft.AspNetCore.Routing;

namespace WEB2020Apr_P06_T02.DAL
{
    public class RouteDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        public RouteDAL()
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

        public bool CheckExistRoute(FlightRoute route)
        {
            bool existroute = false;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all flight routes
            cmd.CommandText = @"SELECT * FROM FlightRoute WHERE (DepartureCity = @DepartureCity AND DepartureCountry = @DepartureCountry AND ArrivalCity = @ArrivalCity AND ArrivalCountry = @ArrivalCountry)";
            cmd.Parameters.AddWithValue("@DepartureCity", route.DepartureCity);
            cmd.Parameters.AddWithValue("@DepartureCountry", route.DepartureCountry);
            cmd.Parameters.AddWithValue("@ArrivalCity", route.ArrivalCity);
            cmd.Parameters.AddWithValue("@ArrivalCountry", route.ArrivalCountry);
            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a flight route list
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetString(1) == route.DepartureCity && reader.GetString(2) == route.DepartureCountry && reader.GetString(3) == route.ArrivalCity && reader.GetString(4) == route.ArrivalCountry)
                    {
                        existroute = true;
                    }
                    else
                    {
                        existroute = false;
                    }
                }
            }
            conn.Close();
            return existroute;
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
            List<FlightRoute> frList = new List<FlightRoute>();
            while (reader.Read())
            {
                frList.Add(
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
            return frList;
        }

        public List<ScheduleView> GetSchedule(int RouteId)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SQL statement that select all schedule
            cmd.CommandText = @"SELECT * FROM FlightSchedule WHERE RouteID = @selectedFlightSchedule";
            //Define the parameter used in SQL statement
            //parameter is retrieved from the method parameter “routeId”.
            cmd.Parameters.AddWithValue("@selectedFlightSchedule", RouteId);

            //Open a database connection
            conn.Open();
            //Execute SELCT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            List<ScheduleView> fsList = new List<ScheduleView>();
            while (reader.Read())
            {
                fsList.Add(
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
                    Status = reader.GetString(8)
                }
                );
            }
            //Close DataReader
            reader.Close();
            //Close database connection
            conn.Close();
            return fsList;
        }

        public int Add(FlightRoute FR)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify an INSERT SQL statement which will
            //return the auto-generated routeID after insertion
            cmd.CommandText = @"INSERT INTO FlightRoute (DepartureCity, DepartureCountry, ArrivalCity,
 ArrivalCountry, FlightDuration)
OUTPUT INSERTED.RouteID
VALUES(@DepartureCity, @DepartureCountry, @ArrivalCity, @ArrivalCountry, 
@FlightDuration)";
            //Define the parameters used in SQL statement, value for each parameter
            //is retrieved from respective class's property.
            cmd.Parameters.AddWithValue("@DepartureCity", FR.DepartureCity);
            cmd.Parameters.AddWithValue("@DepartureCountry", FR.DepartureCountry);
            cmd.Parameters.AddWithValue("@ArrivalCity", FR.ArrivalCity);
            cmd.Parameters.AddWithValue("@ArrivalCountry", FR.ArrivalCountry);
            cmd.Parameters.AddWithValue("@FlightDuration", FR.FlightDuration);
            //A connection to database must be opened before any operations made.
            conn.Open();
            //ExecuteScalar is used to retrieve the auto-generated
            //RouteID after executing the INSERT SQL statement
            FR.RouteId = (int)cmd.ExecuteScalar();
            //A connection should be closed after operations.
            conn.Close();
            //Return id when no error occurs.
            return FR.RouteId;
        }
    }



}
