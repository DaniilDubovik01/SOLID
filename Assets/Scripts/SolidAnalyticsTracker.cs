using System;
using System.Collections.Generic;

namespace SolidDemo
{
    public class SolidAnalyticsTracker : IAnalyticsTracker
    {
        private const string SpawnedObjectEncounteredMessage = "NEW_{0}_ENCOUNTERED";
        private const string NewSpawnedObjectMessage = "NEW_{0}_SPAWNED";

        private Dictionary<Type, int> spawnedObjectsCounter;

        private readonly ILogger logger;

        public SolidAnalyticsTracker(ILogger logger)
        {
            spawnedObjectsCounter = new Dictionary<Type, int>();
            
            this.logger = logger;
        }

        public void LogSpawnedObject<T>()
        {
            var spawnedObjectType = typeof(T);
            var spawnedObjectName = spawnedObjectType.Name.ToUpper();

            if (!spawnedObjectsCounter.ContainsKey(spawnedObjectType))
            {
                spawnedObjectsCounter.Add(typeof(T), 0);
                logger.LogMessage(string.Format(SpawnedObjectEncounteredMessage, spawnedObjectName));
            }

            spawnedObjectsCounter[spawnedObjectType]++;
            logger.LogMessage(string.Format(NewSpawnedObjectMessage, spawnedObjectName));
        }
    }
}
