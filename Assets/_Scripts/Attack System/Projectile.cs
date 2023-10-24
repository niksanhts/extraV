using System;
using _Scripts.Interfaces;
using UnityEngine;

    [SelectionBase]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoCache
    { 
        [Header("Rigidbody")] 
        [SerializeField] private Rigidbody rigidbody;

        [Header("Effects")]
        [SerializeField] private bool spawnEffectOnDestroy = true;
        [SerializeField] private ParticleSystem destroyEffectPrefab;
        //[SerializeField, Min(0f), Range(0,2)] private float destroyEffectLifetime = 1f;

        [SerializeField] 
        private ProjectileDisposeType disposeType = ProjectileDisposeType.OnAnyCollision;

        private bool _isProjectileDispose = false;
        private float _damage;
        
        private void OnValidate()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void SetDamage(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _damage = value;
        }

        private void OnCollisionEnter(Collision other)
        {
            if(_isProjectileDispose) 
                return;
            
            if (other.gameObject.TryGetComponent( out IDamageable damageable))
            {
                OnTargetCollision(other, damageable);

                if (disposeType == ProjectileDisposeType.OnTargetCollision)
                    DisposeProjectile();
            }
            else
            {
                OnOtherCollision(other);
            }
            
            OnAnyCollision(other);

            if (disposeType == ProjectileDisposeType.OnAnyCollision)
                DisposeProjectile();
        }

        private void DisposeProjectile()
        {
            OnProjectileDispose();
            
            SpawnEffectOnDestroy();
            
            Destroy(gameObject);

            _isProjectileDispose = true;
        }
        
        private void SpawnEffectOnDestroy()
        {
            if(spawnEffectOnDestroy)
                destroyEffectPrefab.Play();
        }


        protected virtual void OnTargetCollision(Collision collision, IDamageable damageable)
        {
            damageable.ApplyDamage(_damage);
        }
        protected virtual void OnOtherCollision(Collision collision) { }
        protected virtual void OnAnyCollision(Collision collision) { }
        protected virtual void OnProjectileDispose() { }

    }
