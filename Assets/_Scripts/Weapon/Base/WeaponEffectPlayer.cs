using System;
using UnityEngine;

namespace _Scripts.Weapon
{
    public class WeaponEffectPlayer : MonoCache
    {
        [SerializeField] private AudioSource _shootAudio; 
        [SerializeField] private AudioSource _reloadAudio;
        [SerializeField] private ParticleSystem _particle;
        
        private Animator _animator;
        private Weapon _weapon;
        
        private void Awake()
        {
            _weapon = GetComponent<Weapon>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            EventMediator.Reloaded += PlayReload;
            EventMediator.ShotPerformed += PlayShoot;
        }
        private void OnDisable()
        {
            EventMediator.Reloaded -= PlayReload;
            EventMediator.ShotPerformed -= PlayShoot;
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