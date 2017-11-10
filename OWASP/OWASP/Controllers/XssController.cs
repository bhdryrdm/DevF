using OWASP.Models.Xss.ReflectedXss;
using OWASP_DB.MSSQL.EntityFramework.CodeFirst;
using OWASP_DB.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OWASP.Controllers
{
    public class XssController : BaseController
    {
        public ActionResult Index()
        {
            Session["LoginUserRole"] = "";
            return View("");
        }

        [HttpPost]
        public ActionResult RXSS_S3_Login(RXSS_S3_LoginRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                XSS_User user = dbContext.XSS_User.Where(x => x.Email == request.RXSS_S3_LoginRequest_Email && x.Password == request.RXSS_S3_LoginRequest_Password).FirstOrDefault();
                if(user != null)
                {
                    Session["LoginUserRole"] = user.UserRole;
                    response.LoginUser = user;
                    response.UserList = dbContext.XSS_User.ToList();
                }
            }
            return PartialView("~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
        }
        [HttpPost]
        public ActionResult RXSS_S3_Register(RXSS_S3_RegisterRequest request)
        {
            XSS_User user = new XSS_User
            {
                Email = request.RXSS_S3_RegisterRequest_Email,
                Password = request.RXSS_S3_RegisterRequest_Password,
                UserName = request.RXSS_S3_RegisterRequest_UserName,
                UserSurname = request.RXSS_S3_RegisterRequest_UserSurname,
                UserRole = "User",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            };
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                dbContext.XSS_User.Add(user);
                dbContext.SaveChanges();
                response.UserList = dbContext.XSS_User.ToList();
                Session["LoginUserRole"] = user.UserRole;
                response.LoginUser = user;
            }

            return PartialView("~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
        }

        [HttpPost]
        public ActionResult RXSS_S3_Delete(int userID)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                var user = dbContext.XSS_User.Where(x => x.UserID == userID && (x.Email != "admin@admin.com" || x.Email != "demo@admin.com")).FirstOrDefault();
                if (user != null && Session["LoginUserRole"].ToString() == "Admin")
                {
                    dbContext.XSS_User.Remove(user);
                    dbContext.SaveChanges();
                    response.UserList = dbContext.XSS_User.ToList();
                    response.Message = $"{userID}'ye sahip kullanıcı silindi!";
                }
                else
                {
                    response.Message = $"{userID}'ye sahip kullanıcı bulunamadı yada silinemeyen kullanıcı silmeye çalışıyorsunuz!";
                    response.IsSuccess = false;
                }
            }

            return PartialView("~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
        }
    }
}