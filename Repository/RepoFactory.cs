using Repository.Auth;
using Repository.Library;

namespace Repository
{
    public static class RepoFactory
    {
        public static IAuthentication GetAuthenticationObject()
        {
            return new Authentication();
        }

        public static IBookModule GetBookModuleObject()
        {
            return new BookModule();
        }
    }
}
