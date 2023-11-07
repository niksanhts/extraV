using _Scripts.Configs;
using _Scripts.Dungeon_Generators;
using _Scripts.Interfaces;
using Random = UnityEngine.Random;

namespace _Scripts.Dungeon_Generators
{
    public class RandomDungeonGenerator : IDungeonGenerator
    {
        private readonly Room[] _fightRooms;
        private Room[] _shopRooms;
        private Room[] _lootRooms;
        private Room[] _bossRooms;
        
        private readonly int _length;
        private int _currentChunkNumber = 0;
        private int _specialRoomFrequency;

        public RandomDungeonGenerator(ChunkConfig config)
        {
            _specialRoomFrequency = config.SpecialRoomFrequency;
            _length = config.RoomCount;
            
            _fightRooms = config.FightRooms;
            _shopRooms = config.ShopRooms;
            _lootRooms = config.LootRooms;
            _bossRooms = config.BossRooms;
        }
        
        public Chunk GenerateChunk()
        {
            _currentChunkNumber++;
            var chunkRooms = new Room[_length];

            for (var i = 0; i < _length - 1; i++)
            {
                if(i == _length/2) continue;
                
                chunkRooms[i] = _fightRooms[Random.Range(0,_fightRooms.Length)];
            }

            chunkRooms[_length / 2] = _lootRooms[Random.Range(0,_lootRooms.Length)];
            chunkRooms[_length - 1] = _shopRooms[Random.Range(0,_shopRooms.Length)];

            if (_currentChunkNumber % _specialRoomFrequency != 0)
                return new Chunk(chunkRooms, _currentChunkNumber);
            
            chunkRooms[_length - 2] = _shopRooms[Random.Range(0,_shopRooms.Length)];
            chunkRooms[_length - 1] = _bossRooms[Random.Range(0,_bossRooms.Length)];

            return new Chunk(chunkRooms, _currentChunkNumber);
        }
    }
}
