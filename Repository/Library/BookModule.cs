using DomainLayer;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Library
{
    internal class BookModule : IBookModule
    {
        public string AddBook(BookModel bookObj)
        {
            try
            {
                StaticDatabase._booksList.Add(bookObj);

                return StringLiterals.SuccesMsg;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled)
        {
            try
            {
                if (isIncludeDisabled)
                {
                    return StaticDatabase._booksList;
                }

                return StaticDatabase._booksList.Where(m => m.IsActive == true);
            }
            catch
            {
                throw;
            }
        }

        public string IssueBook(BookHistoryModel obj)
        {
            try
            {
                if (StaticDatabase._bookHistoryList.Any(m => m.BookID == obj.BookID && m.ReturnedAt == null))
                {
                    return StringLiterals.BookIsAssignedToUser;
                }

                StaticDatabase._bookHistoryList.Add(obj);
                return StringLiterals.SuccesMsg;
            }
            catch
            {
                throw;
            }
        }

        public string RemoveBook(int bookID)
        {
            try
            {
                BookModel bookObj = StaticDatabase._booksList.Where(m => m.BookID == bookID).FirstOrDefault();
                bookObj.IsActive = false;
                return StringLiterals.RemoveMsg;
            }
            catch
            {
                throw;
            }

            // add entry into history table
        }

        public void ReturnBook()
        {
            // access the list, get that record , fill the returned at
        }
    }
}
