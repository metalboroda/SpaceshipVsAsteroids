using Lean.Pool;
using SpaceshipVsAsteroids.Props;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceshipVsAsteroids.Level
{
  public class AsteroidsSpawner : MonoBehaviour
  {
    [SerializeField] private List<GameObject> asteroidsToSpawn = new List<GameObject>();

    [Space]
    [SerializeField] private float spawnInterval = 2f;

    [Space]
    [SerializeField] private GameObject asteroidsTarget;

    private void Start()
    {
      StartCoroutine(SpawnAsteroidsWithInterval());
    }

    private IEnumerator SpawnAsteroidsWithInterval()
    {
      while (true)
      {
        SpawnRandomAsteroid();

        yield return new WaitForSeconds(spawnInterval);
      }
    }

    private void SpawnRandomAsteroid()
    {
      if (asteroidsToSpawn.Count == 0) return;

      GameObject asteroidToSpawn = asteroidsToSpawn[Random.Range(0, asteroidsToSpawn.Count)];
      Vector3 spawnPosition = GetRandomSpawnPosition(transform.position, transform.localScale.x);
      Asteroid spawnedAsteroid = LeanPool.Spawn(
        asteroidToSpawn, spawnPosition, Quaternion.identity).GetComponent<Asteroid>();

      spawnedAsteroid.MoveToTarget(
        GetRandomTargetPosition(asteroidsTarget.transform.position, asteroidsTarget.transform.localScale.x));
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