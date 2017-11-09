﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Migrations.MigrationOperations
{
    class DeleteOperation : IMigrationOperation
    {
        private string _fieldToDelete;
        public DeleteOperation(string fieldToDelete)
        {
            _fieldToDelete = fieldToDelete;
        }
        
        public string Apply(string jsonString)
        {
            var jObject = JObject.Parse(jsonString);
            jObject.Remove(_fieldToDelete);
            return jObject.ToString();
        }
    }
}
