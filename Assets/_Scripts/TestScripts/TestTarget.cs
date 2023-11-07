using System.Globalization;
using _Scripts.Interfaces;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts
{
    public class TestTarget : MonoCache, IDamageable
    {
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private ParticleSystem _particle;
        
        public void ApplyDamage(float damage)
        {
            _text.text = damage.ToString();
            _particle.Play();
        }
    }
}