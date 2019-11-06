using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Migrations.MigrationOperations
{
    public class RenameOperation : IMigrationOperation
    {
        public string CurrentFieldName { get; private set; }
        public string NewFieldName { get; private set; }

        public RenameOperation(string currentFieldName, string newFieldName)
        {
            CurrentFieldName = currentFieldName;
            NewFieldName = newFieldName;
        }

        public string Apply(string jsonString)
        {
            var jObject = JObject.Parse(jsonString);
            var fieldValue = jObject[CurrentFieldName];
            jObject.Remove(CurrentFieldName);
            jObject[NewFieldName] = fieldValue;
            return jObject.ToString();
        }
    }
}
