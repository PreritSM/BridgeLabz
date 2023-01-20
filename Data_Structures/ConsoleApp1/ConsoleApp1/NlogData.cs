using System;
using NLog;

namespace LinkedList
{

	 class NlogData
	{
		private static Logger logger= LogManager.GetCurrentClassLogger();

		public static void DebugInfo (string msg)
		{
			logger.Debug(msg);
		}
		public static void Infolevel(string msg)
		{
			logger.Info(msg);
		}
		public static void Warnlevel(string msg) { 
			logger.Warn(msg);
		}
		public static void Errorlevel(string msg) { 
			logger.Error(msg);
		}

		public static void SuccessInfo(string msg)
		{
			logger.Info(msg);
		}
	}
}