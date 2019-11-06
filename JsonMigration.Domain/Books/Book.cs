using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMigration.Domain.Books
{
    //The current version of the software in this example would be 1.0.4.
    //there are sample JSON files in the test method for versions 1.0.0, 1.0.1, and 1.0.2, and 1.0.3
    public class Book
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        //This field was added in version 1.0.2 as NewFieldV2 and then renamed in 1.0.3 to FieldV3
        public string FieldV3 { get; private set; }

        public int FieldV4 { get; private set; }
        public string FieldV4B { get; private set; }

        private List<Chapter> _chapters = new List<Chapter>();
        public IEnumerable<Chapter> Chapters => _chapters;

        public Book(int id, string name, string fieldV3, int fieldV4, string fieldV4B)
        {
            Id = id;
            Name = name;
            FieldV3 = fieldV3;
            FieldV4 = fieldV4;
            FieldV4B = fieldV4B;
        }

        public void AddChapter(Chapter chapter)
        {
            _chapters.Add(chapter);
        }
    }
}
