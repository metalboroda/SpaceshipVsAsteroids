using UnityEngine;

namespace SpaceshipVsAsteroids.Utils
{
  public class Setup : MonoBehaviour
  {
    [System.Obsolete]
    private void Awake()
    {
      int screenRefreshRate = Screen.currentResolution.refreshRate;
      Application.targetFrameRate = screenRefreshRate;
    }
  }
}