using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerInputHandler : MonoBehaviour
  {
    public Vector2 GetInput()
    {
      Vector2 input = Vector2.zero;

      if (Input.touchCount > 0)
      {
        Touch touch = Input.GetTouch(0);

        input.x = (touch.position.x < Screen.width / 2) ? -1f : 1f;
      }
      else if (Input.GetMouseButton(0))
      {
        input.x = (Input.mousePosition.x < Screen.width / 2) ? -1f : 1f;
      }

      return input;
    }
  }
}