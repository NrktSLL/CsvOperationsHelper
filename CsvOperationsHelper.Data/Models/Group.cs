using Newtonsoft.Json;

namespace CsvOperationsHelper.Data.Models
{
    public class Group
    {
        [JsonProperty("GroupId")]
        public int Id { get; set; }
        [JsonProperty("GroupName")]
        public string Name { get; set; }
    }
}
