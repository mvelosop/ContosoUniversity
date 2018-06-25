using Serilog;
using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace ContosoUniversity.App_Start
{
	public class LoggingConfig
	{
		private static string _logFile;
		public static ILogger Logger { get; private set; }

		public static string LogFile => _logFile.Replace("-.log", $"-{DateTime.Today:yyyyMMdd}.log");

		public static ILogger GetLoggerForContext(Type type)
		{
			return Logger.ForContext(type);
		}

		public static ILogger RegisterLogger()
		{
			string logsFolder = ConfigurationManager.AppSettings["logsFolder"];

			logsFolder = logsFolder ?? Path.Combine(HttpRuntime.AppDomainAppPath, "logs");

			_logFile = Path.Combine(logsFolder, "log-.log");

			Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.Destructure.ToMaximumDepth(3)
				.WriteTo.Console()
				.WriteTo.File(_logFile, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 3)
				.WriteTo.Seq("http://localhost:5341/")
				.CreateLogger();

			return Logger;
		}
	}
}