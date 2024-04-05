using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class ShipBase : MonoBehaviour
  {
    [field: SerializeField] public int MaxHealth { get; private set; } = 500;
    [field: SerializeField] public int MaxArmor { get; private set; } = 100;
    [field: SerializeField] public int CollisionDamage { get; private set; } = 100;

    protected int CurrentHealth;
    protected int CurrentArmor;

    protected virtual void Start()
    {
      InitializeStats();
    }

    protected void InitializeStats()
    {
      CurrentHealth = MaxHealth;
      CurrentArmor = MaxArmor;
    }

    public virtual void Damage(int damage)
    {
      int healthBeforeDamage = CurrentHealth;
      int armorBeforeDamage = CurrentArmor;

      if (CurrentArmor > 0)
      {
        int remainingDamage = Mathf.Max(damage - CurrentArmor, 0);

        CurrentArmor = Mathf.Max(CurrentArmor - damage, 0);
        CurrentHealth -= remainingDamage;
      }
      else
      {
        CurrentHealth -= damage;
      }

      if (CurrentHealth <= 0 && healthBeforeDamage > 0)
      {
        CurrentHealth = 0;
      }
      else if (CurrentHealth < healthBeforeDamage)
      {
        OnHealthReduced();
      }

      if (armorBeforeDamage != CurrentArmor)
      {
        OnArmorChanged(CurrentArmor);
      }
    }

    protected virtual void OnHealthReduced() { }

    protected virtual void OnArmorChanged(int armorValue) { }

    public virtual void IncreaseArmor(int armorValue)
    {
      int previousArmor = CurrentArmor;

      CurrentArmor += armorValue;
      CurrentArmor = Mathf.Clamp(CurrentArmor, 0, MaxArmor);

      if (previousArmor != CurrentArmor)
      {
        OnArmorChanged(CurrentArmor);
      }
    }
  }
}