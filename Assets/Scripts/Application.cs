using UnityEngine;

namespace SolidDemo
{
    public class Application : MonoBehaviour
    {
        private Factory factory;

        private void Awake()
        {
            var unityLogger = new UnityLogger();
            var solidAnalyticsTracker = new SolidAnalyticsTracker(unityLogger);
            
            factory = new Factory(unityLogger, solidAnalyticsTracker);
            factory.Add<Soldier>();
            factory.Add<UberSoldier>();
        }

        private void Start()
        {
            factory.Spawn<Soldier>();
            factory.Spawn<Soldier>();
            factory.Spawn<UberSoldier>();
            factory.Spawn<UberSoldier>();
        }
    }
}
