using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Enviarment
{
    public class Explosion
    {
        private Vector3 _position;
        private float _radius;
        private float _force; 
        private float _damage;
        private Collider[] _targets = new Collider[16];
        
        public Explosion(Vector3 position, float radius, float damage, float force)
        {
            _position = position;
            _radius = radius;
            _force = force;
            _damage = damage;
        }
        
        public void Perform()
        {
            Physics.OverlapSphereNonAlloc(_position, _radius, _targets);

            Process();
        }

        private void Process()
        {
            foreach (var target in _targets)
            {
                if(target == null) 
                    continue;
                            
                if(target.TryGetComponent(out IDamageable damageable))
                    damageable.ApplyDamage(-_damage);
                            
                if(target.TryGetComponent(out Rigidbody rb))
                    rb.AddForce(Vector3.up * _force, ForceMode.Impulse);
            }
        }
    }
}