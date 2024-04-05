using UnityEngine;

namespace SpaceshipVsAsteroids.Utils
{
  public class StretchObjectZ : MonoBehaviour
  {
    void Start()
    {
      Vector3 objectSize = transform.localScale;
      float aspectRatio = objectSize.x / objectSize.z;

      objectSize.z = Camera.main.transform.position.y;
      objectSize.x = objectSize.z * aspectRatio;

      transform.localScale = objectSize;
    }
  }
}
