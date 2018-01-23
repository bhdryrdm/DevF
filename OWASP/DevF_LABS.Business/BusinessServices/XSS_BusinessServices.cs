using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using DevF_LABS.RequestResponse.XSS.ReflectedXSS;
using System.Linq;

namespace DevF_LABS.Business.BusinessServices
{
    public class XSS_BusinessServices
    {
        public RXSS_S3_UserListResponse RXSS_S3_Login(RXSS_S3_LoginRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                XSS_User user = dbContext.XSS_User.Where(x => x.Email == request.RXSS_S3_LoginRequest_Email && x.Password == request.RXSS_S3_LoginRequest_Password).FirstOrDefault();
                if (user != null)
                {
                    //Session["LoginUserRole"] = user.UserRole;
                    //response.LoginUser = user;
                    //response.UserList = dbContext.XSS_User.ToList();
                }
            }
            return response;
        }
    }
}
