using System;
using UnityEngine;

namespace _Scripts.Weapon
{
    public class WeaponEffectPlayer : MonoCache
    {
        [SerializeField] private AudioSource _shootAudio; 
        [SerializeField] private AudioSource _reloadAudio;
        
        private Animator _animator;
        private ParticleSystem _particle;
        private Weapon _weapon;
        
        private void Awake()
        {
            _weapon = GetComponent<Weapon>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _weapon.OnShot += PlayShoot;
            _weapon.OnReload += PlayReload;
        }
        private void OnDisable()
        {
            _weapon.OnShot -= PlayShoot;
            _weapon.OnReload -= PlayReload;
        }
        public void PlayShoot()
        {
            _particle.Play();
        }

        public void PlayReload()
        {
        }
    }
}