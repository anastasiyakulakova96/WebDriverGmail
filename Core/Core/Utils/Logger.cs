using System;
using System.IO;

namespace Core.Utils
{
    public class Logger
    {
        public string pathWithNameFile = Data.pathLog + @"\" + Data.nameLogFile;
        
        private static Logger logger;
        private StreamWriter writer;

        private Logger()
        {
            writer = new StreamWriter(File.Create(pathWithNameFile));
        }

        public static Logger GetLogger(Type type)
        {
            Logger logger = GetLogger();
            logger.ForClass(type);
            return logger;
        }

        public static Logger GetLogger()
        {
            if (logger == null)
            {
                logger = new Logger();
            }
            return logger;
        }

        public void ForClass(Type type)
        {
            writer.WriteLine(type.Name + ": ");
        }

        public void Log(String message)
        {
            writer.WriteLine(message);
        }

        public void Close()
        {
            writer.Close();
            logger = null;
        }
    }
}
