using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace HotelManagementSystem.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        public HotelController(ILogger<HotelController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("HotelManagementDB"));
        }
        public IActionResult Index()
        {
            List<Hotel> hotels = new List<Hotel>();
            using (var connection = _connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HotelManagementDB.dbo.Hotels", connection);
                SqlDataReader reader = cmd.ExecuteReader();
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
                        CheckoutTime = DateTime.Parse(reader["CheckoutTime"].ToString()),

                    });

                }
                connection.Close();
            }

            return View(hotels);
        }



        public ActionResult Details(int id)
        {
            Hotel hotel = new Hotel();
            using (var connection = _connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM HotelManagementDB.dbo.Hotels WHERE Id={id}", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    hotel.Id = Convert.ToInt32(reader["Id"]);
                    hotel.Logo_Url = reader["Logo_Url"].ToString();
                    hotel.Name = reader["Name"].ToString();
                    hotel.Email = reader["Email"].ToString();
                    hotel.Phone = reader["Phone"].ToString();
                    hotel.Address = reader["Address"].ToString();
                    hotel.City = reader["City"].ToString();
                    hotel.Status = reader["Status"].ToString();
                    hotel.Stars = Convert.ToInt32(reader["Stars"]);
                    hotel.CheckinTime = DateTime.Parse(reader["CheckinTime"].ToString());
                    hotel.CheckoutTime = DateTime.Parse(reader["CheckoutTime"].ToString());
                }

                connection.Close();
            }
            return View(hotel);
        }
    }

    };


