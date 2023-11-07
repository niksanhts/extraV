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

        public Pool(GameObject prefab)
        {
            _prefab = prefab;
            Cache(10);
        }
        
        public void Cache(int number)
        {
            for (var i = 0; i < number; i++)
            {
                Return(Get());
            }
        }

        public GameObject Get()
        {
            GameObject gameObject;
        
            if (_objects.Count == 0)
            {
                gameObject = Object.Instantiate(_prefab);
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
    
