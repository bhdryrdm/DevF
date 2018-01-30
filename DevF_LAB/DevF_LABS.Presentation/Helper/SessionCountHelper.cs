using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevF_LABS.Presentation.Helper
{
    public static class SessionCountHelper
    {
        public static int SessionCount { get; set; }
        public static List<SessionUserModel> SessionUserList { get; set; } = new List<SessionUserModel>(); 
    }

    public class SessionUserModel
    {
        public string SessionID { get; set; }
        public string IPAddress { get; set; }
        public string IsMobile { get; set; }
        public string OperatingSystem { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsActiveSession { get; set; }
    }
}