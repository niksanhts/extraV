using _Scripts.Interfaces;
using UnityEngine;

namespace _Scripts.Attack_System
{
    public class OverlapAttack : MonoBehaviour, IAttackType
    {
        public void PerformAttack()
        {
            PerformOverlap();
        }

        private void PerformOverlap()
        {
            
        }
    }
}