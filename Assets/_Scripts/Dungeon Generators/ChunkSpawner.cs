using _Scripts.Interfaces;
using _Scripts.Patterns.Singleton;
using UnityEngine;
using Zenject;


namespace _Scripts.Dungeon_Generators
{
    public class ChunkSpawner : MonoBehaviour
    {
        private Transform _startPosition;
        private IDungeonGenerator _generator;

        [Inject]
        public void Init(IDungeonGenerator generator)
        {
            _generator = generator;
            _startPosition = gameObject.GetComponent<Transform>();
            
            Spawn();
        }
        public void Spawn()
        {
            var position = _startPosition.position;
            var chunk = _generator.GenerateChunk();
            var room = chunk.GetNextRoom();
            
            while ( room != null)
            {
                ObjectPool.Spawn(room, position, Quaternion.identity);
                position += (room.GetExit().position - room.GetEntry().position);
                room = chunk.GetNextRoom();
            }
            
            _startPosition.position = position;
        }
    }
}