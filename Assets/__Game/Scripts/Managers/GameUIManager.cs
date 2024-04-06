using DG.Tweening;
using SpaceshipVsAsteroids.Enums;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceshipVsAsteroids.Managers
{
  public class GameUIManager : MonoBehaviour
  {
    [Header("Canvases")]
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject endGameCanvas;

    [Header("Collectible")]
    [SerializeField] private TextMeshProUGUI collectibleCounterText;
    [SerializeField] private Image collectibleIcon;

    [Header("AsteroidContacts")]
    [SerializeField] private TextMeshProUGUI asteroidContactsCounterText;
    [SerializeField] private Image asteroidContactsIcon;

    [Header("Game")]
    [SerializeField] private Button gamePauseBtn;

    [Header("Pause")]
    [SerializeField] private Button pausePlayBtn;
    [SerializeField] private Button pauseRestartBtn;
    [SerializeField] private Button pauseExitBtn;

    [Header("EndGame")]
    [SerializeField] private Button endGameRestartBtn;
    [SerializeField] private Button endGameExitBtn;

    private List<GameObject> _canvases = new List<GameObject>();

    [Inject] private ScenesManager _scenesManager;

    private void OnEnable()
    {
      EventManager.GameStateChanged += SwitchCanvas;
      EventManager.ScoreChanged += DisplayCollectibleText;
      EventManager.AsteroidContacted += DisplayAsteroidContactsText;
    }

    private void OnDisable()
    {
      EventManager.GameStateChanged -= SwitchCanvas;
      EventManager.ScoreChanged -= DisplayCollectibleText;
      EventManager.AsteroidContacted -= DisplayAsteroidContactsText;
    }

    private void Start()
    {
      InitCanvases();
      SubscribeButtons();
    }

    private void InitCanvases()
    {
      _canvases.Add(gameCanvas);
      _canvases.Add(pauseCanvas);
      _canvases.Add(endGameCanvas);
    }

    private void SubscribeButtons()
    {
      gamePauseBtn.onClick.AddListener(() => { EventManager.RaiseGameStateChanged(GameState.Pause); });

      pausePlayBtn.onClick.AddListener(() => { EventManager.RaiseGameStateChanged(GameState.Play); });
      pauseRestartBtn.onClick.AddListener(() => { _scenesManager.RestartScene(); });
      pauseExitBtn.onClick.AddListener(() => { _scenesManager.ToMainMenuScene(); });

      endGameRestartBtn.onClick.AddListener(() => { _scenesManager.RestartScene(); });
      endGameExitBtn.onClick.AddListener(() => { _scenesManager.ToMainMenuScene(); });
    }

    private void SwitchCanvas(GameState gameState)
    {
      foreach (var canvas in _canvases)
      {
        canvas.SetActive(false);
      }

      switch (gameState)
      {
        case GameState.Play:
          gameCanvas.SetActive(true);
          break;
        case GameState.Pause:
          pauseCanvas.SetActive(true);
          break;
        case GameState.EndGame:
          endGameCanvas.SetActive(true);
          break;
      }
    }

    private void DisplayCollectibleText(int score)
    {
      collectibleCounterText.SetText(score.ToString());

      PunchCollectibleIcon();
    }

    private void DisplayAsteroidContactsText(int contacts)
    {
      asteroidContactsCounterText.SetText(contacts.ToString());

      PunchAsteroidContactsIcon();
    }

    private void PunchCollectibleIcon()
    {
      PunchIcon(collectibleIcon);
    }

    private void PunchAsteroidContactsIcon()
    {
      PunchIcon(asteroidContactsIcon);
    }

    private void PunchIcon(Image icon)
    {
      icon.transform.DOPunchRotation(new Vector3(0, 0, 25), 0.5f).SetEase(Ease.OutQuad);

    }
  }
}