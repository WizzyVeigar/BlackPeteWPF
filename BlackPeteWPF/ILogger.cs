using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public interface ILogger
    {
        /// <summary>
        /// Method for logging a message
        /// </summary>
        /// <param name="message"></param>
        void LogMessage(string message);
    }
}
