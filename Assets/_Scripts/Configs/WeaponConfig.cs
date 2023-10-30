using UnityEngine;

namespace _Scripts.Configs
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        [Header("Pauses")]
        [SerializeField, Min(0.01f), Range(0.01f, 2f)] private float fireRate;
        [SerializeField, Min(0.01f), Range(0.01f, 5f)] private float reloadTime;

        [Header("Bullets Count")] 
        [SerializeField, Min(1)] private int maxBullets;
        [SerializeField, Min(1)] private int bulletsInShot;

        [Header("Damage")]
        [SerializeField, Min(0.01f), Range(0.01f, 100f)] private float damage;
        
        public float GetFireRate() => fireRate;
        public float GetReloadTime() => reloadTime;
        public int GetMaxBullets() => maxBullets;
        public int GetBulletsInShot() => bulletsInShot;
        public float GetDamage() => damage;
    }
}