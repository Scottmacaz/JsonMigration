using CSharpFunctionalExtensions;
using Semver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Repositories
{
    public interface IJsonMigration
    {
        SemVersion Version { get; }
        Result<string> Migrate(string json);
    }
}
