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
    public class FlightScheduleDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        public FlightScheduleDAL()
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
    }
}
