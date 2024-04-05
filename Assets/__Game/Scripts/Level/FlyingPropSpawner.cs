using Lean.Pool;
using SpaceshipVsAsteroids.Props;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceshipVsAsteroids.Level
{
  public class FlyingPropSpawner : MonoBehaviour
  {
    [SerializeField] private List<GameObject> asteroidsToSpawn = new List<GameObject>();
    [SerializeField] private List<GameObject> crystalsToSpawn = new List<GameObject>();

    [Space]
    [SerializeField] private float asteroidSpawnInterval = 1.5f;
    [SerializeField] private float minCrystalSpawnInterval = 7.5f;
    [SerializeField] private float maxCrystalSpawnInterval = 15f;

    [Space]
    [SerializeField] private GameObject flyingPropTarget;

    private void Start()
    {
      StartCoroutine(SpawnWithInterval(
          asteroidSpawnInterval, asteroidsToSpawn, SpawnObject));
      StartCoroutine(SpawnWithInterval(
          Random.Range(minCrystalSpawnInterval, maxCrystalSpawnInterval), crystalsToSpawn, SpawnObject));
    }

    private IEnumerator SpawnWithInterval(
        float interval, List<GameObject> objectsToSpawn, System.Action<GameObject> spawnAction)
    {
      while (true)
      {
        yield return new WaitForSeconds(interval);

        GameObject objectPrefab = GetRandomObject(objectsToSpawn);

        if (objectPrefab != null)
        {
          spawnAction.Invoke(objectPrefab);
        }
      }
    }

    private void SpawnObject(GameObject objectPrefab)
    {
      if (objectPrefab == null) return;

      Vector3 spawnPosition = GetRandomSpawnPosition(transform.position, transform.localScale.x);
      FlyingPropMovement spawnedObject = LeanPool.Spawn(
          objectPrefab, spawnPosition, Quaternion.identity).GetComponent<FlyingPropMovement>();

      spawnedObject.Init(GetRandomTargetPosition(
          flyingPropTarget.transform.position, flyingPropTarget.transform.localScale.x));
    }

    private GameObject GetRandomObject(List<GameObject> objects)
    {
      if (objects.Count == 0) return null;

      return objects[Random.Range(0, objects.Count)];
    }

    private Vector3 GetRandomPosition(Vector3 basePosition, float objectScaleX)
    {
      Vector3 position = basePosition;
      float randomX = Random.Range(-objectScaleX / 2f, objectScaleX / 2f);

      position.x += randomX;

      return position;
    }

    private Vector3 GetRandomSpawnPosition(Vector3 basePosition, float objectScaleX)
    {
      return GetRandomPosition(basePosition, objectScaleX);
    }

    private Vector3 GetRandomTargetPosition(Vector3 basePosition, float objectScaleX)
    {
      return GetRandomPosition(basePosition, objectScaleX);
    }
  }
}