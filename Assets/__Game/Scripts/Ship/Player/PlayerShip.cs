using SpaceshipVsAsteroids.Interfaces;
using SpaceshipVsAsteroids.Managers;
using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShip : ShipBase, IDamageable
  {
    protected override void Start()
    {
      base.Start();
    }

    protected override void OnHealthReduced()
    {
      base.OnHealthReduced();

      EventManager.RaisePlayerDamaged();
    }

    protected override void OnArmorChanged(int armorValue)
    {
      base.OnArmorChanged(armorValue);

      EventManager.RaisePlayerArmorChanged(armorValue);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(CollisionDamage);
      }
    }

    public override void Damage(int damage)
    {
      base.Damage(damage);

      EventManager.RaisePlayerHealthChanged(CurrentHealth);

      if (CurrentHealth <= 0)
      {
        EventManager.RaisePlayerDead();
        EventManager.RaiseGameStateChanged(Enums.GameState.EndGame);

        Destroy(gameObject);
      }
    }

    public override void IncreaseArmor(int armorValue)
    {
      base.IncreaseArmor(armorValue);

      EventManager.RaiseArmorReceived();
    }
  }
}