using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Logs
{
    public class NLogLogger
    {
        public static bool Log(Exception ex, string message = "", LogPriority priority = LogPriority.High)
        {
            try
            {
                NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
                switch (priority)
                {
                    case LogPriority.RedAlert:
                        logger.Fatal(ex, message);break;
                    case LogPriority.Low:
                        logger.Info(ex, message);break;
                    case LogPriority.High:
                        logger.Error(ex, message);break;
                    case LogPriority.Normal:
                        logger.Warn(ex, message);break;
                    default:
                        logger.Error(ex, message);break;
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}