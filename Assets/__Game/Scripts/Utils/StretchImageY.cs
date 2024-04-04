using UnityEngine;

namespace SpaceshipVsAsteroids.Utils
{
  public class StretchImageY : MonoBehaviour
  {
    private RectTransform _imageTransform;

    void Awake()
    {
      _imageTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
      Vector2 imageSize = _imageTransform.sizeDelta;
      Vector2 screenSize = new Vector2(Screen.width, Screen.height);
      float aspectRatio = imageSize.x / imageSize.y;

      imageSize.y = screenSize.y;
      imageSize.x = imageSize.y * aspectRatio;

      _imageTransform.sizeDelta = imageSize;
    }
  }
}