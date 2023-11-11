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
        private Base.Weapon _weapon;
        
        private void Awake()
        {
            _weapon = GetComponent<Base.Weapon>();
            _animator = GetComponent<Animator>();
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