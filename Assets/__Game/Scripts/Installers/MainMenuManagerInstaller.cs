using SpaceshipVsAsteroids.Managers;
using UnityEngine;
using Zenject;

namespace SpaceshipVsAsteroids.Installers
{
  public class MainMenuManagerInstaller : MonoInstaller
  {
    [SerializeField] private ScenesManager scenesManager;

    public override void InstallBindings()
    {
      Container.Bind<ScenesManager>().FromInstance(scenesManager).AsSingle();
    }
  }
}