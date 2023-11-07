using UnityEngine;

namespace _Scripts.Patterns.Singleton
{
    public class UnitySingleton<T> : MonoBehaviour
    {
        public static UnitySingleton<T> Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }
    }
}