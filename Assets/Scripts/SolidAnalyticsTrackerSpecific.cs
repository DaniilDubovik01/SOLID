using System;

namespace SolidDemo
{
    public class SolidAnalyticsTrackerSpecific : SolidAnalyticsTracker
    {
        public SolidAnalyticsTrackerSpecific(ILogger logger) : base(logger)
        {
        }

        protected override void LogMessage(string message, Type type)
        {
            if (type != typeof(Soldier))
            {
                return;
            }

            base.LogMessage(message, type);
        }
    }
}
