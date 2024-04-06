using Lean.Pool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SpaceshipVsAsteroids.Visual
{
  public abstract class ObjectVisualHandlerBase<T> : MonoBehaviour where T : MonoBehaviour
  {
    [SerializeField] protected AssetReferenceGameObject DestroyVFXReference;

    private GameObject destroyVFXPrefab;

    protected T Target;

    protected virtual void Awake()
    {
      Target = GetComponent<T>();
    }

    protected virtual void Start()
    {
      LoadDestroyVFX();
    }

    protected virtual void OnEnable()
    {
      SubscribeEvents();
    }

    protected virtual void OnDisable()
    {
      UnsubscribeEvents();
    }

    protected virtual void OnDestroy()
    {
      UnloadDestroyVFX();
    }

    protected abstract void SubscribeEvents();
    protected abstract void UnsubscribeEvents();

    protected virtual async void LoadDestroyVFX()
    {
      AsyncOperationHandle<GameObject> handle = DestroyVFXReference.LoadAssetAsync<GameObject>();

      await handle.Task;

      if (handle.Status == AsyncOperationStatus.Succeeded)
      {
        destroyVFXPrefab = handle.Result;
      }
      else
      {
        Debug.LogError("Failed to load DestroyVFX prefab!");
      }
    }

    protected virtual void SpawnDestroyVFX()
    {
      if (destroyVFXPrefab == null)
      {
        Debug.LogWarning("DestroyVFX prefab is not loaded yet!");

        return;
      }

      LeanPool.Spawn(destroyVFXPrefab, transform.position, transform.rotation);
    }

    protected virtual void UnloadDestroyVFX()
    {
      if (destroyVFXPrefab != null)
      {
        Addressables.ReleaseInstance(destroyVFXPrefab);

        destroyVFXPrefab = null;
      }
    }
  }
}