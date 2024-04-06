using SpaceshipVsAsteroids.Enums;
using UnityEngine;

namespace SpaceshipVsAsteroids.Managers
{
  public class GameManager : MonoBehaviour
  {
    public GameState GameState { get; private set; } = GameState.Play;

    private void OnEnable()
    {
      EventManager.GameStateChanged += SwitchGamePause;
    }

    private void OnDisable()
    {
      EventManager.GameStateChanged -= SwitchGamePause;
    }

    private void Start()
    {
      ChangeState(GameState.Play);
    }

    public void ChangeState(GameState newState)
    {
      GameState = newState;

      EventManager.RaiseGameStateChanged(GameState);
    }

    private void SwitchGamePause(GameState state)
    {
      switch (state)
      {
        case GameState.Play:
          Time.timeScale = 1f;
          break;
        case GameState.Pause:
          Time.timeScale = 0f;
          break;
        case GameState.EndGame:
          break;
      }
    }
  }
}