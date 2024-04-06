using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceshipVsAsteroids.Managers
{
  public class MainMenuUIManager : MonoBehaviour
  {
    [SerializeField] private Button mainMenuStartBtn;

    [Inject] private ScenesManager _scenesManager;

    private void Start()
    {
      SubscribeButtons();
    }

    private void SubscribeButtons()
    {
      mainMenuStartBtn.onClick.AddListener(() => { _scenesManager.ToGameScene(); });
    }
  }
}