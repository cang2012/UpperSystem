﻿using log4net.Config;
using System;
using System.IO;

namespace UpperSystem.Infrasture
{
    public class LogHelper
    {
        #region 配置方法，加载配置文件
        public static void SetConfig()
        {
            XmlConfigurator.Configure();
        }

        //【程序窗体加载的时候调用这个方法】
        public static void SetConfig(FileInfo configFile)
        {
            XmlConfigurator.Configure(configFile);
        }

        #endregion

        #region 写入日志的方法

        public static readonly log4net.ILog LogForFatal = log4net.LogManager.GetLogger("fatal");
        public static readonly log4net.ILog LogForError = log4net.LogManager.GetLogger("error");
        public static readonly log4net.ILog LogForWarn = log4net.LogManager.GetLogger("warn");
        public static readonly log4net.ILog LogForInfo = log4net.LogManager.GetLogger("info");
        public static readonly log4net.ILog LogForDebug = log4net.LogManager.GetLogger("debug");

        public static void Fatal(string fatal, Exception e)
        {
            LogForInfo.Fatal(fatal, e);
        }
        public static void Error(string errorInfo, Exception t)
        {
            LogForError.Error(errorInfo, t);
        }
        public static void Warn(string warnInfo)
        {
            LogForDebug.Warn(warnInfo);
        }
        public static void Info(string info)
        {
            LogForInfo.Info(info);
        }
        public static void Debug(string debugInfo)
        {
            LogForInfo.Debug(debugInfo);
        }

        #endregion

        #region 写入日志的方法【二】

        public static void WriteLogInfo(string info)
        {
            bool isInfoEnabled = LogHelper.LogForInfo.IsInfoEnabled;
            if (isInfoEnabled)
            {
                LogForInfo.Info(info);
            }
        }

        #endregion
    }
}
