using System;
using UnityEngine;
using Zenject;

namespace _Scripts.Player
{
    public class DashTimer : AbilityTimer
    {
        public void Init(int maxAbilityCount, float abilityRecoveryTime, float dashRate)
        {
            base.Init(maxAbilityCount, abilityRecoveryTime);
            _timeBetweenAbility = dashRate;
        }
        
        protected override void ProcessAbilityEnabled()
        {
            EventMediator.EnableDash();
        }
    }
}