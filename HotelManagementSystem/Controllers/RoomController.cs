using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HotelManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly SqlConnection _connection;
        public RoomController(ILogger<RoomController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("HotelManagementDB");
            _connection = new SqlConnection(_connectionString);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int roomnumber)
        {
            Room room = GetRoom(roomnumber);
            return View(room);
        }


        private Room GetRoom(int roomnumber)
        {
            Room room = new Room();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"[GetRoom]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RoomNumber", SqlDbType.Int)).Value = roomnumber;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    room.RoomNumber = Convert.ToInt32(reader["RoomNumber"]);
                    room.Status = reader["Status"].ToString();
                }
                connection.Close();


            }
            return room;
        }

    }
}
