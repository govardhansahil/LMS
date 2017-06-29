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
                bookObj.BookID=StaticDatabase._booksList.Count+1;
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
                else
                {
                StaticDatabase._bookHistoryList.Add(obj);
                BookModel _issueupdate=StaticDatabase._booksList.Where(m=>m.BookID==obj.BookID).FirstOrDefault();
                if(_issueupdate.IsActive==true && _issueupdate.NumberOfBooks>0)
                {
                    _issueupdate.NumberOfBooks-=_issueupdate.NumberOfBooks;
                }
                else _issueupdate.IsActive=false;

                return StringLiterals.SuccesMsg;
                }
            }
            catch
            {
                Console.WriteLine("\nInvalid UserId or BookID");
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

        public string ReturnBook(int retID)
        {
            try
            {
                BookHistoryModel _retRef=StaticDatabase._bookHistoryList.Where(m=>m.BookID==retID).FirstOrDefault();
                _retRef.Operation="Returned";
                _retRef.ReturnedAt=DateTime.Now;
                BookModel _update=StaticDatabase._booksList.Where(m=>m.BookID==retID).FirstOrDefault();
                if(_update.IsActive==false)
                _update.IsActive=true;
                _update.NumberOfBooks+=_update.NumberOfBooks;
                
                return StringLiterals.ReturnedMsg;
            }
            catch
            {
                throw;
            }
            // access the list, get that record , fill the returned at
        }
        public IEnumerable<BookModel> SearchBook(string _searchArg)
        {
            try
            {  
                List<BookModel> retList=new List<BookModel>();
                foreach(BookModel srchObj in StaticDatabase._booksList.Where(m=>Convert.ToString(m.BookID)==_searchArg || m.Name.Contains(_searchArg)))
                {
                    retList.Add(srchObj);
                }
                return retList;
            }
            catch
            {
                throw;
            }


        }
    }
}
