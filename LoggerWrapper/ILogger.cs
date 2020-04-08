namespace NewsCSharp.LoggerWrapper
{
    public interface ILogger
    {
        void WriteOldWay(string message, params object[] args);

        void Write(string message, params object[] args);
    }
}