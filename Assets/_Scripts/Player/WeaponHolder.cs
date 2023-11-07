using System.Collections.Generic;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Player
{
    public class WeaponHolder : MonoBehaviour, IWeaponPicker
    {
        [SerializeField] private List<Weapon.Weapon> _weapons = new List<Weapon.Weapon>();
        private int currentWeaponIndex = 0;
        
        public void PickUpWeapon(Weapon.Weapon weapon)
        {
            ObjectPool.Despawn(weapon);
            var obj= ObjectPool.Spawn(weapon, transform.position, transform.rotation, this);
            _weapons.Add(weapon.GetComponent<Weapon.Weapon>());
            SelectWeapon(currentWeaponIndex - 1);
        }

        public void PerformShoot() => _weapons[currentWeaponIndex].TryShoot();
        public void PerformReload() => _weapons[currentWeaponIndex].Reload();
        
        public void TakeNextWeapon()
        {
            if (currentWeaponIndex == _weapons.Count - 1)
                SelectWeapon(0);
            else
                SelectWeapon(currentWeaponIndex + 1);
        }
        
        public void TakePreviousWeapon()
        {
            if (currentWeaponIndex == 0)
                SelectWeapon(_weapons.Count - 1);
            else
                SelectWeapon(currentWeaponIndex - 1);
        }

        public void TakeWeapon(int index)
        {
            if (index < 0 || index > _weapons.Count) return;
            SelectWeapon(index - 1);
        }

        private void SelectWeapon(int id)
        {
            _weapons[currentWeaponIndex].gameObject.SetActive(false);
            currentWeaponIndex = id;
            _weapons[currentWeaponIndex].gameObject.SetActive(true);
        }
    }
}