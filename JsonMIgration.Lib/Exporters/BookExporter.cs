using JsonMIgration.Lib.Protocols;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Exporters
{
    public class BookExporter
    {
        private const int CurrentVersion = 2;
        public string ExportToJson(Book book)
        {
            JObject jObject = JObject.FromObject(book);
            jObject.Add("Version", CurrentVersion); //Add the version to the json
            return jObject.ToString();
        }
    }
}
