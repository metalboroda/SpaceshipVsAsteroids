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
    [SerializeField] private Image damageVignetteImage;

    [Header("Armor Vignette")]
    [SerializeField] private Image armorVignetteImage;

    [Space]
    [SerializeField] private float vignetteDuration = 0.25f;
    [SerializeField] private float vignetteTargetAlpha = 0.05f;

    protected override void SubscribeEvents()
    {
      EventManager.OnArmorReceived += ArmorVignetteAnimation;
      EventManager.PlayerDamaged += DamageVignetteAnimation;
      EventManager.PlayerDead += SpawnDestroyVFX;
    }

    protected override void UnsubscribeEvents()
    {
      EventManager.OnArmorReceived -= ArmorVignetteAnimation;
      EventManager.PlayerDamaged -= DamageVignetteAnimation;
      EventManager.PlayerDead -= SpawnDestroyVFX;
    }

    private void DamageVignetteAnimation()
    {
      damageVignetteImage.DOFade(vignetteTargetAlpha, vignetteDuration / 2)
          .OnComplete(() => damageVignetteImage.DOFade(0f, vignetteDuration / 2));
    }

    private void ArmorVignetteAnimation()
    {
      armorVignetteImage.DOFade(vignetteTargetAlpha, vignetteDuration / 2)
          .OnComplete(() => armorVignetteImage.DOFade(0f, vignetteDuration / 2));
    }
  }
}