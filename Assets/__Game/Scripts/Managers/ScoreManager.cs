using UnityEngine;

namespace SpaceshipVsAsteroids.Managers
{
  public class ScoreManager : MonoBehaviour
  {
    public static ScoreManager Instance { get; private set; }

    private int _currentScore;

    private void Awake()
    {
      Instance = this;

      EventManager.RaiseScoreChanged(_currentScore);
    }

    public void IncreaseScore(int score)
    {
      _currentScore += score;

      EventManager.RaiseScoreChanged(_currentScore);
    }
  }
}