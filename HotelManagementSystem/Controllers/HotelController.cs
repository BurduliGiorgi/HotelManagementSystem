using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
namespace HotelManagementSystem.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly SqlConnection _connection;
        public HotelController(ILogger<HotelController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("HotelManagementDB");
            _connection = new SqlConnection(_connectionString);
        }
        public IActionResult Index()
        {
            List<Hotel> hotels = new List<Hotel>();
            using (var connection = _connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM HotelManagementDB.dbo.Hotel", connection);
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
            Hotel hotel = GetHotel(id);
            return View(hotel);
        }

        private List<Staff> GetStaffs(int hotelId)
        {
            List<Staff> staffs = new List<Staff>();
            try
            {
                Console.WriteLine($"Fetching staff for Hotel ID: {hotelId}"); // Debugging Line

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("[GetStaffsByHotelId]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@HotelId", SqlDbType.Int)).Value = hotelId;

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        Console.WriteLine($"No staff found for Hotel ID: {hotelId}"); // Debugging Line
                    }

                    while (reader.Read())
                    {
                        staffs.Add(new Staff
                        {
                            StaffID = Convert.ToInt32(reader["StaffId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Position = reader["Position"].ToString(),
                            Salary = (decimal)(reader["Salary"]),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Phone = reader["Phone"].ToString(),
                            HireDate = Convert.ToDateTime(reader["HireDate"])
                        });
                    }
                }

                Console.WriteLine($"Total staff found: {staffs.Count}"); // Debugging Line
                return staffs;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching staff: {ex.Message}"); // Debugging Line
                throw;
            }
        }

        private Hotel GetHotel(int hotelId)
        {
            Hotel hotel = new Hotel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"[GetHotel]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@HotelId", SqlDbType.Int)).Value = hotelId;
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
            hotel.Staffs = GetStaffs(hotelId);
            return hotel;
        }
    }


}
    





