using CSharpFunctionalExtensions;

namespace JsonMIgration.Lib.Repositories
{
    public interface IJsonMigrator<T> where T: class
    {
        Result<T> Migrate(string json);
    }
}