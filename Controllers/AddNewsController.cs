using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Project3API.Models;

namespace Project3API.Controllers
{
    public class AddNewsController : Controller
    {
        [HttpPost("insert")]
        public async Task<IActionResult> InsertNews([FromForm] News news)
        {
            string _connectionString = "Server=localhost,1433;Database=project3;User Id=sa;Password=sa;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var commandText = "INSERT INTO News (Title, Content, ShortContent, PersonId, Type, ImageUrl) VALUES (@Title, @Content, @ShortContent, @PersonId, @Type, @ImageUrl); SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@Title", news.title);
                    command.Parameters.AddWithValue("@Content", news.content);
                    command.Parameters.AddWithValue("@ShortContent", news.shortContent);
                    command.Parameters.AddWithValue("@PersonId", news.personId);
                    command.Parameters.AddWithValue("@Type", news.type);
                    //command.Parameters.AddWithValue("@ImageUrl", news.imageUrl);



                    //var file = news.getImageUrl; // Get the uploaded file from the student object
                    // Lưu hình ảnh vào thư mục Uploads
                    var file = HttpContext.Request.Form.Files.FirstOrDefault();

                    if (file != null && file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                        var filePath = Path.Combine("wwwroot", uniqueFileName);

                        // Save the file to the server
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Lấy đường dẫn tương đối của hình ảnh
                        //var relativeImagePath = Path.Combine("wwwroot", uniqueFileName);

                        // Lưu đường dẫn hình ảnh vào cơ sở dữ liệu
                        command.Parameters.AddWithValue("@ImageUrl", uniqueFileName);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ImageUrl", DBNull.Value);
                    }

                    // Execute the SQL command and get the inserted student ID
                    int insertedNewId = Convert.ToInt32(await command.ExecuteScalarAsync());

                    // Set the ID, name, age, and image path in the student object
                    news.newsId = insertedNewId;

                }
            }

            return Ok(news);
        }

    }
}
