﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class CurrentUser
    {
        public static int UserID { get; set; }
        public static int RoleID { get; set; }
        public static string UserLogin { get; set; }
        public static string UserPassword { get; set; }
    }
}
