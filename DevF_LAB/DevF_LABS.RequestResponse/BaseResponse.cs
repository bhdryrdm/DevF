using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse
{
    public class BaseResponse
    {
        public int ResponseCode { get; set; } = 200;
        public string Message { get; set; } = "İşlem başarılı.";
        public bool IsSuccess { get; set; } = true;
    }
}
