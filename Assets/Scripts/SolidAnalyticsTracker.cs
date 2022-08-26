using System;
using System.Collections.Generic;

namespace SolidDemo
{
    public class SolidAnalyticsTracker : IAnalyticsTracker
    {
        private const string SpawnedObjectEncounteredMessage = "NEW_{0}_ENCOUNTERED";
        private const string NewSpawnedObjectMessage = "NEW_{0}_SPAWNED";

        private Dictionary<Type, int> spawnedObjectsCounter;

        protected readonly ILogger logger;

        public SolidAnalyticsTracker(ILogger logger)
        {
            spawnedObjectsCounter = new Dictionary<Type, int>();

            this.logger = logger;
        }

        public void LogSpawnedObject<T>()
        {
            var spawnedObjectType = typeof(T);

            if (!spawnedObjectsCounter.ContainsKey(spawnedObjectType))
            {
                spawnedObjectsCounter.Add(typeof(T), 0);
                LogMessage(SpawnedObjectEncounteredMessage, spawnedObjectType);
            }

            spawnedObjectsCounter[spawnedObjectType]++;
            LogMessage(NewSpawnedObjectMessage, spawnedObjectType);
        }

        protected virtual void LogMessage(string message, Type type)
        {
            var typeName = type.Name.ToUpper();
            logger.LogMessage(string.Format(message, typeName));
        }
    }
}
