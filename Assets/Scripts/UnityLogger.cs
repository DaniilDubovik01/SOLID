using UnityEngine;

namespace SolidDemo
{
    public class UnityLogger : ILogger
    {
        public void LogMessage(string message)
        {
            Debug.Log(message);
        }
    }
}
