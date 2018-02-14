using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class InjectionController : BaseController
    {
        public ActionResult Index()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd = new SqlCommand("", sqlConnection))
                    {
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}