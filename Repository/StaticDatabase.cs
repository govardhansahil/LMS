using DomainLayer.Models;
using System.Collections.Generic;

namespace Repository
{
    internal static class StaticDatabase
    {
        internal static List<BookModel> _booksList = new List<BookModel>()
        {
            new BookModel() {  BookID=1, Name="Book1", AuthorName="Author1", Department="IT", NumberOfBooks=5 ,IsActive=true   },
            new BookModel() {  BookID=2, Name="Book2", AuthorName="Author2", Department="IT", NumberOfBooks=10 ,IsActive=true   },
            new BookModel() {  BookID=3, Name="Book3", AuthorName="Author3", Department="CSE", NumberOfBooks=15 ,IsActive=false },
            new BookModel() {  BookID=4, Name="Book4", AuthorName="Author4", Department="IT", NumberOfBooks=5 ,IsActive=true },
            new BookModel() {  BookID=5, Name="Book5", AuthorName="Author1", Department="ECE" , NumberOfBooks=30 ,IsActive=false  }
        };

        internal static List<UserModel> _usersList = new List<UserModel>()
        {
            new UserModel() {  UserID=1, Name="User1", Email="Author1", IsActive=true, Password="Pwd1", IsAdmin=true   },
            new UserModel() {  UserID=2, Name="User2", Email="Author2", IsActive=true, Password="Pwd2"   },
            new UserModel() {  UserID=3, Name="User3", Email="Author3", IsActive=false, Password="Pwd3" },
            new UserModel() {  UserID=4, Name="User4", Email="Author4", IsActive=true, Password="Pwd4" },
            new UserModel() {  UserID=5, Name="User5", Email="Author5", IsActive=false, Password="Pwd5"  }
        };

        internal static List<BookHistoryModel> _bookHistoryList = new List<BookHistoryModel>()
        {
            new BookHistoryModel() {BookID=3, UserID=1507, Remarks="Important", PerformedByID=5505},
            new BookHistoryModel() {BookID=5, UserID=1508, Remarks="not Important", PerformedByID=5505},
        };
        

    }
}
