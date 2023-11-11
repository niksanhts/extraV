using System;
using _Scripts.Dungeon_Generators;
using Zenject;

namespace _Scripts
{
    public class Bootstrap : MonoCache
    {
        private ChunkSpawner _chunkSpawner;
        
        [Inject]
        public void Init(ChunkSpawner chunkSpawner)
        {
            _chunkSpawner = chunkSpawner;
        }

        private void Awake()
        {
            _chunkSpawner.Spawn();
        }
    }
}