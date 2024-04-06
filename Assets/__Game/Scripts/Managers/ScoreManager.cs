using UnityEngine;

namespace SpaceshipVsAsteroids.Managers
{
  public class ScoreManager : MonoBehaviour
  {
    public static ScoreManager Instance { get; private set; }

    private int _currentScore;
    private int _currentAsteroidContacts;

    private void Awake()
    {
      Instance = this;
    }

    private void Start()
    {
      EventManager.RaiseScoreChanged(_currentScore);
      EventManager.RaiseAsteroidContacted(_currentAsteroidContacts);
    }

    public void IncreaseScore(int score)
    {
      _currentScore += score;

      EventManager.RaiseScoreChanged(_currentScore);
    }

    public void IncreaseAsteroidContacts(int contact)
    {
      _currentAsteroidContacts += contact;

      EventManager.RaiseAsteroidContacted(_currentAsteroidContacts);
    }
  }
}