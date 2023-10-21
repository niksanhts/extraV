using System.Collections.Generic;
using UnityEngine;



    public class Pool
    {
        private Queue<GameObject> _objects = new ();
        private GameObject _prefab;
        public Pool(GameObject prefab) => _prefab = prefab;

        public GameObject Get()
        {
            GameObject gameObject;
        
            if (_objects.Count == 0)
            {
                gameObject = Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
                gameObject.name = _prefab.name;
            }
            else
            {
                gameObject = _objects.Dequeue();
            }
            return gameObject;
        }

        public void Return(GameObject gameObject)
        {
            _objects.Enqueue(gameObject);
        }


    }
