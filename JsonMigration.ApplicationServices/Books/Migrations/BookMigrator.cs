using CSharpFunctionalExtensions;
using JsonMigration.Domain.Books;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JsonMIgration.Lib.Repositories
{
    public class BookMigrator : IJsonMigrator<Book>
    {
        private List<IJsonMigration> _migrations; 
        public BookMigrator()
        {
            _migrations = new List<IJsonMigration>()
            {
                new BookMigration101(),
            };

            //CreateBookMigrationV101();
            //CreateBookMigrationV102();
            //CreateBookMigrationV103();
            //CreateBookMigrationV104();
        }
        
        public Result<Book> Migrate(string json)
        {
            var updatedJson = json;
            foreach (var migration in _migrations)
            {
                var result = migration.Migrate(updatedJson);
                if (result.IsFailure)
                {
                    return Result.Fail<Book>(result.Error);
                }
                updatedJson = result.Value;
            }

            return Result.Ok(JsonConvert.DeserializeObject<Book>(updatedJson));
        }
        //private void CreateBookMigrationV101()
        //{
        //    var migration = new JsonMigration(new SemVersion(major: 1, minor:0, patch: 1));
        //    migration.AddMigrationOperation(new AddOperation("FieldV2", "Field2 Default Value"));
            
        //    _migrations.Add(migration);
        //}

        //private void CreateBookMigrationV102()
        //{
        //    var migration = new JsonMigration(new SemVersion(major: 1, minor: 0, patch: 2));
        //    migration.AddMigrationOperation(new AddOperation("V102FieldRemovedInV4", "v101 Field Default Value"));
        //    _migrations.Add(migration);
        //}

        //private void CreateBookMigrationV103()
        //{
        //    var migration = new JsonMigration(new SemVersion(major: 1, minor: 0, patch: 3));
        //    migration.AddMigrationOperation(new AddOperation("FieldV3", "Field3 Default Value"));
        //    _migrations.Add(migration);
        //}

        //private void CreateBookMigrationV104()
        //{
        //    var migration = new JsonMigration(new SemVersion(major: 1, minor: 0, patch: 4));
        //    migration.AddMigrationOperation(new AddOperation("FieldV4", "42"));
        //    migration.AddMigrationOperation(new RemoveOperation("V102FieldRemovedInV4"));
        //    migration.AddMigrationOperation(new RenameOperation("FieldV2", "FieldV4B"));

        //    _migrations.Add(migration);
        //}

    }
}
