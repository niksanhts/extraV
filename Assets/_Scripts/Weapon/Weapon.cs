using System;
using _Scripts.Configs;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Weapon
{
    [RequireComponent(typeof(WeaponEffectPlayer))]
    public abstract class Weapon : MonoCache
    {
        public event Action OnShot;
        public event Action OnReload;

        [SerializeField] private WeaponConfig _config;
        
        private WeaponEffectPlayer _effectPlayer;
        private IAttackType _attackType;
        
        private float _fireRate;
        private float _reloadTime;
        private float _lastShotTime;

        private int _maxBullets;
        private int _bulletLeft;
        private int _bulletsInShot;

        private bool _shootingAble;
        public float Damage { get; private set; }

        public void Awake()
        {
            Damage = _config.GetDamage();
            _fireRate = _config.GetFireRate();
            _reloadTime = _config.GetReloadTime();
            _maxBullets = _config.GetMaxBullets();
            _bulletsInShot = _config.GetBulletsInShot();
            
            _bulletLeft = _maxBullets;
        }

        public void TryShoot()
        {
            var currentTime = Time.time;

            if (_bulletLeft <= 0)
            {
                Reload();
                return;
            }
            
            if (_lastShotTime - currentTime <= (1 / _fireRate) && 
                _shootingAble == false)
            {
                return;
            }

            _lastShotTime = currentTime;
            Shoot();
        }
        
        public void Reload()
        {
            Invoke(nameof(SetShootingAble), _reloadTime);
            _bulletLeft = _maxBullets;
            OnReload?.Invoke();
        }
        
        private void Shoot()
        {
            for (var i = 0;  i < _bulletsInShot; i++)
                _attackType.PerformAttack();
            _bulletLeft--;
            OnShot?.Invoke();
        }

        private void SetShootingAble()
        {
            _shootingAble = true;
        }
    }
}