using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.App_Start;
using Serilog;
using ILogger = Serilog.ILogger; 

namespace ContosoUniversity.Logging
{
	public class LogFilter : IActionFilter, IExceptionFilter
	{
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var logger = GetLogger(filterContext);

			logger.Information("Executing action {Controller}.{Action} --> [{RequestType}] {Request}",
				filterContext.HttpContext.Request.HttpMethod, 
				filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
				filterContext.ActionDescriptor.ActionName,
				filterContext.HttpContext.Request.Url);
		}

		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
		}

		public void OnException(ExceptionContext filterContext)
		{
			var logger = GetLogger(filterContext);

			logger.Error(filterContext.Exception, "Request: {Request}", filterContext.HttpContext.Request.Url);
		}

		private Serilog.ILogger GetLogger(ControllerContext filterContext)
		{
			var controllerType = filterContext.GetType();

			var logger = LoggingConfig.GetLoggerForContext(controllerType);

			return logger;
		}
	}
}