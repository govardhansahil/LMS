using DomainLayer.Models;
using System.Collections.Generic;

using Repo = Repository.Library;
using System;

namespace BusinessLayer.Library
{
    internal class BookModule : IBookModule
    {
        Repo.IBookModule _bookObj;

        public BookModule()
        {
            _bookObj = Repository.RepoFactory.GetBookModuleObject();
        }

        public string AddBook(BookModel bookObj)
        {
            return _bookObj.AddBook(bookObj);
        }

        public IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled = false)
        {
            return _bookObj.GetAllBooks(isIncludeDisabled);
        }

        public string IssueBook(BookHistoryModel obj)
        {
            return _bookObj.IssueBook(obj);
        }

        public string RemoveBook(int bookID)
        {
            return _bookObj.RemoveBook(bookID);
        }

        public void ReturnBook()
        {
        }
    }
}
