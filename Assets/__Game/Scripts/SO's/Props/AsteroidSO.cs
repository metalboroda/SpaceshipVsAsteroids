using UnityEngine;

namespace SpaceshipVsAsteroids.SOs
{
  [CreateAssetMenu(fileName = "Asteroid", menuName = "Props/Asteroid")]
  public class AsteroidSO : ScriptableObject
  {
    [field: SerializeField] public int Health { get; private set; }

    [field: Space]
    [field: SerializeField] public int CollisionDamaged { get; private set; } 

    [field: Space]
    [field: SerializeField] public float MinMovementSpeed { get; private set; }
    [field: SerializeField] public float MaxMovementSpeed { get; private set; }
    [field: SerializeField] public float MinRotationSpeed { get; private set; }
    [field: SerializeField] public float MaxRotationSpeed { get; private set; }
  }
}