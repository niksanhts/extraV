using System;
using _Scripts.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.Enviarment
{
    [RequireComponent(typeof(Collider))]
    public class GunPedestal : MonoCache
    {
        [SerializeField] private Weapon.Weapon weapon;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out IWeaponPicker weaponPicker)) 
                return;
            weaponPicker.PickUpWeapon(weapon);
            ObjectPool.Despawn(this);
        }
    }
}