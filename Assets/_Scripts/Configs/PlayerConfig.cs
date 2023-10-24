using UnityEngine;
using UnityEngine.Rendering;

namespace _Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField, Min(10)] private int health;
        [SerializeField, Min(1), Range(1, 6)] private float speed;
        [SerializeField, Min(0.1f), Range(0.1f, 4)] private float jumpHeight;
        [SerializeField, Min(0.1f), Range(0.1f, 4)] private float jumpDistance;
        [SerializeField, Min(1)] private float _gravityForce;
        
        public int GetHealth() => health;
        public float GetSpeed() => speed;
        public float GetJumpHeight() => jumpHeight;
        public float GetJumpDistance() => jumpDistance;

        public float GetGravityForce() => _gravityForce;
    }
}
