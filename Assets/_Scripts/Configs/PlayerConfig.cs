using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace _Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField, Min(10)] private int health;
        [SerializeField, Min(1), Range(1, 6)] private float speed;
        [SerializeField, Min(0.1f), Range(0.1f, 4)] private float jumpHeight;
        [SerializeField, Min(0.1f), Range(0.1f, 4)] private float jumpTime;
        [SerializeField, Min(1)] private float gravityForce;
        
        public int GetHealth() => health;
        public float GetSpeed() => speed;
        public float GetJumpHeight() => jumpHeight;
        public float GetJumpTime() => jumpTime;
        public float GetGravityForce() => gravityForce;
    }
}
