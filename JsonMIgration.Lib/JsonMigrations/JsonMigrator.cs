using JsonMIgration.Lib.Migrations;
using JsonMIgration.Lib.Migrations.MigrationOperations;
using JsonMIgration.Lib.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.JsonMigrations
{
    public class JsonFileMigrator<T> where T: class
    {
        private JsonMigrationRepository _migrationRepository;
        public JsonFileMigrator(JsonMigrationRepository migrationRepository)
        {
            _migrationRepository = migrationRepository;
        }

        public T Migrate(string jsonExport, int currentVersion)
        {
            var jObject = JObject.Parse(jsonExport);
            int version;
            var didParse = int.TryParse((string) jObject["Version"], out version);
            
            if (!didParse)
            {
                //would return result here ...
                throw new Exception("Unable to parse Version from json.");
            }

            var updatedJsonString = jsonExport;
            while (version < currentVersion)
            {
                var migration = _migrationRepository.GetMigration(version + 1);
                foreach (var migrationOperation in migration.MigrationOperations)
                {
                    updatedJsonString = migrationOperation.Apply(updatedJsonString);
                }
                version++;
            }
            return JsonConvert.DeserializeObject<T>(updatedJsonString);
        }
       
    }
}
