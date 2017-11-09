using JsonMIgration.Lib.JsonMigrations;
using JsonMIgration.Lib.Migrations.MigrationOperations;
using System.Collections.Generic;

namespace JsonMIgration.Lib.Repositories
{
    public class BookMigrationRepository : JsonMigrationRepository
    {
        public BookMigrationRepository()
        {
            CreateBookMigrationV2();
        }
               
        
        private void CreateBookMigrationV2()
        {
            var migration = new JsonMigration(2);
            migration.AddMigrationOperation(new AddOperation("NewFieldV2", "Some Default Value"));
            _migrationDictionary.Add("2", migration);
        }
        
        
    }
}
