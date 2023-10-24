using System;
using _Scripts.Configs;
using _Scripts.Interfaces;
using Zenject;

namespace _Scripts.Player
{
    public class PlayerEntity : IDamageable
    {
        public static Action<float> HealthChanged;
        public static Action PlayerDied;

        private float _currentHealth;
        private float _maxHealth;

        [Inject]
        public void Init(PlayerConfig config)
        {
            _maxHealth = config.GetHealth();
            _currentHealth = _maxHealth;
        }
        
        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            
            if (_currentHealth - damage <= 0)
                Die();
            damage -= damage;
            
            HealthChanged?.Invoke(_currentHealth);
        }

        public void Heal(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _currentHealth += value;
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
            
            HealthChanged?.Invoke(_currentHealth);
        }

        private void Die()
        {
            PlayerDied?.Invoke();
        }
    }
}