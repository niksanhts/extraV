using System;
using _Scripts.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Scripts.Enviarment
{
    [RequireComponent(typeof(Collider))]
    public class GunPedestal : MonoCache
    {
        [SerializeField] private Weapon.Base.Weapon weapon;
        [SerializeField] private Transform holder;

        private void Start()
        {
            ObjectPool.Spawn(weapon, holder.position, holder.rotation, holder);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out IWeaponEquip weaponEquip)) 
                return;
            weaponEquip.EquipWeapon(weapon);
            ObjectPool.Despawn(this);
        }
    }
}