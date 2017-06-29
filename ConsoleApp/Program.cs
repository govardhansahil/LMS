using BusinessLayer;
using BusinessLayer.Auth;
using BusinessLayer.Library;
using DomainLayer.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static bool result;
        static void Main(string[] args)
        {
            Console.Title="Library Management System";
            IAuthentication obj = BALFactory.GetAuthenticationObject();
            AuthModel argObj = new AuthModel();
Login:      Console.WriteLine("\nEnter Credentials:");
            Console.Write("Email: ");
            argObj.Email = Console.ReadLine();
            Console.Write("\nPassword: ");
            argObj.Password = Console.ReadLine();
            result = obj.Authenticate(argObj);
            if (result)
            {
                int iterer;
                do
                {
                    iterer=ChoiceSelect();
                } while (iterer != 1);
            }
            else
            {
                Console.WriteLine("Invalid Credentials!, Try Again");
                goto Login;
            }
            Console.WriteLine("Exiting Application...");

        }


        public static  int ChoiceSelect()
        {
            IBookModule BookChoice = BALFactory.GetBookModuleObject();
            int choice;
            Console.WriteLine("\nWelcome to Library!\n\n" +
                "Select the choice of operation\n\n" +
                "1. Add Book\n" +
                "2. Issue Book\n" +
                "3. Return Book\n" +
                "4. Remove Book\n" +
                "5. Get All Books\n"+
                "6. Search a Book\n"+
                "7. Log Out\n");
            Console.Write("Enter choice :");
            choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter the Book details");
                    Console.Write("Book ID: ");
                    int _bookID = Int32.Parse(Console.ReadLine());
                    Console.Write("Book Name: ");
                    string _bookName = Console.ReadLine();
                    Console.Write("Book Author: ");
                    string _bookAuthor = Console.ReadLine();
                    Console.Write("Department: ");
                    string _bookDept = Console.ReadLine();
                    Console.Write("Number of Books: ");
                    int _bookCount=Int32.Parse(Console.ReadLine());
                    for(int _loopAdd=0,_lastID=_bookID;_loopAdd<_bookCount;_loopAdd++,_lastID++)
                    {
                        BookChoice.AddBook(new BookModel{
                            BookID=_lastID,
                            Name=_bookName,
                            AuthorName=_bookAuthor,
                            Department=_bookDept,
                            NumberOfBooks=_bookCount,
                            IsActive=true
                        });
                    }
                    break;
                case 2:
                    Console.Clear();
                    BookHistoryModel issueInfo = new BookHistoryModel();
                    Console.WriteLine("Enter issuing details\n");
                    Console.Write("Book ID: ");
                    issueInfo.BookID = Int32.Parse(Console.ReadLine());
                    Console.Write("User ID: ");
                    issueInfo.UserID = Int32.Parse(Console.ReadLine());
                    Console.Write("Issue Time: ");
                    issueInfo.OperationPerformedAt = DateTime.Now;
                    Console.WriteLine(issueInfo.OperationPerformedAt);
                    Console.Write("Validity: ");
                    issueInfo.ReturnedAt = DateTime.Now.AddDays(30);
                    Console.WriteLine(issueInfo.ReturnedAt);
                    Console.Write("Remarks: ");
                    issueInfo.Remarks = Console.ReadLine();
                    Console.Write("Issuing Authority ID: ");
                    issueInfo.PerformedByID = Int32.Parse(Console.ReadLine());
                    issueInfo.Operation="Issued";
                    string _issuemsg=BookChoice.IssueBook(issueInfo);
                    Console.WriteLine(_issuemsg);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Enter the details of the book: ");
                    Console.Write("Book ID: ");
                    int _returnID=Int32.Parse(Console.ReadLine());
                    string _retMsg=BookChoice.ReturnBook(_returnID);
                    Console.WriteLine(_retMsg);

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Enter Book ID: ");
                    int _removeID = Int32.Parse(Console.ReadLine());
                    string _removemsg=BookChoice.RemoveBook(_removeID);
                    Console.WriteLine(_removemsg);
                    break;
                case 5:
                    Console.Clear();
                    bool _getList=false;
                    Console.WriteLine("1.List all books\n"+"2.List available books\n"+"Enter your choice: ");
                    int _listChoice=Int32.Parse(Console.ReadLine());
                    if(_listChoice==1) _getList=true; 
                    IEnumerable<BookModel> BookList = BookChoice.GetAllBooks(_getList);
                    foreach (BookModel item in BookList) {
                        Console.WriteLine("Book ID: {0}\n" +
                            "Book Name: {1}\n" +
                            "Author: {2}\n" +
                            "Department: {3}\n"+
                            "Number of books available: {4}",item.BookID,item.Name,item.AuthorName,item.Department,item.NumberOfBooks);
                    }
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("\nEnter BookID or Book Name: ");
                    string _searcharg=Console.ReadLine();
                    IEnumerable<BookModel> _srchList=BookChoice.SearchBook(_searcharg);
                    foreach(BookModel item in _srchList){
                        Console.WriteLine("\nBookID: {0}\n"+
                        "Book Name: {1}\n"+
                        "Author: {2}\n"+
                        "Department: {3}\n",item.BookID,item.Name,item.AuthorName,item.Department);
                    }
                    break;
                case 7:
                    Console.WriteLine("Signing Out...");
                    return 1;

            } return 0;
            
        }

        
    }
}
