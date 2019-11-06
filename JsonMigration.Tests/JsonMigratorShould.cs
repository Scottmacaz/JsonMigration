using JsonMIgration.Lib.Repositories;
using Xunit;

namespace JsonMigration.Tests
{
    public class JsonMigratorShould
    {
        //[Fact]
        //public void MigrateBooksFromVersion_1_0_0_0_ToCurrent()
        //{
        //    //Arrange
        //    var migrationRepository = new BookMigrationRepository();
        //    var migrator = new JsonFileMigrator<Book>(migrationRepository);

        //    //Act
        //    var version = JsonHelpers.GetSemVersionFromJson(_bookVersion_1_0_0_Json);
        //    var book = migrator.Migrate(_bookVersion_1_0_0_Json, version);

        //    //Assert
        //    //The default value for the new field as set in the AddOperation in the BookMigrationRepository
        //    //book.FieldV3.Should().Contain("Some Default Value");  
        //}

        //[Fact]
        //public void MigrateBooksFromVersion_1_0_1_ToCurrent()
        //{
        //    var migrationRepository = new BookMigrationRepository();
        //    var migrator = new JsonFileMigrator<Book>(migrationRepository);

        //    var version = JsonHelpers.GetSemVersionFromJson(_bookVersion_1_0_1_Json);
        //    var book = migrator.Migrate(_bookVersion_1_0_1_Json, version);
        //}

        //[Fact]
        //public void MigrateBooksFromVersion_1_0_2_ToCurrent()
        //{
        //    var migrationRepository = new BookMigrationRepository();
        //    var migrator = new JsonFileMigrator<Book>(migrationRepository);

        //    var version = JsonHelpers.GetSemVersionFromJson(_bookVersion_1_0_2_Json);
        //    var book = migrator.Migrate(_bookVersion_1_0_2_Json, version);
        //}

        //[Fact]
        //public void MigrateBooksFromVersion_1_0_3_ToCurrent()
        //{
        //    var migrationRepository = new BookMigrationRepository();
        //    var migrator = new JsonFileMigrator<Book>(migrationRepository);

        //    var version = JsonHelpers.GetSemVersionFromJson(_bookVersion_1_0_3_Json);
        //    var book = migrator.Migrate(_bookVersion_1_0_3_Json, version);
        //}

        [Fact]
        public void MigrateBooksFromCurrentToCurrent()
        {
            var bookMigrator = new BookMigrator();
            var migrationResult = bookMigrator.Migrate(_bookVersion_1_0_0_Json);
            if (migrationResult.IsFailure)
            {
                throw new System.Exception("Convert failed!");
            }
            var book = migrationResult.Value;            
        }

        //[Fact]
        //public void MakeExport()
        //{
        //    var book = new Book(1, "Moby Dick", "Some New Value");
        //    book.AddChapter(new Chapter(1, "Introduction"));
        //    book.AddChapter(new Chapter(2, "Preparations"));
        //    book.AddChapter(new Chapter(3, "Going Fishin"""));
        //    var exporter = new BookExporter();
        //    var json = exporter.ExportToJson(book);
        //}


        private string _bookVersion_1_0_0_Json =
            @"{
              ""Id"": 1,
              ""Name"": ""Moby Dick"",
              ""Chapters"": [
                {
                  ""Name"": ""Introduction"",
                  ""Number"": 1
                },
                {
                  ""Name"": ""Preparations"",
                  ""Number"": 2
                },
                {
                  ""Name"": ""Going Fishing"",
                  ""Number"": 3
                }
              ],
              ""Version"": ""1.0.0""
            }";

        private string _bookVersion_1_0_1_Json =
            @"{
              ""Id"": 1,
              ""Name"": ""Moby Dick"",
              ""FieldV2"": ""FieldV2 Value"",
              ""Chapters"": [
                {
                  ""Name"": ""Introduction"",
                  ""Number"": 1
                },
                {
                  ""Name"": ""Preparations"",
                  ""Number"": 2
                },
                {
                  ""Name"": ""Going Fishing"",
                  ""Number"": 3
                }
              ],
              ""Version"": ""1.0.1""
            }";


        private string _bookVersion_1_0_2_Json =
             @"{
              ""Id"": 1,
              ""Name"": ""Moby Dick"",
              ""FieldV2"": ""Some FieldV2 Value"",
              ""V102FieldRemovedInV4"": ""Removed in V4"",
              ""Chapters"": [
                {
                  ""Name"": ""Introduction"",
                  ""Number"": 1
                },
                {
                  ""Name"": ""Preparations"",
                  ""Number"": 2
                },
                {
                  ""Name"": ""Going Fishing"",
                  ""Number"": 3
                }
              ],
              ""Version"": ""1.0.2""
            }";

        private string _bookVersion_1_0_3_Json =
            @"{
              ""Id"": 1,
              ""Name"": ""Moby Dick"",
              ""FieldV2"": ""FieldV2 Value"",
              ""V102FieldRemovedInV4"": ""Removed in V4"",
              ""FieldV3"": ""FieldV3 Value"",
              ""Chapters"": [
                {
                  ""Name"": ""Introduction"",
                  ""Number"": 1
                },
                {
                  ""Name"": ""Preparations"",
                  ""Number"": 2
                },
                {
                  ""Name"": ""Going Fishing"",
                  ""Number"": 3
                }
              ],
              ""Version"": ""1.0.3""
            }";

        private string _bookVersion_1_0_4_Json =
            @"{
              ""Id"": 1,
              ""Name"": ""Moby Dick"",
              ""FieldV4B"": ""This is FieldV4B"",
              ""FieldV3"": ""FieldV3 Value"",
              ""Chapters"": [
                {
                  ""Name"": ""Introduction"",
                  ""Number"": 1
                },
                {
                  ""Name"": ""Preparations"",
                  ""Number"": 2
                },
                {
                  ""Name"": ""Going Fishing"",
                  ""Number"": 3
                }
              ],
              ""Version"": ""1.0.4""
            }";
    }
}
