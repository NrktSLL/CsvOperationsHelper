using System;
using System.ComponentModel;
using CsvOperationsHelper.Data.Enums;
using Newtonsoft.Json;

namespace CsvOperationsHelper.Data.Models
{
    public class Product
    {
        [JsonProperty("ProductId")]
        public int Id { get; set; }
        [JsonProperty("ProductName")]
        public string Name { get; set; }
        [JsonProperty("ProductPrice")]
        public double Price { get; set; }
        [JsonProperty("ProductGroup")]
        public Group Group { get; set; }
        [JsonProperty("ProductStatus")]
        [DefaultValue(1)]
        public StatusEnum Status { get; set; }
        [JsonProperty("ProductAddedDate")]
        public DateTimeOffset AddedDate { get; set; }
        [JsonIgnore]
        public bool? IsDeleted { get; set; }
    }
}
