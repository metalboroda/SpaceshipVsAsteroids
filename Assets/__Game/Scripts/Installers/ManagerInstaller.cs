using SpaceshipVsAsteroids.Managers;
using UnityEngine;
using Zenject;

namespace SpaceshipVsAsteroids.Installers
{
  public class ManagerInstaller : MonoInstaller
  {
    [SerializeField] private GameManager _gameManager;

    public override void InstallBindings()
    {
      Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
    }
  }
}