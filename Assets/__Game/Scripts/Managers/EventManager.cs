using UnityEngine.Events;

namespace SpaceshipVsAsteroids.Managers
{
  public static class EventManager
  {
    #region Player
    public static event UnityAction PlayerDamaged;
    public static void RaisePlayerDamaged() => PlayerDamaged?.Invoke();

    public static event UnityAction<int> PlayerHealthChanged;
    public static void RaisePlayerHealthChanged(int health) => PlayerHealthChanged?.Invoke(health);

    public static event UnityAction OnArmorReceived;
    public static void RaiseArmorReceived() => OnArmorReceived?.Invoke();

    public static event UnityAction<int> PlayerArmorChanged;
    public static void RaisePlayerArmorChanged(int armor) => PlayerArmorChanged?.Invoke(armor);

    public static event UnityAction PlayerDead;
    public static void RaisePlayerDead() => PlayerDead?.Invoke();
    #endregion

    #region Score
    public static event UnityAction<int> ScoreChanged;
    public static void RaiseScoreChanged(int score) => ScoreChanged?.Invoke(score);
    #endregion
  }
}