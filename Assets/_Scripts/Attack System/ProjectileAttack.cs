using _Scripts.Interfaces;
using _Scripts.Weapon;
using UnityEngine;

    [RequireComponent(typeof(Weapon))]
    public class ProjectileAttack : MonoCache, IAttackType
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private float force;
        [SerializeField] private Projectile projectilePrefab;

        private float _damage;

        public void Start()
        {
            _damage = GetComponent<Weapon>().Damage;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void PerformAttack()
        {
            var projectile = ObjectPool.Spawn(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Projectile>().SetDamage(_damage);
            projectile.GetComponent<Rigidbody>().AddForce(firePoint.forward * force, ForceMode.Impulse);
        }
        
        
    }
