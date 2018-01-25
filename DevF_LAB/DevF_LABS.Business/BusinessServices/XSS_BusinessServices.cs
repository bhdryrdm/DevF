using DevF_LABS.Business.DomainModel.XSS;
using DevF_LABS.Business.Mapping;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using DevF_LABS.RequestResponse.XSS.ReflectedXSS;
using DevF_LABS.RequestResponse.XSS.StoredXSS;
using System;
using System.Linq;

namespace DevF_LABS.Business.BusinessServices
{
    public static class XSS_BusinessServices
    {
        public static RXSS_S3_UserListResponse RXSS_S3_Login(RXSS_S3_LoginRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                try
                {
                    XSS_User user = dbContext.XSS_User.Where(x => x.Email == request.RXSS_S3_LoginRequest_Email && x.Password == request.RXSS_S3_LoginRequest_Password).FirstOrDefault();
                    if (user != null)
                    {
                        response.LoginUser = XSS_Mapping.XSS_User_To_RXSS_S3_UserView(user);
                        response.UserList = XSS_Mapping.XSS_User_To_RXSS_S3_UserView(dbContext.XSS_User.ToList());
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return response;
        }

        public static RXSS_S3_UserListResponse RXSS_S3_Register(RXSS_S3_RegisterRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                try
                {
                    RXSS_S3_RegisterDomainModel model = XSS_Mapping.RXSS_S3_RegisterRequest_To_RXSS_S3_RegisterDomainModel(request);
                    // TODO : Model valid kontrolü yapılacak Exceptio mantıgı kurulacak
                    XSS_User user = XSS_Mapping.RXSS_S3_RegisterDomainModel_To_XSS_User(model);
                    
                    dbContext.XSS_User.Add(user);
                    dbContext.SaveChanges();

                    response.LoginUser = XSS_Mapping.XSS_User_To_RXSS_S3_UserView(user);
                    response.Message = "Kullanıcı kaydı başarılı";
                }
                catch (Exception ex)
                {
                    response.Message = "Kullanıcı kaydı başarısız" + ex.Message;
                }
                response.UserList = XSS_Mapping.XSS_User_To_RXSS_S3_UserView(dbContext.XSS_User.ToList());
            }
            return response;
        }

        public static RXSS_S3_UserListResponse RXSS_S3_Delete(RXSS_S3_DeleteRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                XSS_User user = dbContext.XSS_User.Where(x => x.UserID == request.UserID && (x.Email != "admin@devf.com" && x.Email != "demo@devf.com")).FirstOrDefault();
                if (user != null)
                {
                    dbContext.XSS_User.Remove(user);
                    dbContext.SaveChanges();
                    response.Message = $"{request.UserID.ToString()} ID'li kullanıcı başarılı bir şekilde silinmiştir!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = $"İşlem başarısız!{request.UserID.ToString()} ID'li kullanıcı bulunamadı!";
                    XSS_User deleteDefaultUser = dbContext.XSS_User.Where(x => x.Email != "admin@devf.com" && x.Email != "demo@devf.com").FirstOrDefault();

                    if (deleteDefaultUser != null)
                    {
                        dbContext.XSS_User.Remove(deleteDefaultUser);
                        dbContext.SaveChanges();
                        response.Message += $"Öntanımlı olarak {deleteDefaultUser.UserID }-{deleteDefaultUser.UserName} kullanıcı silinmiştir!";
                    }
                }
                response.UserList = XSS_Mapping.XSS_User_To_RXSS_S3_UserView(dbContext.XSS_User.ToList());
            }
            return response;
        }

        public static SXSS_S1_CommentListResponse SXSS_S1_Comment(SXSS_S1_CommentRequest request)
        {
            SXSS_S1_CommentListResponse response = new SXSS_S1_CommentListResponse();
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                try
                {
                    dbContext.XSS_Comment.Add(XSS_Mapping.SXSS_S1_CommentRequest_To_XSS_Comment(request));
                    dbContext.SaveChanges();

                    response.CommentList = XSS_Mapping.XSS_Comment_To_SXSS_S1_CommentView(dbContext.XSS_Comment.ToList());
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return response;
        }
    }
}
