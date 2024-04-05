using SpaceshipVsAsteroids.Interfaces;
using SpaceshipVsAsteroids.Managers;
using System;
using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShip : MonoBehaviour, IDamageable
  {
    public event Action PlayerDead;

    [SerializeField] private int health = 1000;

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

      EventManager.RaisePlayerDamaged();

      if (_currentHealth <= 0)
      {
        _currentHealth = 0;

        PlayerDead?.Invoke();

        DestroyShip();
      }
    }

    private void DestroyShip()
    {
      Destroy(gameObject);
    }
  }
}