using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIAmbientContextThreadLocalStoragePresentation.App_Start
{
    public static class ServiceLocator
    {
        public static T GetService<T>()
        {
            return (T)DependencyResolver.Current.GetService(typeof(T));
        }
    }
}