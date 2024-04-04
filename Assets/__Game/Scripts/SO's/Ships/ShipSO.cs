using UnityEngine;

namespace SpaceshipVsAsteroids.SOs
{
  [CreateAssetMenu(fileName = "Ship", menuName = "ShipsSettings/Ship")]
  public class ShipSO : ScriptableObject
  {
    [field: SerializeField] public float MovementForce { get; private set; } = 15f;
    [field: SerializeField] public float RotationMultiplier { get; private set; } = 50f;
    [field: SerializeField] public float RotationDuration { get; private set; } = 10f;
  }
}