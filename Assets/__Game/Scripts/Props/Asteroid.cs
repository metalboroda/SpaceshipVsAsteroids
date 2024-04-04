using DG.Tweening;
using Lean.Pool;
using SpaceshipVsAsteroids.SOs;
using UnityEngine;

namespace SpaceshipVsAsteroids.Props
{
  public class Asteroid : MonoBehaviour, IPoolable
  {
    [SerializeField] private AsteroidSO asteroidSO;

    private Tween _moveTween;
    private Tween _rotationTween;

    public void OnSpawn()
    {
      DOTween.Kill(_moveTween);
      DOTween.Kill(_rotationTween);

      RotateRandom();
    }

    public void OnDespawn()
    {
    }

    public void MoveToTarget(Vector3 target)
    {
      float randomMovementSpeed = Random.Range(asteroidSO.MinMovementSpeed, asteroidSO.MaxMovementSpeed);

      _moveTween = transform.DOMove(target, randomMovementSpeed).SetSpeedBased(true).OnComplete(() =>
      {
        DespawnObject();
      });
    }

    private void RotateRandom()
    {
      Vector3 randomRotation = new Vector3(
        Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
      float randomRotationSpeed = Random.Range(asteroidSO.MinRotationSpeed, asteroidSO.MaxRotationSpeed);

      _rotationTween = transform.DORotate(randomRotation, randomRotationSpeed, RotateMode.FastBeyond360)
          .SetSpeedBased(true)
          .SetEase(Ease.Linear)
          .SetLoops(-1);
    }

    public void DespawnObject()
    {
      LeanPool.Despawn(gameObject);
    }
  }
}