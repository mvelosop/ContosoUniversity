using Serilog;
using System;
using System.IO;
using System.Web;

namespace ContosoUniversity.App_Start
{
	public class LoggingConfig
	{
		public static ILogger Logger { get; private set; }

		public static ILogger GetLoggerForContext(Type type)
		{
			return Logger.ForContext(type);
		}

		public static ILogger RegisterLogger()
		{
			var logFile = Path.Combine(HttpRuntime.AppDomainAppPath, "logs", "log-.log");

			Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Console()
				.WriteTo.File(logFile, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 3)
				.WriteTo.Seq("http://localhost:5341/")
				.CreateLogger();

			return Logger;
		}
	}
}