using DevF_LABS.ViewModel.XSS.StoredXSS;
using System.Collections.Generic;

namespace DevF_LABS.RequestResponse.XSS.StoredXSS
{
    public class SXSS_S2_CookieListResponse : BaseResponse
    {
        public List<SXSS_S2_CookieView> CookieList { get; set; }
    }
}
