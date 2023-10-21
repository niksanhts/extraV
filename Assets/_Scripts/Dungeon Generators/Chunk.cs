namespace _Scripts.Dungeon_Generators
{
    public class Chunk
    {
        public int ChunkNumber { get; private set; }
        
        private readonly Room[] _rooms;
        private int _currentRoom = 0;

        public Chunk(Room[] rooms, int chunkNumber)
        {
            _rooms = rooms;
            ChunkNumber = chunkNumber;
        }

        public Room GetNextRoom()
            => _currentRoom == _rooms.Length ? null : _rooms[_currentRoom++];
    
    }
}
