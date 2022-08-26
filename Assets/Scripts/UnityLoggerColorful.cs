namespace SolidDemo
{
    public class UnityLoggerColorful : UnityLogger
    {
        public override void LogMessage(string message)
        {
            base.LogMessage($"<color=red>{message}</color>");
        }
    }
}
