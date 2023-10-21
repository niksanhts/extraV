using UnityEngine;


    public class MonoCache : MonoBehaviour
    {
        private void OnEnable() => GlobalUpdate.Add(this);
        private void OnDisable() => GlobalUpdate.Remove(this);
        private void OnDestroy() => GlobalUpdate.Remove(this);
        public void Tick() => OnTick();
        public void FixedTick() => FixedTick();
        public void LateTick() => OnLateTick();
        
        protected virtual void OnFixedTick() { }
        protected virtual void OnTick() { }
        protected virtual void OnLateTick() { }
    }
