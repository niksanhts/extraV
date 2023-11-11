using System;
using _Scripts.Interfaces;
using UnityEngine;

    //[SelectionBase]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoCache
    { 
        [Header("Rigidbody")] 
        [SerializeField] public new Rigidbody rigidbody;

        [Header("Effects")]
        [SerializeField] private bool spawnEffectOnDestroy = true;
        [SerializeField] private ParticleSystem destroyEffectPrefab;

        [SerializeField] 
        private ProjectileDisposeType disposeType = ProjectileDisposeType.OnAnyCollision;

        [SerializeField] private float lifeTime;
        
        private float currentLifeTime;
        private float _damage;
        
        private void OnValidate() => rigidbody = GetComponent<Rigidbody>();

        public void Init(float damage)
        {
            SetDamage(damage);
            currentLifeTime = lifeTime;
        }

        public void SetDamage(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));
            _damage = value;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
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

        private void Update()
        {
            currentLifeTime -= Time.deltaTime;
            
            if (currentLifeTime < 0)
                DisposeProjectile();
        }

        private void DisposeProjectile()
        {
            OnProjectileDispose();
            
            SpawnEffectOnDestroy();
            
            ObjectPool.Despawn(this);
            
            currentLifeTime = lifeTime;
            rigidbody.velocity = Vector3.zero;
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
