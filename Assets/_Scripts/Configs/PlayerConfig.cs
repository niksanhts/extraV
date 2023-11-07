using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace _Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("Health")]
        [SerializeField, Min(1)] private int health;
        
        [Header("Speed")]
        [SerializeField, Min(0.1f)] private float speed;
        
        [Header("Dash")]
        [SerializeField, Min(0.1f)] private float dashDistance;
        [SerializeField, Min(0.1f)] private float dashRecoveryTime;
        [SerializeField, Min(0.1f)] private float dashRate;
        [SerializeField, Min(1)] private int dashCount;
        
        [Header("Jump")]
        [SerializeField, Min(0.1f)] private float jumpHeight;
        [SerializeField, Min(0.1f)] private float jumpTime;
        [SerializeField, Min(1)] private float gravityForce;
        
        public int GetHealth() => health;
        public float GetSpeed() => speed;
        public float GetDashDistance() => dashDistance;
        public float GetDashRecoveryTime() => dashRecoveryTime;
        public float GetDashRate() => dashRate;
        public int GetDashCount() => dashCount;
        public float GetJumpHeight() => jumpHeight;
        public float GetJumpTime() => jumpTime;
        public float GetGravityForce() => gravityForce;
    }
}
