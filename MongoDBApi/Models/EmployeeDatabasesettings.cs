using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBApi.Models
{
    public class EmployeeDatabasesettings : IEmployeeDatabaseSettings
    {
        public string EmployeesCollectionName { get ; set; }
        public string ConnectionString { get ;set ; }
        public string DatabaseName { get ; set; }
    }
    public interface IEmployeeDatabaseSettings
    {
        public string EmployeesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
