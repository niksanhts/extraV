using UnityEngine;

namespace _Scripts.Dungeon_Generators
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Transform entry;
        [SerializeField] private Transform exit;
        
        [SerializeField] private RoomType type;

        public RoomType GetRoomTypeType() => type;
        public Transform GetEntry() => entry;
        public Transform GetExit() => exit;
    }
}