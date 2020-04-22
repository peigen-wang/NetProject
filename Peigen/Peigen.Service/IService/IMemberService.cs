﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Service
{
    public interface IMemberService
    {
        string GetUserName();
    }

    //简单容器
    public class MemberFactory
    {
        public static IMemberService GetFactory()
        {
            return new MemberService();
        }
    }
}
