using System.Collections.Generic;
using _Scripts.Patterns.Singleton;


    public sealed class GlobalUpdate : UnitySingleton<GlobalUpdate>
    {
        private static List<MonoCache> MonoCaches = new List<MonoCache>(255);

        private void Update()
        {
            foreach (var monoCache in MonoCaches)
                monoCache.Tick();
        }

        internal static void Add(MonoCache monoCache) => MonoCaches.Add(monoCache);
        internal static void Remove(MonoCache monoCache) => MonoCaches.Remove(monoCache);
    }
