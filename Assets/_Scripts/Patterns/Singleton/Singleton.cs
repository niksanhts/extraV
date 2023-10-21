using UnityEngine;

namespace _Scripts.Patterns.Singleton
{
    public class Singleton<T> : MonoBehaviour
    {
        public static Singleton<T> Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }
    }
}