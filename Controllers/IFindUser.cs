﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPackage
{
    interface IUserFinder
    {
        User findUser(string email);
    }
}
