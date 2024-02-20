using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Project3API.Models;


[ApiController]
[Route("api/[controller]")]
public class NewsController : ControllerBase
{
    // Trong lớp NewsController
    [HttpGet("all")]
    public async Task<IEnumerable<News>> GetNews()
    {
        var newsList = new List<News>();
        //string _connectionString = "Server=localhost,1433;Database=project3;User Id=sa;Password=sa;";
        string _connectionString = "Server=localhost,1433;Database=project3;User Id=sa;Password=sa;TrustServerCertificate=True;";


        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var commandText = "SELECT * FROM News;";

            using (var command = new SqlCommand(commandText, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var newsItem = new News
                        {
                            title = reader.GetString(reader.GetOrdinal("title")),
                            content = reader.GetString(reader.GetOrdinal("content")),
                            type = reader.GetString(reader.GetOrdinal("type")),
                            shortContent = reader.GetString(reader.GetOrdinal("shortContent")),
                            imageUrl = reader.GetString(reader.GetOrdinal("imageUrl")), // hoặc sử dụng GetSqlBytes nếu là kiểu image
                            createdAt = reader.GetDateTime(reader.GetOrdinal("createdAt"))
                        };
                        newsList.Add(newsItem);
                    }
                }
            }
        }

        return newsList;
    }
}




