using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySignalr.DAL.DbModels;
namespace MySignalr.DAL
{
    public class accessDb
    {
       
        public static bool checkLogin(string account ,string  pwd)
        {
            using (var db = new DbEntities())
            {
                var obj = db.UserInfo.FirstOrDefault(p => p.Account == account && p.PassWord == pwd);
                if (obj != null)
                {
                    return true;
                }
                else
                    return false;
            }
        }

    }
}
