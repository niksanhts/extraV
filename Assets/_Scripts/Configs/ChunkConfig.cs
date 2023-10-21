using _Scripts.Dungeon_Generators;
using UnityEngine;

namespace _Scripts.Configs
{
    [CreateAssetMenu(menuName = "ChunkConfig")]
    public class ChunkConfig : ScriptableObject
    {
        [SerializeField, Min(4)] private int roomCount = 10;
        [SerializeField, Min(1)] private int specialRoomFrequency;
        
        [SerializeField] private Room[] fightRooms;
        [SerializeField] private Room[] shopRooms;
        [SerializeField] private Room[] lootRooms;
        [SerializeField] private Room[] bossRooms;
        
        
        public int RoomCount => roomCount;
        public int SpecialRoomFrequency => specialRoomFrequency;
        public Room[] FightRooms => fightRooms;
        public Room[] ShopRooms => shopRooms;
        public Room[] LootRooms => lootRooms;
        public Room[] BossRooms => bossRooms;
    }
}