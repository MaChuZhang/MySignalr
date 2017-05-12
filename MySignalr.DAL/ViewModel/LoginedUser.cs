using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySignalr.DAL
{
    public class LoginedUser
    {
        public int AccountId { get; set; }
        
        public string Account { get; set; }
        public string Ip { get; set; }
    }
}
