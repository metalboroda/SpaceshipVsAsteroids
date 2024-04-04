using DG.Tweening;
using UnityEngine;

namespace SpaceshipVsAsteroids.Components
{
  public class ShipMovement
  {
    private GameObject _shipModel;

    private Rigidbody _rb;

    public ShipMovement(GameObject shipModel, Rigidbody rb)
    {
      _shipModel = shipModel;
      _rb = rb;
    }

    public void MovementRb(float movementForce, Vector2 axis)
    {
      Vector3 movementDirection = new Vector3(axis.x, 0, axis.y);
      Vector3 force = movementDirection * movementForce;

      _rb.AddForce(force, ForceMode.Force);
    }

    public void RotateShipZ(float rotationMultiplier, float rotationDuration, Vector2 axis)
    {
      _shipModel.transform.DORotate(
        new Vector3(0, 0, -axis.x * rotationMultiplier), rotationDuration).SetEase(Ease.InOutSine);
    }
  }
}