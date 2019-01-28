using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LogHandler : ILogHandler
{
    void ILogHandler.LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        Debug.unityLogger.logHandler.LogFormat(logType, context, format, args);
    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        Debug.unityLogger.LogException(exception, context);
    }
}
