using Lean.Pool;
using UnityEngine;

namespace SpaceshipVsAsteroids.Props
{
  public class AsteroidVisualHandler : MonoBehaviour
  {
    [SerializeField] private GameObject destroyVFX;

    private Asteroid _asteroid;

    private void Awake()
    {
      _asteroid = GetComponent<Asteroid>();
    }

    private void OnEnable()
    {
      _asteroid.AsteroidDestroyed += SpawnDestroyVFX;
    }

    private void OnDisable()
    {
      _asteroid.AsteroidDestroyed -= SpawnDestroyVFX;
    }

    private void SpawnDestroyVFX()
    {
      LeanPool.Spawn(destroyVFX, transform.position, transform.rotation);
    }
  }
}