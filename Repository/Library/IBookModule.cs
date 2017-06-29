using DomainLayer.Models;
using System.Collections.Generic;

namespace Repository.Library
{
    public interface IBookModule
    {
        string IssueBook(BookHistoryModel obj);

        string ReturnBook(int retID);

        string AddBook(BookModel bookObj);

        string RemoveBook(int bookID);

        IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled);
        IEnumerable<BookModel> SearchBook(string _searchArg);
    }
}
