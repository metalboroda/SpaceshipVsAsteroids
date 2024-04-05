using SpaceshipVsAsteroids.Managers;
using SpaceshipVsAsteroids.Visual;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShipVisualHandler : ObjectVisualHandlerBase<PlayerShip>
  {
    [Header("Damage Vignette")]
    [SerializeField] private Image vignetteImage;
    [Space]
    [SerializeField] private float damageDuration = 0.5f;
    [SerializeField] private float vignetteTargetAlpha = 0.05f;

    protected override void SubscribeEvents()
    {
      EventManager.PlayerDamaged += DamageVignetteAnimation;
      EventManager.PlayerDead += SpawnDestroyVFX;
    }

    protected override void UnsubscribeEvents()
    {
      EventManager.PlayerDamaged -= DamageVignetteAnimation;
      EventManager.PlayerDead -= SpawnDestroyVFX;
    }

    private void DamageVignetteAnimation()
    {
      vignetteImage.DOFade(vignetteTargetAlpha, damageDuration / 2)
          .OnComplete(() => vignetteImage.DOFade(0f, damageDuration / 2));
    }
  }
}