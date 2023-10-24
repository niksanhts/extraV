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
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Weapon.OnShot += PlayShoot;
            Weapon.OnReload += PlayReload;
        }
        private void OnDisable()
        {
            Weapon.OnShot -= PlayShoot;
            Weapon.OnReload -= PlayReload;
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