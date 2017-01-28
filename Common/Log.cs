using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logary;
using Logary.Configuration;
using Logary.Targets;

namespace Common
{
    public class Log
    {
        private static LogManager Instance = new Globals().LogManager;
        private static void LogMessage(string loggerName, Logary.LogLevel level, string[] tags, IDictionary<string, object> fields, string message, params object[] parameters)
        {
            try
            {
                var fieldsNotNull = ClearFields(fields);
                Instance.GetLogger(loggerName).Log(
                    String.Format(message, parameters),
                    level,
                    fieldsNotNull,
                    tags,
                    null,
                    null,
                    null
                    );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Exception writing log: " + ex.Message);
            }
        }
        private static IDictionary<string, object> ClearFields(IDictionary<string, object> fields)
        {
            if (fields != null)
            {
                var fieldsNotNull = fields.Where(i => i.Value != null);
                if (fieldsNotNull != null && fieldsNotNull.Any())
                {
                    return fieldsNotNull.ToDictionary(i => i.Key, i => i.Value);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public static void Info(string loggerName, string[] tags, IDictionary<string, object> fields, string message, params object[] parameters)
        {
            Log.LogMessage(loggerName, LogLevel.Info, tags, fields, message, parameters);
        }
        public static void Warn(string loggerName, string[] tags, IDictionary<string, object> fields, string message, params object[] parameters)
        {
            Log.LogMessage(loggerName, LogLevel.Warn, tags, fields, message, parameters);
        }
        public static void Error(string loggerName, string[] tags, IDictionary<string, object> fields, string message, params object[] parameters)
        {
            Log.LogMessage(loggerName, LogLevel.Error, tags, fields, message, parameters);
        }
        private static LoggedException ExceptionToLogged(Exception e)
        {
            var ex = new LoggedException
            {
                ClassName = e.GetType().FullName,
                Message = e.Message,
                StackTraceString = e.StackTrace == null ? string.Empty : e.StackTrace,
                Source = e.Source == null ? string.Empty : e.Source,
                ParamName = e is ArgumentException ? (e as ArgumentException).ParamName : string.Empty
            };
            if (e.InnerException != null)
            {
                ex.InnerException = ExceptionToLogged(e.InnerException);
            }
            return ex;
        }
        private static void LogException(string loggerName, string[] tags, IDictionary<string, object> fields, string message, Exception e)
        {
            try
            {
                var fieldsNotNull = ClearFields(fields);
                if (fieldsNotNull == null)
                {
                    fieldsNotNull = new Dictionary<string, object>();
                }
                else
                {
                    if (fieldsNotNull.ContainsKey("exception"))
                    {
                        fieldsNotNull.Remove("exception");
                    }
                }
                var ex = ExceptionToLogged(e);
                fieldsNotNull.Add("exception", ex);


                Log.LogMessage(loggerName, LogLevel.Error, tags, fieldsNotNull, message);

                Instance.GetLogger(loggerName).Log(
                    message,
                    LogLevel.Error,
                    fieldsNotNull,
                    tags,
                    null,
                    e,
                    null
                    );
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Exception writing log: " + ex.Message);
            }
        }
        public static void Exception(string loggerName, string[] tags, IDictionary<string, object> fields, string message, Exception e)
        {
            Log.LogException(loggerName, tags, fields, message, e);
        }
    }
}
