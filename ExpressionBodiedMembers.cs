using System;
using System.Runtime.InteropServices;
using NewsCSharp.LoggerWrapper;

namespace NewsCSharp
{
    public static class ExpressionBodiedMembersWrapper
    {
        public static void ExampleBodiedMembers()
        {
            Console.WriteLine();
            Console.WriteLine("====== Expression Bodied Members ======");
            var logger = new Logger();
            for (int i = 0; i < 2; i++)
            {
                var ebmOld = new ExpressionBodiedMembersOld(logger);

                ebmOld.Log("test 1 from old");
                ebmOld.Logger.WriteOldWay("test 2 from old");
                ebmOld.Logger.Write("test 3 from old");

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            for (int i = 0; i < 2; i++)
            {
                var ebm = new ExpressionBodiedMembers(logger);

                ebm.Log("test 1");
                ebm.Logger.WriteOldWay("test 2");
                ebm.Logger.Write("test 3");

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            Console.WriteLine("====================================================================");
        }
    }

    internal class ExpressionBodiedMembersOld
    {
        private ILogger _logger;

        public ExpressionBodiedMembersOld(ILogger logger)
        {
            _logger = logger;
        }

        ~ExpressionBodiedMembersOld()
        {
            _logger.Write("{0} from old is finalized!", nameof(ExpressionBodiedMembers));
        }

        public void Log(string message)
        {
            _logger.Write(message);
        }

        public ILogger Logger
        {
            get
            {
                return _logger;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Logger));
                }
                _logger = value;
            }
        }
    }

    internal class ExpressionBodiedMembers
    {
        private ILogger _logger;

        public ExpressionBodiedMembers(ILogger logger) => _logger = logger;

        ~ExpressionBodiedMembers() => _logger.Write("{0} is finalized!", nameof(ExpressionBodiedMembers));

        public void Log(string message) => _logger.Write(message);

        public ILogger Logger
        {
            get => _logger;
            set => _logger = value ?? throw new ArgumentNullException(nameof(Logger));
        }
    }
}