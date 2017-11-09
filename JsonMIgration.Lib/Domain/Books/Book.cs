using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonMIgration.Lib.Domain.Books
{
    public class Book
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public string NewFieldV2 { get; private set; }

        private List<Chapter> _chapters = new List<Chapter>();
        public IEnumerable<Chapter> Chapters => _chapters;

        public Book(int id, string name, string newFieldV2)
        {
            Id = id;
            Name = name;
            NewFieldV2 = newFieldV2;
        }

        public void AddChapter(Chapter chapter)
        {
            _chapters.Add(chapter);
        }
    }
}
