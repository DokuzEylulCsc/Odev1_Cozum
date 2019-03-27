using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace Odev_1
{
    public class LogWriter
    {
        private static string m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static bool logBool=true;
        public static void LogMessage(string logMessage)
        {
            if(logBool)
                LogWrite(logMessage);
        }
        private static void LogWrite(string logMessage)
        {
           
            
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
           
        }

        private static void Log(string logMessage, TextWriter txtWriter)
        {
           
                txtWriter.Write("\r\nLog Girdisi : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
           
        }
    }
}
