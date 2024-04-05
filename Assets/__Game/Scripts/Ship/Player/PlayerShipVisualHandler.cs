using Lean.Pool;
using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShipVisualHandler : MonoBehaviour
  {
    [SerializeField] private GameObject destroyVFX;

    private PlayerShip _playerShip;

    private void Awake()
    {
      _playerShip = GetComponent<PlayerShip>();
    }

    private void OnEnable()
    {
      _playerShip.PlayerDead += SpawnDestroyVFX;
    }

    private void OnDisable()
    {
      _playerShip.PlayerDead -= SpawnDestroyVFX;
    }

    private void SpawnDestroyVFX()
    {
      LeanPool.Spawn(destroyVFX, transform.position, transform.rotation);
    }
  }
}