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
            Console.WriteLine("Welcome to Library!\n" +
                "Select the choice of operation\n\n" +
                "1. Add Book\n" +
                "2. Issue Book\n" +
                "3. Return Book\n" +
                "4. Remove Book\n" +
                "5. Get All Books\n"+
                "6. Log Out\n");
            Console.Write("Enter choice :");
            choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    BookModel newBook = new BookModel();
                    Console.WriteLine("Enter the Book details");
                    Console.Write("Book ID: ");
                    newBook.BookID = Int32.Parse(Console.ReadLine());
                    Console.Write("Book Name: ");
                    newBook.Name = Console.ReadLine();
                    Console.Write("Book Author: ");
                    newBook.AuthorName = Console.ReadLine();
                    Console.Write("Department: ");
                    newBook.Department = Console.ReadLine();
                    newBook.IsActive = true;
                    BookChoice.AddBook(newBook);
                    break;
                case 2:
                    BookHistoryModel issueInfo = new BookHistoryModel();
                    Console.WriteLine("Enter issuing details\n");
                    Console.Write("Book ID: ");
                    issueInfo.BookID = Int32.Parse(Console.ReadLine());
                    Console.Write("User ID: ");
                    issueInfo.UserID = Int32.Parse(Console.ReadLine());
                    Console.Write("Issue Time: ");
                    issueInfo.OperationPerformedAt = DateTime.Now;
                    Console.WriteLine(issueInfo.OperationPerformedAt);
                    Console.Write("Return Date: ");
                    issueInfo.ReturnedAt = DateTime.Now.AddDays(30);
                    Console.WriteLine(issueInfo.ReturnedAt);
                    Console.Write("Remarks: ");
                    issueInfo.Remarks = Console.ReadLine();
                    Console.Write("Issuing Authority ID: ");
                    issueInfo.PerformedByID = Int32.Parse(Console.ReadLine());
                    string _issuemsg=BookChoice.IssueBook(issueInfo);
                    Console.WriteLine(_issuemsg);
                    break;
                case 3:
                    break;
                case 4:
                    Console.WriteLine("Enter Book ID: ");
                    int _removeID = Int32.Parse(Console.ReadLine());
                    string _removemsg=BookChoice.RemoveBook(_removeID);
                    Console.WriteLine(_removemsg);
                    break;
                case 5:
                    IEnumerable<BookModel> BookList = BookChoice.GetAllBooks(true);
                    foreach (BookModel item in BookList) {
                        Console.WriteLine("Book ID: {0}\n" +
                            "Book Name: {1}\n" +
                            "Author: {2}\n" +
                            "Department: {3}\n",item.BookID,item.Name,item.AuthorName,item.Department);
                    }
                    break;
                case 6:
                    Console.WriteLine("Signing Out...");
                    return 1;

            } return 0;
            
        }

        
    }
}
