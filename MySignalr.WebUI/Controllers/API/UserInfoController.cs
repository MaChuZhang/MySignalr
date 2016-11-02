using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySignalr.DAL;
namespace MySignalr.WebUI.Controllers.API
{
    [RoutePrefix("api/user")]
    public class UserInfoController : ApiController
    {
        public bool  Login(UserInfo model)
        {
            return true;
        }
    }
}
