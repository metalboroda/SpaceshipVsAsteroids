using Lean.Pool;
using UnityEngine;

namespace SpaceshipVsAsteroids.Visual
{
  public abstract class ObjectVisualHandlerBase<T> : MonoBehaviour where T : MonoBehaviour
  {
    [SerializeField] protected GameObject DestroyVFX;

    protected T Target;

    protected virtual void Awake()
    {
      Target = GetComponent<T>();
    }

    protected virtual void Start() { }

    protected virtual void OnEnable()
    {
      SubscribeEvents();
    }

    protected virtual void OnDisable()
    {
      UnsubscribeEvents();
    }

    protected abstract void SubscribeEvents();
    protected abstract void UnsubscribeEvents();

    protected virtual void SpawnDestroyVFX()
    {
      LeanPool.Spawn(DestroyVFX, transform.position, transform.rotation);
    }
  }
}