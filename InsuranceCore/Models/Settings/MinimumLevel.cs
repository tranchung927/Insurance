using System.Text.Json.Serialization;

namespace InsuranceCore.Models.Settings
{
    public class MinimumLevel
    {
        [JsonPropertyName("Default")]
        public string Default { get; set; }
    }
}
