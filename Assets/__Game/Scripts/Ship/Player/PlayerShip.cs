using SpaceshipVsAsteroids.Interfaces;
using SpaceshipVsAsteroids.SOs;
using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShip : MonoBehaviour, IDamageable
  {
    [SerializeField] private ShipSO shipSO;

    private int _health;

    private void Start()
    {
      _health = shipSO.Health;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IDamageable damageable))
      {
        damageable.Damage(shipSO.CollisionDamaged);
      }
    }

    public void Damage(int damage)
    {
      _health -= damage;

      if (_health <= 0)
      {
        _health = 0;

        DestroyShip();
      }
    }

    private void DestroyShip()
    {
      Destroy(gameObject);
    }
  }
}