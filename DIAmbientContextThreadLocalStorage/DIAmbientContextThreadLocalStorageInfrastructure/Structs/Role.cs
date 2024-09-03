using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAmbientContextThreadLocalStorageInfrastructure.Structs
{
    public static class Role
    {
        private const string ROLE_ADMIN = "ADMIN";

        private const string ROLE_VIEWER = "VIEWER";

        private const string ROLE_EDITOR = "EDITOR";

        public static string Admin => ROLE_ADMIN;

        public static string Viewer => ROLE_VIEWER;

        public static string Editor => ROLE_EDITOR;

        public static bool IsAdmin(string roleName) => roleName == ROLE_ADMIN;
    }
}
