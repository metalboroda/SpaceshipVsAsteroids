using DG.Tweening;
using UnityEngine;

namespace SpaceshipVsAsteroids.Managers
{
  public class CameraManager : MonoBehaviour
  {
    [Header("Player Camera Param's")]
    [SerializeField] private Vector3 damagePunchVector = new Vector3(0, 1, 0);
    [SerializeField] private float damagePunchDuration = 0.25f;

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
      _mainCamera.transform.DOPunchRotation(damagePunchVector, damagePunchDuration, 50, 1).SetEase(Ease.OutSine);
    }
  }
}