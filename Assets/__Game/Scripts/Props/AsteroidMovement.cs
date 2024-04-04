using SpaceshipVsAsteroids.SOs;
using UnityEngine;

namespace SpaceshipVsAsteroids.Props
{
  public class AsteroidMovement : MonoBehaviour
  {
    [SerializeField] private AsteroidSO asteroidSO;

    private Asteroid _asteroid;
    private Vector3 _moveTarget;

    private void Awake()
    {
      _asteroid = GetComponent<Asteroid>();
    }

    private void Update()
    {
      MoveToTarget();
      RotateRandom();
    }

    public void Init(Vector3 moveTarget)
    {
      _moveTarget = moveTarget;
    }

    public void MoveToTarget()
    {
      float randomMovementSpeed = Random.Range(asteroidSO.MinMovementSpeed, asteroidSO.MaxMovementSpeed);
      float step = randomMovementSpeed * Time.deltaTime;

      transform.position = Vector3.MoveTowards(transform.position, _moveTarget, step);

      if (transform.position == _moveTarget)
      {
        _asteroid.DespawnAsteroid();
      }
    }

    private void RotateRandom()
    {
      Vector3 randomRotation = new Vector3(
          Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
      float randomRotationSpeed = Random.Range(asteroidSO.MinRotationSpeed, asteroidSO.MaxRotationSpeed);

      transform.Rotate(randomRotation * Time.deltaTime * randomRotationSpeed);
    }
  }
}