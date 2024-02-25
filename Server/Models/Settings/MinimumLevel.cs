using System.Text.Json.Serialization;

namespace Server.Models.Settings
{
    public class MinimumLevel
    {
        [JsonPropertyName("Default")]
        public string Default { get; set; }
    }
}
