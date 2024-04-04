using UnityEngine;

namespace SpaceshipVsAsteroids.Utils
{
  public class XScreenScaler : MonoBehaviour
  {
    [SerializeField] private float scaleDecreasePercent = 0.9f;

    private void Start()
    {
      SetXScale();
    }

    private void SetXScale()
    {
      float screenWidth = Screen.width;
      Camera mainCamera = Camera.main;
      float screenWorldWidth = mainCamera.ScreenToWorldPoint(
          new Vector3(screenWidth, 0f, 0f)).x - mainCamera.ScreenToWorldPoint(Vector3.zero).x;
      Vector3 newScale = transform.localScale;

      newScale.x *= screenWorldWidth / transform.localScale.x;
      newScale *= scaleDecreasePercent;
      transform.localScale = newScale;
    }
  }
}
