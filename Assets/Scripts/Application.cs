using UnityEngine;

namespace SolidDemo
{
    public class Application : MonoBehaviour
    {
        [SerializeField]
        private bool IsFlowChanged;
        
        private Factory factory;

        private void Awake()
        {
            var unityLogger = new UnityLogger();
            var analyticsTracker = IsFlowChanged ? new SolidAnalyticsTrackerSpecific(new UnityLoggerColorful()) : new SolidAnalyticsTracker(unityLogger);

            factory = new Factory(unityLogger, analyticsTracker);
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
