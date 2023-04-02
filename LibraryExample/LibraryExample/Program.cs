namespace LibraryExample
{
    internal class Program
    {
        interface BookMethods
        {
            void AddBook(Book book) { }
            void RemoveBook(Book book) { }
        }

        public abstract class Book
        {
            public string Name { get; set; }
            //public string Title { get; set; }
            protected int ID { get; set; }
            public Book(string Name)
            {
                this.Name = Name;
            }
            public abstract void GenerateID();
        }

        internal class Library : Book, BookMethods
        {
            const int MaxBooks = 2;
            public int CurrentCount { get; set; }
            public List<Book> Books_list = new List<Book>();
            public Library(string Name) : base(Name) { }
            public void Print()
            {
                foreach (var k in Books_list)
                {
                    Console.WriteLine(k);
                }
            }
            public void AddBook(Book book)
            {
                if (CurrentCount >= MaxBooks)
                {
                    Console.WriteLine("Cant");
                }
                Books_list.Add(book);
                CurrentCount++;
            }
            public void RemoveBook(Book book)
            {
                Books_list.Remove(book);
                CurrentCount--;
            }
            public override void GenerateID()
            {
                Random rnd = new Random();
                ID = rnd.Next();
                Console.WriteLine(ID);
            }
        }
        static void Main(string[] args)
        {
            Book book1 = new Library("Book1");
            book1.GenerateID();
            Book book2 = new Library("Book2");
            book1.GenerateID();
            //Book book3 = new Library("Book3");
            //Book book4 = new Library("Book4");
            Library book = new Library("Name1");
            book.AddBook(book1);
            book.AddBook(book2);
            Console.WriteLine(book.CurrentCount);
            //book.AddBook(book3);
            //book.AddBook(book4);
            book.Print();
            book.RemoveBook(book1);
            Console.WriteLine(book.CurrentCount);
            // book.RemoveBook(book2);
            book.Print();
        }
    }
}