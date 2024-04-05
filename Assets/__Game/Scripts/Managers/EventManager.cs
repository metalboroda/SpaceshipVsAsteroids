using UnityEngine.Events;

namespace SpaceshipVsAsteroids.Managers
{
  public static class EventManager
  {
    #region Player
    public static event UnityAction PlayerDamaged;
    public static void RaisePlayerDamaged() => PlayerDamaged?.Invoke();
    #endregion
  }
}