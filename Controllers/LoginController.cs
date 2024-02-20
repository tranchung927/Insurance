using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Project3API.Models;

namespace Project3API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpGet("getaccount/{username}/{password}")]
        public async Task<IActionResult> GetAccount(string username, string password)
        {
            try
            {
                string _connectionString = "Server=localhost,1433;Database=project3;User Id=sa;Password=sa;TrustServerCertificate=True;";
                // Kết nối đến cơ sở dữ liệu
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    // Sử dụng parameterized query để tránh SQL Injection
                    var commandText = "SELECT Username, Password, Role FROM Person WHERE Username = @Username AND Password = @Password;";
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            // Kiểm tra xem có dòng dữ liệu nào được trả về không
                            if (reader.Read())
                            {
                                // Tạo đối tượng Person từ dữ liệu đọc được từ cơ sở dữ liệu
                                var person = new Person
                                {
                                    username = reader.GetString(reader.GetOrdinal("Username")),
                                    password = reader.GetString(reader.GetOrdinal("Password")),
                                    role = reader.GetString(reader.GetOrdinal("Role"))
                                };

                                // Trả về thông tin tài khoản nếu tìm thấy
                                return Ok(person);
                            }
                            else
                            {
                                // Trả về lỗi 404 nếu không tìm thấy tài khoản
                                return NotFound();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trả về lỗi 500 nếu có lỗi xảy ra
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
