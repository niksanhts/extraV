using System;
using _Scripts.Configs;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Weapon.Base
{
    [RequireComponent(typeof(WeaponEffectPlayer))]
    public abstract class Weapon : MonoCache
    {
        [SerializeField] private WeaponConfig _config;
        
        private WeaponEffectPlayer _effectPlayer;
        private IAttackType _attackType;
        
        private float _fireRate;
        private float _reloadTime;
        private float _lastShotTime;

        private int _maxBullets;
        private int _bulletLeft;
        private int _bulletsInShot;

        private bool _shootingAble = true;
        private float nextShotTime = 0;
        public float Damage { get; private set; }

        private void Init()
        {
            Damage = _config.GetDamage();
            _fireRate = _config.GetFireRate();
            _reloadTime = _config.GetReloadTime();
            _maxBullets = _config.GetMaxBullets();
            _bulletsInShot = _config.GetBulletsInShot();
            
            _bulletLeft = _maxBullets;
            _attackType = GetComponent<IAttackType>();
            _effectPlayer = GetComponent<WeaponEffectPlayer>();

            _lastShotTime = Time.time;
        }

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            EventMediator.PerformBulletCountChanged(_bulletLeft, _maxBullets);
            Init();
        }
    

        public void TryShoot()
        {
            var currentTime = Time.time;
            
            if (_bulletLeft <= 0)
            {
                Reload();
                return;
            }

            if (_shootingAble && (Time.time > nextShotTime))
            {
                nextShotTime = Time.time + 1f / _fireRate;
                Shoot();
            }
        }
        
        public void Reload()
        {
            _shootingAble = false;
            Invoke(nameof(SetShootingAble), _reloadTime);
            _bulletLeft = _maxBullets;
            
            EventMediator.PerformBulletCountChanged(_bulletLeft, _maxBullets);
            _effectPlayer.PlayShoot();
        }
        
        private void Shoot()
        {
            for (var i = 0;  i < _bulletsInShot; i++)
                _attackType.PerformAttack();
            _bulletLeft--;
            
            EventMediator.PerformBulletCountChanged(_bulletLeft, _maxBullets);
            _effectPlayer.PlayShoot();
        }

        private void SetShootingAble() => _shootingAble = true;
    }
}