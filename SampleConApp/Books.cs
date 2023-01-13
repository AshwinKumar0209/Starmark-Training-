using System;
using System.IO;

namespace SampleConApp
{
    class BookDetails
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string bookAuthor { get; set; }


    }
    class BookLibrary
    {
        private BookDetails[] _bookdetails = null;
        private int _size = 0;
        public BookLibrary(int size)
        {
            _size = size;
            _bookdetails = new BookDetails[_size];
        }

        public void AddBook(BookDetails boo)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_bookdetails[i] == null)
                {
                    _bookdetails[i] = new BookDetails { BookId = boo.BookId, BookName = boo.BookName, bookAuthor = boo.bookAuthor };
                    return;
                }
            }
        }


        public void UpdateBook(BookDetails boo)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_bookdetails[i] != null && _bookdetails[i].BookId == boo.BookId)
                {
                    _bookdetails[i].BookName = boo.BookName;
                    return;
                }
            }
            throw new Exception("Book is NOT AVAILABLE");
        }




    }
}

    //class Details
    //{
    //    private int Id;

    //    public int BookId
    //    {
    //        get { return Id; }
    //        set { Id = value; }
    //    }


    //    public string BookName
    //    {
    //        get { return BookName; }
    //        set { BookName = value; }
    //    }

    //    public string BookAuthor
    //    {
    //        get { return BookAuthor; }
    //        set { BookAuthor = value; }
    //    }
    //}

    //    class UIManager
    //{  static int size = utilities.GetAlldata("Enter the size");
    //    public static BookLibrary boo = new BookLibrary( size);
    //    internal static void DisplayMenu(string file)
    //    {
            
    //        bool processing = true;
    //        string menu = File.ReadAllText(file);
    //        do
    //        {
    //            int choice = utilities.GetAlldata(menu);
    //            processing = processMenu(choice);
    //        } while (processing);
    //        Console.WriteLine("Thanks for using our Application");
    //    }

    //    private static bool processMenu(int choice)
    //    {
    //        switch (choice)
    //        {
    //            case 1:
    //                addingBookHelper();
    //                break;
    //            case 2:
    //                updatingBookHelper();
    //                break;
    //            default:
    //                return false;
    //        }
    //        return true;
    //    }

    //    private static void addingBookHelper()
    //    {
    //        int id = utilities.GetAlldata("Enter Book ID ");
    //        Console.WriteLine("Enter the Book Name");
    //        string bName = Console.ReadLine();
    //        Console.WriteLine("Enter the Book's Author");
    //        string bAuthor = Console.ReadLine();
    //        BookDetails book = new BookDetails { BookId = id, BookName = bName, bookAuthor = bAuthor };
    //       boo.AddBook(book);
    //    }
    //    private static void updatingBookHelper()
    //    {
    //        int id = utilities.GetAlldata("Enter the ID of the Account to Update");
    //        Console.WriteLine("Enter the new Book Name");
    //        string name = Console.ReadLine();
    //        Console.WriteLine("Enter the Book Name");
    //        BookDetails obj = new BookDetails { BookId = id, BookName = name };
    //        boo.UpdateBook(obj);
    //        utilities.GetAlldata("Press Enter to clear the Screen");
    //        Console.Clear();
    //    }
    //}


    //class Books
    //{

    //    static void Main(string[] args)
    //    {
    //        BookDetails obj2 = new BookDetails { BookId = 3306, BookName = "Half Girlfriend", bookAuthor = "Chethan Bhagat" };
    //        Console.WriteLine("the name is " + obj2.BookName);
    //        //Adding book
    //        UIManager.DisplayMenu(args[0]);

    //        //Update book

    //        //{
           
    //        //}





//        }

//    }
//}
