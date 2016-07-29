using System;
using System.IO;

namespace Core.Utils
{
    class Logger
    {
        public string pathWithNameFile = Data.pathLog + @"\" + Data.nameLogFile;

        private static Logger logger;
        private StreamWriter writer;

        private Logger()
        {
            writer = new StreamWriter(File.Create(pathWithNameFile));
        }

        public static Logger GetLogger()
        {
            if (logger == null)
            {
                logger = new Logger();
            }
            return logger;
        }

        public void Log(String message)
        {
            writer.WriteLine(message);
        }

        public void Close()
        {
            writer.Close();
        }
    }
}
