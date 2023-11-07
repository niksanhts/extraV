using UnityEngine;


    public class MonoCache : MonoBehaviour
    {
        private void OnEnable() => GlobalUpdate.Add(this);
        private void OnDisable() => GlobalUpdate.Remove(this);
        private void OnDestroy() => GlobalUpdate.Remove(this);
        public virtual void Tick() => OnTick();
        
        protected virtual void OnTick() { }
    }
