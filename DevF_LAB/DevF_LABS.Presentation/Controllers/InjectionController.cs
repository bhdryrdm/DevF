using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web.Mvc;
using DevF_LABS.RequestResponse.Injection.SQLInjection;
using DevF_LABS.RequestResponse;

namespace DevF_LABS.Presentation.Controllers
{
    public class InjectionController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SQLI_S1_Login(SQLI_S1_LoginRequest request)
        {
            SQLUser user = new SQLUser();
            string sqlQuery = $"SELECT * FROM SQLInjection_User WHERE Username=@Username AND Password=@Password";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        
                        SqlParameter sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = "@Username";
                        sqlParameter.Value = request.Username;
                        cmd.Parameters.Add(sqlParameter);

                        cmd.Parameters.AddWithValue("@Password", request.Password);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    user.Username = reader.GetString(1);
                                    user.Password = reader.GetString(3);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                user.Message = "Hata oluştu";
                user.ResponseCode = 500;
            }
            return Json(user,JsonRequestBehavior.AllowGet);
        }

        public class SQLUser : BaseResponse
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}