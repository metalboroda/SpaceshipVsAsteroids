using DG.Tweening;
using UnityEngine;

namespace SpaceshipVsAsteroids.Managers
{
  public class CameraManager : MonoBehaviour
  {
    private Camera _mainCamera;

    private void Awake()
    {
      _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
      EventManager.PlayerDamaged += CameraPunchRotation;
    }

    private void OnDisable()
    {
      EventManager.PlayerDamaged -= CameraPunchRotation;
    }

    private void CameraPunchRotation()
    {
      _mainCamera.transform.DOPunchRotation(new Vector3(0, 1, 0), 0.25f, 50, 1).SetEase(Ease.OutSine);
    }
  }
}