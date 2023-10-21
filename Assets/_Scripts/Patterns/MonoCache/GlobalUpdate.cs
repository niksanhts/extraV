using System.Collections.Generic;
using _Scripts.Patterns.Singleton;


    public sealed class GlobalUpdate : Singleton<GlobalUpdate>
    {
        private static readonly List<MonoCache> MonoCaches = new List<MonoCache>(255);


        private void FixedUpdate()
        {
            foreach (var monoCache in MonoCaches)
                monoCache.FixedTick();
        }

        private void Update()
        {
            foreach (var monoCache in MonoCaches)
                monoCache.Tick();
        }

        private void LateUpdate()
        {
            foreach (var monoCache in MonoCaches)
                monoCache.LateTick();
        }

        internal static void Add(MonoCache monoCache) => MonoCaches.Add(monoCache);
        internal static void Remove(MonoCache monoCache) => MonoCaches.Remove(monoCache);
    }
