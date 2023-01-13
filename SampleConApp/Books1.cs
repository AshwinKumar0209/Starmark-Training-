using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Books1
    {
        class BookLibrary
        {
            public int BookId { get; set; }
            public string BookName { get; set; }
            public string BookAuthor { get; set; }
        }

        class BookCount
        {
            private BookLibrary[] _bookLibrary = null;
            private int _size = 0;

            public BookCount(int size)
            {
                _size = size;
                _bookLibrary = new BookLibrary[_size];
            }

            public void AddBook(BookLibrary boo)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_bookLibrary[i] == null)
                    {
                        _bookLibrary[i] = new BookLibrary { BookId = boo.BookId, BookName = boo.BookName };
                        return;
                    }
                }
            }

            public void UpdateBook(BookLibrary boo)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_bookLibrary[i] != null && _bookLibrary[i].BookId == boo.BookId)
                    {
                        _bookLibrary[i] = new BookLibrary { BookId = boo.BookId, BookName = boo.BookName, BookAuthor = boo.BookAuthor };
                        return;
                    }
                }
                throw new Exception("No book found to Update");
            }


            public void RemoveBook(int id)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_bookLibrary[i] != null && _bookLibrary[i].BookId == id)
                    {
                        _bookLibrary[i] = null;
                        return;
                    }
                }
                throw new Exception("Book ID is Not Found to Delete");
            }

            public void FindBook(int id)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_bookLibrary[i] != null && _bookLibrary[i].BookId == id)
                    {
                        Console.WriteLine(_bookLibrary[i]);
                        return;
                    }

                }

            }
        }

        class UIComponents
        {
            public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~BOOK STORE MANAGER SOFTWARE~~~~~~~~~~~~~~~~~~~\nTO ADD NEW BOOK------------------------>PRESS 1\nTO UPDATE EXISTING BOOK---------------->PRESS 2\nTO Delete BOOK BY ID---------------->PRESS 3\nTO FIND BOOK BY ID--------------------->PRESS 4\nTO DELETE BOOK------------------------->PRESS 5\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT.....................................";

            public static void Run()
            {

                int size = utilities.GetNumber("ENter the size of array");
                BookCount boo = new BookCount(size);
                bool processing = true;
                do
                {
                    int option = utilities.GetNumber(menu);
                    processing = processMenu(option);
                } while (processing);


                Console.WriteLine("THANKS FOR USING OUR APPLICATION");

                bool processMenu(int option)
                {
                    switch (option)
                    {
                        case 1:
                            AddingBook();
                            break;
                        case 2:
                            UpdatingBook();
                            break;
                        case 3:
                            RemovingBook();
                            break;
                        case 4:
                            FindingBook();
                            break;
                        default:
                            return false;

                    }
                    return true;
                }
                void AddingBook()
                {
                    try
                    {
                        int id = utilities.GetNumber("Enter Id");
                        string name = utilities.Prompt("Enter name");
                        string author = utilities.Prompt("Enter author");
                        BookLibrary obj = new BookLibrary { BookName = name, BookAuthor = author, BookId = id };
                        Console.WriteLine("Book Added Successfully");
                        boo.AddBook(obj);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }



                }
                void UpdatingBook()
                {
                    try
                    {
                        int id = utilities.GetNumber("ENter BOOk id to update");
                        string name = utilities.Prompt("Enter name");
                        string author = utilities.Prompt("Enter author");
                        BookLibrary obj = new BookLibrary { BookName = name, BookAuthor = author, BookId = id };
                        Console.WriteLine("Book Updated Successfully");
                        boo.UpdateBook(obj);

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                void RemovingBook()
                {
                    try
                    {
                        int id = utilities.GetNumber("ENter BOOk id to Delete");
                        boo.RemoveBook(id);
                        Console.WriteLine("Book Deleted Succesfully");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

                }
                void FindingBook()
                {
                    try
                    {
                        int id = utilities.GetNumber("Enter the book Id");
                         boo.FindBook(id);
                        

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }

    



            public static void Main(string[] args)
            {

                UIComponents.Run();


            }
        
  }  
}


