using UnityEngine;

namespace SpaceshipVsAsteroids.SOs
{
  [CreateAssetMenu(fileName = "ScenesHashes", menuName = "Management/ScenesHashes")]
  public class ScenesHashesSO : ScriptableObject
  {
    [field: SerializeField] public string MainMenuScene { get; private set; }
    [field: SerializeField] public string GameScene { get; private set; }
  }
}