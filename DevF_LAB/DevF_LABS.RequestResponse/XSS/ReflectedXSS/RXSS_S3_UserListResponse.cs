using DevF_LABS.ViewModel.XSS.ReflectedXSS;
using System.Collections.Generic;

namespace DevF_LABS.RequestResponse.XSS.ReflectedXSS
{
    public class RXSS_S3_UserListResponse : BaseResponse
    {
        public List<RXSS_S3_UserView> UserList { get; set; } = new List<RXSS_S3_UserView>();
        public RXSS_S3_UserView LoginUser { get; set; }
    }
}
