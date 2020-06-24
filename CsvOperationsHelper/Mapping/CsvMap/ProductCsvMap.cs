using System.Globalization;
using CsvHelper.Configuration;
using CsvOperationsHelper.Data.Models;

namespace CsvOperationsHelper.Mapping.CsvMap
{
    public sealed class ProductCsvMap : ClassMap<Product>
    {
        public ProductCsvMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            References<GroupCsvMap>(m => m.Group);
        }
    }
}

