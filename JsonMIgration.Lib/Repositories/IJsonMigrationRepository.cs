using JsonMIgration.Lib.JsonMigrations;
using System.Collections.Generic;

namespace JsonMIgration.Lib.Repositories
{
    public abstract class JsonMigrationRepository
    {
        protected Dictionary<string, JsonMigration> _migrationDictionary = new Dictionary<string, JsonMigration>();

        public JsonMigration GetMigration(int version)
        {
            return _migrationDictionary[version.ToString()];
        }
    }
}
