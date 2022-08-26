using UnityEngine;

namespace SolidDemo
{
    public class UnityLogger : ILogger
    {
        public virtual void LogMessage(string message)
        {
            Debug.Log(message);
        }
    }
}
