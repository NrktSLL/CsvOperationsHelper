using System;
using CsvOperationsHelper.Data.Enums;
using CsvOperationsHelper.Data.Models;
using Newtonsoft.Json;

namespace CsvOperationsHelper.Data.Dto
{
    public class ProductDto
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
        public StatusEnum Status { get; set; }
        [JsonProperty("ProductAddedDate")]
        public DateTimeOffset AddedDate { get; set; } = DateTimeOffset.Now;
    }
}
