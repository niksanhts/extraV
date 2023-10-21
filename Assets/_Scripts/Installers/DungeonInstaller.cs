using _Scripts.Configs;
using _Scripts.Dungeon_Generators;
using _Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.Installers
{
    public class DungeonInstaller : MonoInstaller
    {
        [SerializeField] private ChunkConfig chunkConfig;
        
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.BindInstance<IDungeonGenerator>(new RandomDungeonGenerator(chunkConfig)).AsSingle();
        }
    }
}