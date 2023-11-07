using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class HealthViewer : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        
        private void OnEnable() 
            => EventMediator.HealthChanged += OnHealthChanged;
        private void OnDisable() 
            => EventMediator.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(float value)
        {
            healthBar.value = value;
        }
    }
}