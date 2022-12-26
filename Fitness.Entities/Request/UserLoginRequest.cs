using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.Entities.Request
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
