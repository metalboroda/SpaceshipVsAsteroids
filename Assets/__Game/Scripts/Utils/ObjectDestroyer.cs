using Lean.Pool;
using UnityEngine;

namespace SpaceshipVsAsteroids.Utils
{
  public class ObjectDestroyer : MonoBehaviour, IPoolable
  {
    [SerializeField] private bool poolable = false;
    [SerializeField] private float destroyTime = 1f;

    private void Start()
    {
      if (poolable == false)
      {
        Destroy(gameObject, destroyTime);
      }
    }

    public void OnSpawn()
    {
      if (poolable == true)
      {
        LeanPool.Despawn(gameObject, destroyTime);
      }
    }

    public void OnDespawn()
    {
    }
  }
}