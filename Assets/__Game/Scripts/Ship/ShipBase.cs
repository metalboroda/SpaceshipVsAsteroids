using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class ShipBase : MonoBehaviour
  {
    [SerializeField] protected int maxHealth = 500;
    [SerializeField] protected float maxArmor = 100;
    [SerializeField] protected int collisionDamage = 100;

    protected int currentHealth;
    protected float currentArmor;

    protected virtual void Start()
    {
      InitializeStats();
    }

    protected void InitializeStats()
    {
      currentHealth = maxHealth;
      currentArmor = maxArmor;
    }

    public void IncreaseArmor(int armorValue)
    {
      currentArmor += armorValue;
      currentArmor = Mathf.Clamp(currentArmor, 0, maxArmor);
    }

    public virtual void Damage(int damage)
    {
      int healthBeforeDamage = currentHealth;

      if (currentArmor > 0)
      {
        int remainingDamage = Mathf.Max(damage - (int)currentArmor, 0);

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
    }

    protected virtual void OnHealthReduced() { }
  }
}