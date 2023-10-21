using _Scripts.Interfaces;

namespace _Scripts.Weapon
{
    public abstract class Weapon : MonoCache
    {
        private IAttackType _attackType;
        private float _damage;
        private float _fireRate;
    }
}