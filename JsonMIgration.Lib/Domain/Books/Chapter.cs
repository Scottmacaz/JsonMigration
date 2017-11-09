namespace JsonMIgration.Lib.Domain.Books
{
    public class Chapter
    {
        public string Name { get; private set; }
        public int Number { get; private set; }

        
        //CreationDate
        //Status

        public Chapter(int number, string name)
        {
            Name = name;
            Number = number;
        }
    }
}