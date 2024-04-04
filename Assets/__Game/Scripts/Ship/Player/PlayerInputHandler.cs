using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerInputHandler : MonoBehaviour
  {
    public float GetXInput()
    {
      float inputX = 0f;

      if (Input.touchCount > 0)
      {
        Touch touch = Input.GetTouch(0);

        inputX = (touch.position.x < Screen.width / 2) ? -1f : 1f;
      }
      else if (Input.GetMouseButton(0))
      {
        inputX = (Input.mousePosition.x < Screen.width / 2) ? -1f : 1f;
      }

      return inputX;
    }
  }
}