using _Scripts.Enviarment;
using UnityEngine;

namespace _Scripts.Attack_System.Projectiles
{
    public class Granade : Projectile
    {
        [Header("Explosion")]
        [SerializeField] private float explosionRadius;
        [SerializeField] private float explosionForce; 
        [SerializeField] private float explosionDamage;
        
        private Explosion _explosion;

        private void Awake()
        {
            _explosion = new Explosion(transform.position, explosionRadius, explosionDamage, explosionForce);
        }

        protected override void OnProjectileDispose()
        {
            base.OnProjectileDispose();
            _explosion.Perform();
        }
        
    }
}