﻿using DomainLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Library
{
    public interface IBookModule
    {
        string IssueBook(BookHistoryModel obj);

        void ReturnBook();

        string AddBook(BookModel bookObj);

        void RemoveBook(int bookID);

        IEnumerable<BookModel> GetAllBooks(bool isIncludeDisabled);
    }
}
