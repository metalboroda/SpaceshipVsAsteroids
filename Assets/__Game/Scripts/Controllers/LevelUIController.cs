using DG.Tweening;
using SpaceshipVsAsteroids.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceshipVsAsteroids.Controllers
{
  public class LevelUIController : MonoBehaviour
  {
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI collectibleCounterText;
    [SerializeField] private Image collectibleIcon;

    private void OnEnable()
    {
      EventManager.ScoreChanged += DisplayCollectibleText;
    }

    private void OnDisable()
    {
      EventManager.ScoreChanged -= DisplayCollectibleText;
    }

    private void DisplayCollectibleText(int score)
    {
      collectibleCounterText.SetText(score.ToString());

      PunchCollectibleIcon();
    }

    private void PunchCollectibleIcon()
    {
      collectibleIcon.transform.DOPunchRotation(new Vector3(0, 0, 25), 0.5f).SetEase(Ease.OutQuad);
    }
  }
}