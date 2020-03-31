using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Infrastructure.Abstract
{
    //Interfejs do oddzielenia kontrolera od metod statycznych FormsAuth.
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}