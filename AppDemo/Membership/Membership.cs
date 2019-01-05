using SEP_framwork.Controllers.HandleController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo.Membership
{
    public class Member
    {
        private HandleController controller;

        public Member(string cnnString)
        {
            controller = new HandleController(cnnString);
            controller.createSessionTable();
        }

        public bool Login(string username, string password)
        {
            if (controller.Login(username, password))
            {
                return true;
            }
            return false;
        }

        public bool Register(string username, string password)
        {
            if (controller.Register(username, password))
            {
                return true;
            }
            return false;
        }

        public bool Logout(string username)
        {
            if (controller.Logout(username))
            {
                return true;
            }
            return false;
        }
    }
}
