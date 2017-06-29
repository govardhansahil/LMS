using DomainLayer;
using DomainLayer.Models;
using System.Linq;
using System;

namespace Repository.Auth
{
    internal class Authentication : IAuthentication
    {
        public bool Authenticate(AuthModel obj)
        {
            return StaticDatabase._usersList
            .Any(m => m.Email == obj.Email && m.Password == obj.Password
                   && m.IsAdmin == true && m.IsActive == true);
        }

        public string Register(UserModel obj)
        {
            obj.IsAdmin=false;
            obj.IsActive=true;
            obj.UserID=StaticDatabase._usersList.Count()+1;
            obj.Password=Convert.ToString(obj.UserID);
            StaticDatabase._usersList.Add(obj);
            return StringLiterals.RegisteredMsg;
        }
    }
}