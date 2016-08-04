using System;
using System.IO;

namespace Core.Utils
{
    public class Logger
    {        
        private static Logger logger;
        private StreamWriter writer;

        private Logger(string path)
        {
            writer = File.AppendText(path);
        }

        public static Logger GetLogger()
        {
            return logger;
        }

        public static Logger GetLogger(Type type, string path)
        {
            Logger logger = GetLogger(path);
            logger.ForClass(type);
            return logger;
        }

        public static Logger GetLogger(string path)
        {
            if (logger == null)
            {
                logger = new Logger(path);
            }
            return logger;
        }

        public void ForClass(Type type)
        {
            writer.WriteLine(type.Name + ": ");
        }

        public void Log(String message)
        {
            writer.WriteLine(DateTime.Now + ": " + message);
        }

        public void Close()
        {
            writer.Close();
            writer = null;
            logger = null;
        }
    }
}
