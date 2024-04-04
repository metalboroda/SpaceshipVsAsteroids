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

    public void MovementRb(float movementForce, float xAxis)
    {
      Vector3 movementDirection = new Vector3(xAxis, 0, 0);
      Vector3 force = movementDirection * movementForce;

      _rb.AddForce(force, ForceMode.Force);
    }

    public void RotateShipZ(float rotationMultiplier, float rotationDuration, float xAxis)
    {
      _shipModel.transform.DORotate(
        new Vector3(0, 0, -xAxis * rotationMultiplier), rotationDuration).SetEase(Ease.InOutSine);
    }
  }
}