using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class ShipBase : MonoBehaviour
  {
    [field: SerializeField] public int MaxHealth { get; private set; } = 500;
    [field: SerializeField] public int MaxArmor { get; private set; } = 100;
    [field: SerializeField] public int CollisionDamage { get; private set; } = 100;

    protected int currentHealth;
    protected int currentArmor;

    protected virtual void Start()
    {
      InitializeStats();
    }

    protected void InitializeStats()
    {
      currentHealth = MaxHealth;
      currentArmor = MaxArmor;
    }

    public virtual void Damage(int damage)
    {
      int healthBeforeDamage = currentHealth;
      int armorBeforeDamage = currentArmor;

      if (currentArmor > 0)
      {
        int remainingDamage = Mathf.Max(damage - currentArmor, 0);

        currentArmor = Mathf.Max(currentArmor - damage, 0);
        currentHealth -= remainingDamage;
      }
      else
      {
        currentHealth -= damage;
      }

      if (currentHealth <= 0 && healthBeforeDamage > 0)
      {
        currentHealth = 0;
      }
      else if (currentHealth < healthBeforeDamage)
      {
        OnHealthReduced();
      }

      if (armorBeforeDamage != currentArmor)
      {
        OnArmorChanged(currentArmor);
      }
    }

    protected virtual void OnHealthReduced() { }

    protected virtual void OnArmorChanged(int armorValue) { }

    public virtual void IncreaseArmor(int armorValue)
    {
      int previousArmor = currentArmor;

      currentArmor += armorValue;
      currentArmor = Mathf.Clamp(currentArmor, 0, MaxArmor);

      if (previousArmor != currentArmor)
      {
        OnArmorChanged(currentArmor);
      }
    }
  }
}