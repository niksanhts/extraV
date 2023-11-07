using _Scripts.Configs;
using _Scripts.Input;
using _Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig config;
        [SerializeField] private InputHandler _inputHandler;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<PlayerConfig>().FromInstance(config).AsSingle().NonLazy();
            //InstallInput();
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void InstallInput()
        {
            Container.BindInstance(new PlayerInput()).AsSingle();
            Container.BindInstance(_inputHandler).AsSingle();
        }
    }
}