using Lean.Pool;
using SpaceshipVsAsteroids.Interfaces;
using SpaceshipVsAsteroids.SOs;
using UnityEngine;

namespace SpaceshipVsAsteroids.Props
{
  public class Asteroid : MonoBehaviour, IDamageable
  {
    [SerializeField] private AsteroidSO asteroidSO;

    private int _health;

    private void Start()
    {
      _health = asteroidSO.Health;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(asteroidSO.CollisionDamaged);
      }
    }

    public void Damage(int damage)
    {
      _health -= damage;

      if (_health <= 0)
      {
        _health = 0;

        DespawnAsteroid();
      }
    }

    public void DespawnAsteroid()
    {
      LeanPool.Despawn(gameObject);
    }
  }
}