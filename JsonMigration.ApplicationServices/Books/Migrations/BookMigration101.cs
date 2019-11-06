using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using JsonMIgration.Lib.JsonMigrations;
using JsonMIgration.Lib.Migrations.MigrationOperations;
using Semver;

namespace JsonMIgration.Lib.Repositories
{
    public class BookMigration101 : IJsonMigration
    {
        public SemVersion Version => new SemVersion(major: 1, minor: 0, patch: 1);
        private List<IMigrationOperation> _migrations; 

        public BookMigration101()
        {
            _migrations = new List<IMigrationOperation>()
            {
                new AddOperation("FieldV2", "Field2 Default Value")
            };
        }
        public Result<string> Migrate(string json)
        {
            var updatedJson = json;
            //Go through each operation in the list and then do any custom stuff if necessary.
            foreach (var migration in _migrations)
            {
                updatedJson = migration.Apply(updatedJson);
            }

            //Any custom stuff could go here.

            return Result.Ok(updatedJson);
        }
    }
}
