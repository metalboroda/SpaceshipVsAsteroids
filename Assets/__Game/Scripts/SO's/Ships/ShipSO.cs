using UnityEngine;

namespace SpaceshipVsAsteroids.SOs
{
  [CreateAssetMenu(fileName = "Ship", menuName = "ShipsSettings/Ship")]
  public class ShipSO : ScriptableObject
  {
    [field: SerializeField] public float MovementForce { get; set; } = 15f;
  }
}