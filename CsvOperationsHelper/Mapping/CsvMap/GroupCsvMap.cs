using CsvHelper.Configuration;
using CsvOperationsHelper.Data.Models;

namespace CsvOperationsHelper.Mapping.CsvMap
{
    public sealed class GroupCsvMap : ClassMap<Group>
    {
        public GroupCsvMap()
        {
            Map(m => m.Id).Name("GroupId", "Id");
            Map(m => m.Name).Name("GroupName", "name");
        }
    }
}
