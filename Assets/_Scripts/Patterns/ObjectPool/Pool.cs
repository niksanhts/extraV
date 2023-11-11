using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using Cache = Unity.VisualScripting.Cache;

public enum SpawnType
{
    Normal,
    AsChildren
}

public class Pool
    {
        private Queue<GameObject> _objects = new();
        private GameObject _prefab;
        public Pool(GameObject prefab) => _prefab = prefab;

        public GameObject Get() => Get(null);

        public GameObject Get(Component parent)
        {
            GameObject gameObject;
        
            if (_objects.Count == 0)
            {
                gameObject = (parent == null) ? Object.Instantiate(_prefab) : Object.Instantiate(_prefab, parent.transform);
                gameObject.name = _prefab.name;
                return gameObject;
            }
            
            gameObject = _objects.Dequeue();
            return gameObject;
        }

        public void Return(GameObject gameObject)
        {
            _objects.Enqueue(gameObject);
            gameObject.SetActive(false);
        }
    }  
    
