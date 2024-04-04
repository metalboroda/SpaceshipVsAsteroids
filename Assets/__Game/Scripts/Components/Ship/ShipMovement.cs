using UnityEngine;

namespace SpaceshipVsAsteroids.Components
{
  public class ShipMovement
  {
    private float _screenWidth;

    private Camera _mainCamera;
    private Rigidbody _rb;

    public ShipMovement(Rigidbody rb)
    {
      _rb = rb;
    }

    private void Start()
    {
      _mainCamera = Camera.main;
      _screenWidth = Screen.width;
    }

    public void MovementRb(float movementForce, float xAxis)
    {
      Vector3 movementDirection = new Vector3(xAxis, 0, 0);
      Vector3 force = movementDirection * movementForce;

      _rb.AddForce(force, ForceMode.Force);
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