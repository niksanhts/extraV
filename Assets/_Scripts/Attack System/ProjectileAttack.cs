using _Scripts;
using _Scripts.Interfaces;
using _Scripts.Weapon;
using UnityEngine;

    [RequireComponent(typeof(Weapon))]
    public class ProjectileAttack : MonoCache, IAttackType
    {
        [SerializeField] private float force;
        [SerializeField] private Projectile projectilePrefab;

        private float _damage;
        private Transform firePoint;
        
        public void Start()
        {
            firePoint = FirePoint.Instance.transform;
            _damage = GetComponent<Weapon>().Damage;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void PerformAttack()
        {
            var projectile = ObjectPool.Spawn(projectilePrefab, firePoint.position, firePoint.rotation)
                            .GetComponent<Projectile>();
            projectile.SetDamage(_damage);
            projectile.rigidbody.AddForce(firePoint.forward * force, ForceMode.Impulse);
        }
        
        
    }
