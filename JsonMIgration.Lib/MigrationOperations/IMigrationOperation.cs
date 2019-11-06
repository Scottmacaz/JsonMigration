using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Migrations.MigrationOperations
{
    public interface IMigrationOperation
    {

        /// <summary>
        /// Applies the migration operation to the json string.
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns>the jsonString with the updates applied.</returns>
        string Apply(string jsonString);
        
    }

    
}
