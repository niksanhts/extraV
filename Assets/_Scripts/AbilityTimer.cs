using System;
using UnityEngine;
using Zenject;

namespace _Scripts
{
    public class AbilityTimer : MonoBehaviour
    {


        private int _abilityCount;
        private int _maxAbilityCount;
        private float _abilityRecoveryTime;
        private float _timer = 0;
        
        protected float _timeBetweenAbility = 0.4f;
        
        public virtual void Init(int maxAbilityCount, float abilityRecoveryTime)
        {
            _abilityRecoveryTime = abilityRecoveryTime;
            _maxAbilityCount = maxAbilityCount;
            _abilityCount = _maxAbilityCount;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (!(_timer >= _abilityRecoveryTime) || _abilityCount >= _maxAbilityCount) return;
            _timer = 0;
            EnableAbility();
        }
        
        public bool CheckAbility() => _abilityCount > 0 && _timer > _timeBetweenAbility;
        public void PerformAbility() => _abilityCount -= 1;

        private void EnableAbility()
        {
            Debug.Log("+dash");
            _abilityCount += 1;
            ProcessAbilityEnabled();
        }

        protected virtual void ProcessAbilityEnabled()
        {
            
        }
    }
}