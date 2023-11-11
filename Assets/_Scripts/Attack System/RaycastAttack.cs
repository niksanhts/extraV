using _Scripts.Interfaces;
using _Scripts.Weapon;
using _Scripts.Weapon.Base;
using UnityEngine;
using Random = UnityEngine.Random;


    [RequireComponent(typeof(Weapon))]
    public class RaycastAttack : MonoBehaviour, IAttackType
    {
        [Header("Ray")]
        [SerializeField] private LayerMask layerMask;
        [SerializeField, Min(0f)] private float distance = 100f;
        [SerializeField, Min(0f)] private int shotCount = 1;

        [Header("Spread")]
        [SerializeField] private bool useSpread;
        [SerializeField, Min(0f)] private float spreadFactor = 1f;
        
        private float _damage;
        private void Start()
        {
            var weapon = GetComponent<Weapon>();
            _damage = weapon.Damage;
        }

        public void PerformAttack() 
        {
            for (var i = 0; i < shotCount; i++)
                PerformRaycast();
        }

        private void PerformRaycast() 
        {
            var direction = useSpread ? transform.forward + CalculateSpread() : transform.forward;
            var ray = new Ray(transform.position, direction);

            if (!Physics.Raycast(ray, out var hitInfo, distance, layerMask)) return;
            
            var hitCollider = hitInfo.collider;

            if (hitCollider.TryGetComponent(out IDamageable damageable))
                damageable.ApplyDamage(_damage);
        }

        private Vector3 CalculateSpread() 
        {
            return new Vector3
            {
                x = Random.Range(-spreadFactor, spreadFactor),
                y = Random.Range(-spreadFactor, spreadFactor),
                z = Random.Range(-spreadFactor, spreadFactor)
            };
        }
    }

