using System;
using _Scripts.Configs;
using _Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace _Scripts.Weapon
{
    [RequireComponent(typeof(WeaponEffectPlayer))]
    [RequireComponent(typeof(IAttackType))]
    public abstract class Weapon : MonoCache
    {
        public static Action OnShot;
        public static Action OnReload;
        
        private WeaponEffectPlayer _effectPlayer;
        private IAttackType _attackType;
        
        private float _fireRate;
        private float _reloadTime;

        private int _maxBullets;
        private int _bulletLeft;
        private int _bulletsInShot;

        public float Damage { get; private set; }

        public void Init(WeaponConfig config)
        {
            Damage = config.GetDamage();
            _fireRate = config.GetFireRate();
            _reloadTime = config.GetReloadTime();
            _maxBullets = config.GetMaxBullets();
            _bulletsInShot = config.GetBulletsInShot();
            
            _bulletLeft = _maxBullets;
        }

        public void TryShoot()
        {
            if (_bulletLeft > 0) Shoot();
            else Reload();
        }
        public void Reload()
        {
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
    }
}