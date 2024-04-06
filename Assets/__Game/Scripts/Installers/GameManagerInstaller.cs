using SpaceshipVsAsteroids.Managers;
using UnityEngine;
using Zenject;

namespace SpaceshipVsAsteroids.Installers
{
  public class GameManagerInstaller : MonoInstaller
  {
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ScenesManager scenesManager;

    public override void InstallBindings()
    {
      Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
      Container.Bind<ScenesManager>().FromInstance(scenesManager).AsSingle();
    }
  }
}