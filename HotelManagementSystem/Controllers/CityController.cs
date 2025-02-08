using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace HotelManagementSystem.Controllers
{
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;

        public CityController(ILogger<CityController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("HotelManagementDB"));
        }
        public IActionResult Index(string city)
        {
            List<Hotel> hotels = GetCity(city);
            return View(hotels);
        }
        public List<Hotel> GetCity(string city)
        {
            List<Hotel> hotels = new List<Hotel>();

            using (var connection = _connection)
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("[GetHotelByName]", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar)
                    {
                        Value = string.IsNullOrEmpty(city) ? (object)DBNull.Value : city
                    });

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hotels.Add(new Hotel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Logo_Url = reader["Logo_Url"].ToString(),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Status = reader["Status"].ToString(),
                                Stars = Convert.ToInt32(reader["Stars"]),
                                CheckinTime = DateTime.Parse(reader["CheckinTime"].ToString()),
                                CheckoutTime = DateTime.Parse(reader["CheckoutTime"].ToString())
                            });
                        }
                    }
                }
            }

            return hotels;
        }
    }
}
