using UnityEngine;

namespace SolidDemo
{
    public class Application : MonoBehaviour
    {
        private Factory factory;

        private void Awake()
        {
            factory = new Factory(new UnityLogger());
            factory.Add<Soldier>();
            factory.Add<UberSoldier>();
        }

        private void Start()
        {
            factory.Spawn<Soldier>();
            factory.Spawn<UberSoldier>();
        }
    }
}
