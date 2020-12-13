using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitCoopSimulation.Business
{
    public class Logger
    {
        public static void Log(string text)
        {
            new ConsoleLogger().Log(text);
        }
    }

    public class ConsoleLogger : Ilog
    {
        public void Log(string text)
        {
            Console.WriteLine(text);
        }
    }

    public interface Ilog
    {
        void Log(string text);
    }


}
