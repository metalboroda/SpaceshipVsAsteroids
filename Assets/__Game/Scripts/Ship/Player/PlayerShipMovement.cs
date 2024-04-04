using SpaceshipVsAsteroids.Components;
using SpaceshipVsAsteroids.SOs;
using UnityEngine;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShipMovement : MonoBehaviour
  {
    [SerializeField] private ShipSO shipSO;

    private float _screenWidth;

    private Camera _mainCamera;
    private Rigidbody _rb;

    private PlayerInputHandler _inputHandler;

    private ShipMovement _shipMovement;

    private void Awake()
    {
      _mainCamera = Camera.main;
      _rb = GetComponent<Rigidbody>();

      _inputHandler = GetComponent<PlayerInputHandler>();

      _shipMovement = new ShipMovement(_rb);
    }

    private void Start()
    {
      _screenWidth = Screen.width;
    }

    private void FixedUpdate()
    {
      RestrictToBounds();

      _shipMovement.MovementRb(shipSO.MovementForce, _inputHandler.GetXInput());
    }

    public void RestrictToBounds()
    {
      Vector3 viewPos = _mainCamera.WorldToViewportPoint(_rb.position);

      viewPos.x = Mathf.Clamp01(viewPos.x);

      Vector3 worldPos = _mainCamera.ViewportToWorldPoint(viewPos);

      _rb.position = new Vector3(worldPos.x, _rb.position.y, _rb.position.z);
    }
  }
}