using DevF_LABS.Business.DomainModel.XSS;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using DevF_LABS.RequestResponse.XSS.ReflectedXSS;
using DevF_LABS.RequestResponse.XSS.StoredXSS;
using DevF_LABS.ViewModel.XSS.ReflectedXSS;
using DevF_LABS.ViewModel.XSS.Stored_XSS;
using DevF_LABS.ViewModel.XSS.StoredXSS;
using ExpressMapper;
using System.Collections.Generic;

namespace DevF_LABS.Business.Mapping
{
    public class XSS_Mapping
    {
        // Login Request --> LoginDomainModel
        public RXSS_S3_LoginDomainModel RXSS_S3_LoginRequest_To_RXSS_S3_DomainModel(RXSS_S3_LoginRequest request)
        {
            return Mapper.Map<RXSS_S3_LoginRequest, RXSS_S3_LoginDomainModel>(request);
        }

        // Regiter Request --> RegisterDomainModel
        public static RXSS_S3_RegisterDomainModel RXSS_S3_RegisterRequest_To_RXSS_S3_RegisterDomainModel(RXSS_S3_RegisterRequest request)
        {
            return Mapper.Map<RXSS_S3_RegisterRequest, RXSS_S3_RegisterDomainModel>(request);
        }

        // RegisterDomainModel -->EntityModel
        public static XSS_User RXSS_S3_RegisterDomainModel_To_XSS_User(RXSS_S3_RegisterDomainModel model)
        {
            return Mapper.Map<RXSS_S3_RegisterDomainModel, XSS_User>(model);
        }

        // EntityModel List --> ViewModel List
        public static List<RXSS_S3_UserView> XSS_User_To_RXSS_S3_UserView(List<XSS_User> userEntityList)
        {
            List<RXSS_S3_UserView> userList = new List<RXSS_S3_UserView>();
            foreach (var user in userEntityList)
            {
                userList.Add(XSS_User_To_RXSS_S3_UserView(user));
            }
            return userList;
        }

        // EntityModel --> ViewModel
        public static RXSS_S3_UserView XSS_User_To_RXSS_S3_UserView(XSS_User entity)
        {
            return Mapper.Map<XSS_User, RXSS_S3_UserView>(entity);
        }

        public static XSS_Comment SXSS_S1_CommentRequest_To_XSS_Comment(SXSS_S1_CommentRequest request)
        {
            return Mapper.Map<SXSS_S1_CommentRequest, XSS_Comment>(request);
        }

        // EntityModel List --> ViewModel List
        public static List<SXSS_S1_CommentView> XSS_Comment_To_SXSS_S1_CommentView(List<XSS_Comment> commentEntityList)
        {
            List<SXSS_S1_CommentView> commentList = new List<SXSS_S1_CommentView>();
            foreach (var comment in commentEntityList)
            {
                commentList.Add(XSS_Comment_To_SXSS_S1_CommentView(comment));
            }
            return commentList;
        }

        // EntityModel --> ViewModel
        public static SXSS_S1_CommentView XSS_Comment_To_SXSS_S1_CommentView(XSS_Comment entity)
        {
            return Mapper.Map<XSS_Comment, SXSS_S1_CommentView>(entity);
        }

        // Steal Request List --> EntityModel
        public static List<XSS_Cookie> SXSS_S2_StealRequest_To_XSS_Cookie(SXSS_S2_StealRequest request)
        {
            List<XSS_Cookie> cookieList = new List<XSS_Cookie>();
            foreach (string cookie in request.SXSS_S2_StealRequest_Cookie.Split(';'))
            {
                XSS_Cookie xss_Cookie = new XSS_Cookie
                {
                    SessionID = request.SessionID,
                    CookieName = cookie.Split('=')[0],
                    CookieValue = cookie.Split('=')[1],
                };
                cookieList.Add(xss_Cookie);
            }
            return cookieList;
        }

        // EntityModel List --> ViewModel List
        public static List<SXSS_S2_CookieView> XSS_Cookie_To_SXSS_S2_CookieView(List<XSS_Cookie> cookieEntityList)
        {
            List<SXSS_S2_CookieView> cookieList = new List<SXSS_S2_CookieView>();
            foreach (var cookie in cookieEntityList)
            {
                cookieList.Add(XSS_Cookie_To_SXSS_S2_CookieView(cookie));
            }
            return cookieList;
        }

        // EntityModel --> ViewModel
        public static SXSS_S2_CookieView XSS_Cookie_To_SXSS_S2_CookieView(XSS_Cookie entity)
        {
            return Mapper.Map<XSS_Cookie, SXSS_S2_CookieView>(entity);
        }
    }
}
