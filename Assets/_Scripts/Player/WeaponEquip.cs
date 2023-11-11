using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Player
{
    public class WeaponEquip : MonoCache, IWeaponEquip
    {
        [SerializeField] private WeaponHolder _weaponHolder;
        
        public void EquipWeapon(Weapon.Base.Weapon weapon)
        {
            var holderTransform = _weaponHolder.transform;
            var weaponTransform = weapon.transform;
            
            weaponTransform.position = holderTransform.position;
            weaponTransform.rotation = holderTransform.rotation;
            weaponTransform.SetParent(holderTransform);
            
            _weaponHolder.Add(weapon);
        }
    }
}