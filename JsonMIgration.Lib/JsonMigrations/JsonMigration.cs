using JsonMIgration.Lib.Migrations.MigrationOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.JsonMigrations
{
    public class JsonMigration
    {
        public int Version { get; private set; }

        private List<IMigrationOperation> _migrationOperations = new List<IMigrationOperation>();
        public IEnumerable<IMigrationOperation> MigrationOperations => _migrationOperations;
        
        public JsonMigration(int version)
        {
            Version = version;
        }

        public void AddMigrationOperation(IMigrationOperation migrationOperation)
        {
            _migrationOperations.Add(migrationOperation);
        }
    }

    
}
