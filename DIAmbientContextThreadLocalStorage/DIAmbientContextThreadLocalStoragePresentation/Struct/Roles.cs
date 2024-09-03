using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIAmbientContextThreadLocalStoragePresentation.Struct
{
    public struct Roles
    {
        private const string ADMIN = "ADMIN";

        private const string MANAGER = "MANAGER";

        private const string VIEWER = "VIEWER";

        public static string Admin => ADMIN;

        public static string Manager => MANAGER;

        public static string Viewer => VIEWER;
    }
}