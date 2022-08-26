using System;
using System.Collections.Generic;

namespace SolidDemo
{
    public class Factory
    {
        private readonly List<Type> objectsToSpawn;
        private readonly ILogger logger;
        private readonly IAnalyticsTracker analyticsTracker;

        public Factory(ILogger logger, IAnalyticsTracker analyticsTracker)
        {
            objectsToSpawn = new List<Type>();
            
            this.logger = logger;
            this.analyticsTracker = analyticsTracker;
        }

        public void Add<T>()
        {
            objectsToSpawn.Add(typeof(T));
        }

        public T Spawn<T>() where T : new()
        {
            var spawnedObject = objectsToSpawn.Contains(typeof(T)) ? new T() : default(T);

            if (spawnedObject != null && logger != null)
            {
                logger.LogMessage($"{nameof(Factory)}: {spawnedObject.GetType().Name} has been spawned.");
            }
            
            analyticsTracker?.LogSpawnedObject<T>();

            return spawnedObject;
        }
    }
}
