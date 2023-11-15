using System;
using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Attack_System.Overlap
{
    public class OverlapAttack : MonoBehaviour, IAttackType
    {
        [Header("LayerMasks")]
        [SerializeField] private LayerMask searchLayer;
        [SerializeField] private LayerMask obstacleLayer;

        [Header("Overlap Area")]
        [SerializeField] private Transform overlapPoint;
        [SerializeField] private OverlapType overlapType;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Vector3 boxSize = Vector3.one;
        [SerializeField] private float sphereRadius = 1f;
        
        [Header("Consider Obstacles")]
        [SerializeField] private bool considerObstacles;
        
        [Header("Push Bodies")]
        [SerializeField] private bool pushRigidbodies;
        [SerializeField] private float pushForce;

        private readonly Collider[] _overlapResults = new Collider[32];
        private int _overlapResultsCount;
        
        private float _damage;
        
        
        public void PerformAttack()
        {
            if (TryFindTargets())
            {
                TryAttack();
            }
        }

        private bool TryFindTargets()
        {
            var position = overlapPoint.TransformPoint(offset);

            _overlapResultsCount = overlapType switch
            {
                OverlapType.Box => PerformBoxOverlap(position),
                OverlapType.Sphere => PerformSphereOverlap(position),

                _ => throw new ArgumentOutOfRangeException(nameof(overlapType))
            };

            return _overlapResultsCount > 0;
        }

        private int PerformBoxOverlap(Vector3 position)
        {
            return Physics.OverlapBoxNonAlloc(position, boxSize / 2,
                _overlapResults, overlapPoint.rotation, searchLayer);
        }

        private int PerformSphereOverlap(Vector3 position)
        {
            return Physics.OverlapSphereNonAlloc(position, sphereRadius,
                _overlapResults, searchLayer);
        }

        private void TryAttack()
        {
            if (_overlapResults.Length == 0)
            {
                throw new ArgumentException("Find Target Error");
            }

            for (var i = 0; i < _overlapResultsCount; i++)
            {
                if (_overlapResults[i].TryGetComponent(out IDamageable damageable )== false)
                {
                    continue;
                }

                if (considerObstacles)
                {
                    var colliderPosition = _overlapResults[i].transform.position;
                    var hasObstacle = Physics.Linecast(overlapPoint.position,
                        colliderPosition, obstacleLayer);

                    if (hasObstacle)
                    {
                        continue;
                    }
                }
                
                damageable.ApplyDamage(_damage);

                if (pushRigidbodies == false)
                {
                    continue;
                }

                if (_overlapResults[i].TryGetComponent(out Rigidbody rb))
                {
                    rb.AddForce(-overlapPoint.position * pushForce, ForceMode.Impulse);
                }

            }
            
        }


    }
}