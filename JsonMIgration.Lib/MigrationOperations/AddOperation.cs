using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Migrations.MigrationOperations
{
    public class AddOperation : IMigrationOperation
    {
        public string Field { get; private set; }
        public string DefaultValue { get; private set; }

        public AddOperation(string field, string defaultValue)
        {
            Field = field;
            DefaultValue = defaultValue;
        }

        public string Apply(string jsonString)
        {
            var jObject = JObject.Parse(jsonString);
            jObject.Add(Field, DefaultValue); 
            return jObject.ToString();
        }
    }
}
