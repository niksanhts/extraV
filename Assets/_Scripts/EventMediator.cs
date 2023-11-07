using System;

namespace _Scripts
{
    public static class EventMediator
    {
        public static event Action Reloaded;
        public static event Action ShotPerformed;
        public static event Action<int, int> BulletCountChanged;
        public static event Action DashEnabled;
        public static event Action Dashed; 
        public  static event Action<float> HealthChanged;
        public static event Action PlayerDied;

        public static void PerformReloaded() => Reloaded?.Invoke();
        public static void PerformShot() => ShotPerformed?.Invoke();
        public static void PerformBulletCountChanged(int current, int all) 
            => BulletCountChanged?.Invoke(current, all);
        public static void EnableDash() => DashEnabled?.Invoke();
        
        public static void Dash() => Dashed?.Invoke();
        public static void PerformHealthChanged(float value) 
            => HealthChanged?.Invoke(value);
        public static void PerformPlayerDied() => PlayerDied?.Invoke();


    }
}