using Lean.Pool;
using SpaceshipVsAsteroids.Ship;
using System;
using UnityEngine;

namespace SpaceshipVsAsteroids.Props
{
  public class ArmorCrystal : MonoBehaviour
  {
    public event Action CrystalDestroyed;

    [SerializeField] private int armorValue;

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out PlayerShip shipArmorHandler))
      {
        shipArmorHandler.IncreaseArmor(armorValue);

        CrystalDestroyed?.Invoke();

        LeanPool.Despawn(gameObject);
      }
    }
  }
}