using Lean.Pool;
using SpaceshipVsAsteroids.Interfaces;
using System;
using UnityEngine;

namespace SpaceshipVsAsteroids.Props
{
  public class Asteroid : MonoBehaviour, IDamageable
  {
    public event Action AsteroidDestroyed;

    [SerializeField] private int health = 100;

    [Space]
    [SerializeField] private int collisionDamage = 100;

    private int _currentHealth;

    private void Start()
    {
      _currentHealth = health;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(collisionDamage);
      }
    }

    public void Damage(int damage)
    {
      _currentHealth -= damage;

      if (_currentHealth <= 0)
      {
        _currentHealth = 0;

        AsteroidDestroyed?.Invoke();

        LeanPool.Despawn(gameObject);
      }
    }
  }
}