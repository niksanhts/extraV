using UnityEngine;

namespace _Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs")]
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

        //[Header("Effects")] 
        //[SerializeField] private AudioClip _shootClip;
        //[SerializeField] private AudioClip _reloadClip;
        //[SerializeField] private ParticleSystem _shootParticle;

        public float GetFireRate() => fireRate;
        public float GetReloadTime() => reloadTime;
        public int GetMaxBullets() => maxBullets;
        public int GetBulletsInShot() => bulletsInShot;
        public float GetDamage() => damage;
    }
}