using FluentAssertions;
using JsonMIgration.Lib.Exporters;
using JsonMIgration.Lib.JsonMigrations;
using JsonMIgration.Lib.Protocols;
using JsonMIgration.Lib.Repositories;
using System.Collections.Generic;
using Xunit;

namespace JsonMigration.Tests
{
    public class JsonMigratorShould
    {
        [Fact]
        public void MigrateBooksFromVersion1ToVersion2()
        {
            //Arrange
            var migrationRepository = new BookMigrationRepository();
            var migrator = new JsonFileMigrator<Book>(migrationRepository);

            //Act
            var book = migrator.Migrate(_bookVersion1Json, 2);

            //Assert
            //The default value for the new field as set in the AddOperation in the BookMigrationRepository
            book.NewFieldV2.Should().Contain("Some Default Value");  
        }

        [Fact]
        public void MigrateBooksFromVersion1ToVersion3()
        {
            var migrationRepository = new BookMigrationRepository();
            var migrator = new JsonFileMigrator<Book>(migrationRepository);
            var book = migrator.Migrate(_bookVersion1Json, 3);
        }
        
        [Fact]
        public void MakeExport()
        {
            var book = new Book(1, "Moby Dick", "Some New Value");
            book.AddChapter(new Chapter(1, "Introduction"));
            book.AddChapter(new Chapter(2, "Preparations"));
            book.AddChapter(new Chapter(3, "Going Fishin'"));
            var exporter = new BookExporter();
            var json = exporter.ExportToJson(book);
        }

        private string _bookVersion1Json =
            @"{
              'Id': 1,
              'Name': 'Moby Dick',
              'Chapters': [
                {
                  'Name': 'Introduction',
                  'Number': 1
                },
                {
                  'Name': 'Preparations',
                  'Number': 2
                },
                {
                  'Name': 'Going Fishing',
                  'Number': 3
                }
              ],
              'Version': 1
            }";
        

        private string _version2Json =
             @"{
              'Id': 1,
              'Name': 'Moby Dick',
              'NewFieldV2': 'Some New Value',
              'Chapters': [
                {
                  'Name': 'Introduction',
                  'Number': 1
                },
                {
                  'Name': 'Preparations',
                  'Number': 2
                },
                {
                  'Name': 'Going Fishing',
                  'Number': 3
                }
              ],
              'Version': 2
            }";

        private string _version3Json = @"            ";
    }
}
