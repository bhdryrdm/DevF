using DevF_LABS.Business.DomainModel.XSS;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using DevF_LABS.RequestResponse.XSS.ReflectedXSS;
using DevF_LABS.RequestResponse.XSS.StoredXSS;
using DevF_LABS.ViewModel.XSS.ReflectedXSS;
using DevF_LABS.ViewModel.XSS.Stored_XSS;
using ExpressMapper;
using System;

namespace DevF_LABS.Business.Mapping_AutoMapper
{
    public class XSS_ExpressMapper
    {
        public XSS_ExpressMapper()
        {
            Mapper.Register<RXSS_S3_LoginRequest, RXSS_S3_LoginDomainModel>()
                .Member(y => y.RXSS_S3_LoginRequest_PasswordHash , z => z.RXSS_S3_LoginRequest_Password);

            Mapper.Register<RXSS_S3_RegisterRequest, RXSS_S3_RegisterDomainModel>()
                .Member(y => y.RXSS_S3_RegisterRequest_Password_Hash, z => z.RXSS_S3_RegisterRequest_Password)
                .Member(y => y.UpdatedTime, z => DateTime.Now)
                .Member(y => y.CreatedTime, z=>  DateTime.Now);

            Mapper.Register<RXSS_S3_RegisterDomainModel, XSS_User>()
                .Member(y => y.Password, z => z.RXSS_S3_RegisterRequest_Password_Hash)
                .Member(y => y.Email, z => z.RXSS_S3_RegisterRequest_Email)
                .Member(y => y.UserName, z => z.RXSS_S3_RegisterRequest_UserName)
                .Member(y => y.UserSurname, z => z.RXSS_S3_RegisterRequest_UserSurname)
                .Member(y => y.UserRole, z => "User");

            Mapper.Register<RXSS_S3_RegisterDomainModel, XSS_User>();

            Mapper.Register<XSS_User, RXSS_S3_UserView>();

            Mapper.Register<SXSS_S1_CommentRequest, XSS_Comment>()
                .Member(y => y.Comment, z => z.SXSS_S1_CommentRequest_Comment)
                .Member(y => y.Email, z => z.SXSS_S1_CommentRequest_Email)
                .Member(y => y.Name, z => z.SXSS_S1_CommentRequest_Name)
                .Member(y => y.CreatedTime, z => DateTime.Now);

            Mapper.Register<XSS_Comment, SXSS_S1_CommentView>()
                .Member(y => y.SXSS_S1_Comment, z => z.Comment)
                .Member(y => y.SXSS_S1_Email, z => z.Email)
                .Member(y => y.SXSS_S1_Name, z => z.Name);

            Mapper.Register<SXSS_S3_CKEditor_Request, XSS_Editor>()
                .Member(y => y.Content, z => z.SXSS_S3_CKEditorRequest_Value);
        }
    }
}
