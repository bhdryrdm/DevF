using DevF_LABS.RequestResponse;
using DevF_LABS.RequestResponse.Injection.SQLInjection;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class InjectionController : BaseController
    {
        public ActionResult Index() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SQLI_S1_Login(SQLI_S1_LoginRequest request) // İstek yapılan Request
        {
            SQLUser user = new SQLUser(); // Kullanıcıya dönülecek response 
            string sqlQuery = request.ORM_Control ?  // Request üzerinden gelen ORM kontrolüne göre SQL sorgusu belirlenir
                              "SELECT * FROM SQLInjection_User WHERE Username=@Username AND Password=@Password" :
                              $"SELECT * FROM SQLInjection_User WHERE Username=N'{request.Username}' AND Password=N'{request.Password}'";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString)) // Veritabanı bağlantısı hazırlanır ve using ile kilitlenir.
                {
                    sqlConnection.Open(); // Veritabanı bağlantısı açılır.
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection)) // Hazırlanan SQL sorgusu veritabanı bağlantısı ile birlikte sorgulanır
                    {

                        if (request.ORM_Control) // ORM kontrolüne göre veriler parametre olarak eklenir
                        {
                            SqlParameter sqlParameter = new SqlParameter();

                            // ADO.Net Parametre Ekleme I.Yol
                            sqlParameter.ParameterName = "@Username";
                            sqlParameter.Value = request.Username;
                            cmd.Parameters.Add(sqlParameter);

                            // ADO.Net Parametre Ekleme II.Yol
                            cmd.Parameters.AddWithValue("@Password", request.Password);
                        }


                        using (SqlDataReader reader = cmd.ExecuteReader()) // Hazırlanan SQL sorgusu çalıştırılır
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
            catch (Exception)
            {
                user.Message = "Hata oluştu";
                user.ResponseCode = 500;
            }

            return Json(user);
        }

        public class SQLUser : BaseResponse
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}