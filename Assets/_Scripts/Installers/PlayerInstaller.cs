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
        public override void InstallBindings()
        {
            //InstallInput();
            //InstallMovement();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void InstallMovement()
        {
            var gravityHandler = new GravityHandler(config.GetGravityForce());
            Container.BindInstance(gravityHandler).AsSingle();
            Container.BindInstance(new JumpHandler(config, gravityHandler)).AsSingle();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void InstallInput()
        {
            Container.BindInstance(new PlayerInput()).AsSingle();
            Container.BindInstance(new InputHandler()).AsSingle();
        }
    }
}