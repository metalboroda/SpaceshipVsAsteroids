using SpaceshipVsAsteroids.Interfaces;
using SpaceshipVsAsteroids.Managers;
using System;
using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShip : ShipBase, IDamageable
  {
    public event Action PlayerDead;

    protected override void Start()
    {
      base.Start();
    }

    protected override void OnHealthReduced()
    {
      base.OnHealthReduced();

      EventManager.RaisePlayerDamaged();
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(collisionDamage);
      }
    }

    public override void Damage(int damage)
    {
      base.Damage(damage);

      if (currentHealth <= 0)
      {
        PlayerDead?.Invoke();

        Destroy(gameObject);
      }
    }
  }
}