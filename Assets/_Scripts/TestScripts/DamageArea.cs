using System;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts
{
    public class DamageArea : MonoBehaviour
    {
        [SerializeField, Min(1)] private float damage;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Damage trigger enter");
            if (other.gameObject.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(damage);
            }
        }
        
    }
}