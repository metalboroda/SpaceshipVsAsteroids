using SpaceshipVsAsteroids.SOs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceshipVsAsteroids.Managers
{
  public class ScenesManager : MonoBehaviour
  {
    [SerializeField] private ScenesHashesSO scenesHashesSO;

    public void ToMainMenuScene()
    {
      SceneManager.LoadScene(scenesHashesSO.MainMenuScene, LoadSceneMode.Single);
    }

    public void ToGameScene()
    {
      SceneManager.LoadScene(scenesHashesSO.GameScene, LoadSceneMode.Single);
    }

    public void RestartScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}