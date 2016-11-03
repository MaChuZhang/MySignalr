using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySignalr.DAL;
using MySignalr.DAL.DbModels;
using System.Data.Entity;
namespace MySignalr.WebUI.Controllers.API
{
    [RoutePrefix("api/user")]
    public class UserInfoController : ApiController
    {
        [Route("login"),HttpGet]
        public ApiResult<bool>  Login(string account ,string  pwd)
        {
            using (var db = new DbEntities())
            {
                var ret = db.UserInfo.FirstOrDefault(f => f.Account ==account && f.PassWord ==pwd);
                if (ret != null)
                {
                    return ApiResult.Ok(true);
                }
                else
                {
                    return  ApiResult<bool>.Error("密码错误请重新登录");

                    //return ApiResult<bool>.Error("密码错误请重新登录");
                }
            }
        }
    }
}
