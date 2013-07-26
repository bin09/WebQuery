using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Helper
{
    /// <summary>
    /// Enumeration for database action type
    /// </summary>
    public enum DatabaseAction
    {
        Select,
        Insert,
        Update,
        Delete
    }
    public class Log4Helper
    {
        //Pre-defined logger name in web.config or app.config
        private const string LoggerName = "Query";
        private const int EmptyFunctionKey = -1;
        private const int AnonymouseUserKey = -1;
        private static readonly ILog Logger = log4net.LogManager.GetLogger(LoggerName);


        /// <summary>
        /// Add a error log
        /// </summary>
        /// <param name="errorMessage"></param>
        public static void AddError(string errorMessage)
        {
            Logger.Error(errorMessage);
        }
        /// <summary>
        /// 添加异常具体信息
        /// </summary>
        /// <param name="ex"></param>
        public static void AddError(Exception ex)
        {
            Logger.Error(System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.ToString());
        }
        /// <summary>
        /// Add a error log with an exception
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="ex"></param>
        public static void AddError(string errorMessage, Exception ex)
        {
            Logger.Error(errorMessage + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.ToString());
        }
        /// <summary>
        /// Add a warning log
        /// </summary>
        /// <param name="warnMessage"></param>
        public static void AddWarn(string warnMessage)
        {
            Logger.Warn(warnMessage);
        }
        /// <summary>
        /// Add a warning log with an exception
        /// </summary>
        /// <param name="warnMessage"></param>
        /// <param name="ex"></param>
        public static void AddWarn(string warnMessage, Exception ex)
        {
            Logger.Warn(warnMessage + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.ToString());
        }
        /// <summary>
        /// Add a info log
        /// </summary>
        /// <param name="infoMessage"></param>
        public static void AddInfo(string infoMessage)
        {
            Logger.Info(infoMessage);
        }
        /// <summary>
        /// Add a info log with an exception
        /// </summary>
        /// <param name="infoMessage"></param>
        /// <param name="ex"></param>
        public static void AddInfo(string infoMessage, Exception ex)
        {
            Logger.Info(infoMessage + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.ToString());
        }
        /// <summary>
        /// Add a debug log
        /// </summary>
        /// <param name="debugMessage"></param>
        public static void AddDebug(string debugMessage)
        {
            Logger.Debug(debugMessage);
        }
        /// <summary>
        /// Add a debug log with an exception
        /// </summary>
        /// <param name="debugMessage"></param>
        /// <param name="ex"></param>
        public static void AddDebug(string debugMessage, Exception ex)
        {
            Logger.Debug(debugMessage + System.Environment.NewLine + ex.Message + System.Environment.NewLine + ex.ToString());
        }
        /// <summary>
        /// Add a database error log 
        /// </summary>
        /// <param name="objectName">table or view name</param>
        /// <param name="dbAction">either retrieve, update, delete</param>
        /// <param name="ex"></param>
        public static void AddDatabaseError(string objectName, DatabaseAction dbAction, Exception ex)
        {
            string logMessage = string.Empty;
            switch (dbAction)
            {
                case DatabaseAction.Select:
                    logMessage = "Error occurred when retrieve data from table " + objectName;
                    break;
                case DatabaseAction.Insert:
                    logMessage = "Error occurred when insert data to table " + objectName;
                    break;
                case DatabaseAction.Update:
                    logMessage = "Error occurred when update data to table " + objectName;
                    break;
                case DatabaseAction.Delete:
                    logMessage = "Error occurred when delete data from table " + objectName;
                    break;
            }
            AddError(logMessage, ex);
        }
    }
}
