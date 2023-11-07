using System;
using _Scripts.Configs;
using _Scripts.Interfaces;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerEntity : MonoBehaviour, IDamageable
    {

        private float _currentHealth;
        private float _maxHealth;

        [Inject]
        public void Init(PlayerConfig config)
        {
            _maxHealth = config.GetHealth();
            _currentHealth = _maxHealth;
            EventMediator.PerformHealthChanged(_currentHealth);
            Debug.Log(_currentHealth);
        }
        
        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            
            if (_currentHealth - damage <= 0)
                Die();
            _currentHealth -= damage;
            
            EventMediator.PerformHealthChanged(_currentHealth);
            Debug.Log("Damage Applied:" + damage);
        }

        public void Heal(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _currentHealth += value;
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
            
            EventMediator.PerformHealthChanged(_currentHealth);
        }

        private void Die()
        {
            EventMediator.PerformPlayerDied();
        }
    }
}