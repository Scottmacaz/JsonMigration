
using JsonMIgration.Lib.Domain.Books;
using Newtonsoft.Json.Linq;

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
