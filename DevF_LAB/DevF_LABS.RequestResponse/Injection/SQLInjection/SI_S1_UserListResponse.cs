using DevF_LABS.ViewModel.Injection.SQLInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse.Injection.SQLInjection
{
    public class SI_S1_UserListResponse : BaseResponse
    {
        public List<SI_S1_UserView> Users { get; set; } = new List<SI_S1_UserView>();
    }
}
