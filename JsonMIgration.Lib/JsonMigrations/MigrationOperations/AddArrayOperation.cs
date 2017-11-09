using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Migrations.MigrationOperations
{
    public class AddArrayOperation : IMigrationOperation
    {
        object[] _array;
        string _fieldName;

        public AddArrayOperation(string fieldName, object[] array)
        {
            _array = array;
            _fieldName = fieldName;
        }
        public string Apply(string jsonString)
        {
            var jObject = JObject.Parse(jsonString);
            JArray jArray = new JArray();
            foreach (var arrayItem in _array)
            {
                jArray.Add(arrayItem);
            }
            jObject.Add(_fieldName, jArray);
            return jObject.ToString();
        }
    }
}
