using Lean.Pool;
using SpaceshipVsAsteroids.Managers;
using SpaceshipVsAsteroids.Ship;
using System;
using UnityEngine;

namespace SpaceshipVsAsteroids.Props
{
  public class CollectibleCrystal : MonoBehaviour
  {
    public event Action CrystalDestroyed;

    [SerializeField] private int collectibleValue;

    private ScoreManager _scoreManager;

    private void Start()
    {
      _scoreManager = ScoreManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.GetComponent<PlayerShip>())
      {
        CrystalDestroyed?.Invoke();

        _scoreManager.IncreaseScore(collectibleValue);

        LeanPool.Despawn(gameObject);
      }
    }
  }
}