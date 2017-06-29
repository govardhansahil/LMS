using DomainLayer.Models;

using Repo = Repository.Auth;

namespace BusinessLayer.Auth
{
    internal class Authentication : IAuthentication
    {
        Repo.IAuthentication _authObj;

        public Authentication()
        {
            _authObj = Repository.RepoFactory.GetAuthenticationObject();
        }

        public bool Authenticate(AuthModel obj)
        {
            return _authObj.Authenticate(obj);
        }
        public string Register(UserModel obj)
        {
            return _authObj.Register(obj);
        }
    }
}