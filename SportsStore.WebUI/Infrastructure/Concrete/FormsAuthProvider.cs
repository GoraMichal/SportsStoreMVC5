using System.Web.Security;
using SportsStore.WebUI.Infrastructure.Abstract;

namespace SportsStore.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        [System.Obsolete]
        public bool Authenticate(string username, string password)
        {
            //Stary sposob uwierzytelniania (niepolecany)
            bool result = FormsAuthentication.Authenticate(username, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }
            return result;
        }

    }
}

//Jeszcze trzeba zarejestrować FormsAuthProvider w metodzie AddBindings w NinjectDependencyResolver