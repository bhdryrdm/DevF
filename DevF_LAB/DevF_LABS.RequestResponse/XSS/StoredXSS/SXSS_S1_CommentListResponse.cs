using DevF_LABS.ViewModel.XSS.Stored_XSS;
using System.Collections.Generic;

namespace DevF_LABS.RequestResponse.XSS.StoredXSS
{
    public class SXSS_S1_CommentListResponse : BaseResponse
    {
        public List<SXSS_S1_CommentView> CommentList { get; set; } = new List<SXSS_S1_CommentView>();
    }
}
