using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySteps.LogInfo
{
    internal class Logger : ILogger
    {
        private static  Logger _logger;
        private string _path { get; set; }
        private Logger()
        {
            _path = DateTime.UtcNow.ToString();
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        public void Error(string message)
        {
            WriteFile("error"+message);
        }

        public void Info(string message)
        {
            WriteFile("Info" + message);
        }
        
        private void WriteFile(string name)
        {
            File.WriteAllText(_path, name);
        }
        public static ILogger GetInstance()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
                return _logger;
        }
    }
}
