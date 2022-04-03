using System;

namespace Application.Logging
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
        void LogException(Exception exception);
        void SetLogger(string logName);
    }
}
