using System.Collections.Generic;
using UnityEngine;

    public static class ObjectPool
    {
        private static Dictionary<string, Pool> _pools = new ();
        
        public static GameObject Spawn(Component component, Vector3 position,
                        Quaternion rotation, Component parent = null)
        {
            var prefab = component.gameObject;
            
            if (prefab != null && _pools.ContainsKey(prefab.name) == false)
                CreatePool(prefab);

            var gameObject = parent ? _pools[prefab.name].Get() : _pools[prefab.name].Get(parent);
            
            gameObject.SetActive(true);
            
            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            
            return gameObject;
        }

        public static void Despawn(Component component)
        {
            var gameObject = component.gameObject;

            if (_pools.ContainsKey(gameObject.name))
                _pools[gameObject.name].Return(gameObject);
            else
                Object.Destroy(gameObject);
            
        }

        private static void CreatePool(GameObject prefab) => _pools[prefab.name] = new Pool(prefab);

    }
