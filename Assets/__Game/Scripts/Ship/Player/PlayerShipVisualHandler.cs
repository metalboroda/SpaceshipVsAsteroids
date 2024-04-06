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

    [Header("Armor Outline")]
    [SerializeField] private float maxOutlineValue = 1.05f;

    private Tween _vignetteTween;

    private Material _armorMaterial;
    private Renderer _renderer;

    protected override void Awake()
    {
      SetArmorMaterial();
    }

    protected override void SubscribeEvents()
    {
      EventManager.OnArmorReceived += () => VignetteAnimation(armorVignetteImage);
      EventManager.PlayerArmorChanged += SwitchArmorOutline;
      EventManager.PlayerDamaged += () => VignetteAnimation(damageVignetteImage);
      EventManager.PlayerDead += SpawnDestroyVFX;
    }

    protected override void UnsubscribeEvents()
    {
      EventManager.OnArmorReceived -= () => VignetteAnimation(armorVignetteImage);
      EventManager.PlayerArmorChanged -= SwitchArmorOutline;
      EventManager.PlayerDamaged -= () => VignetteAnimation(damageVignetteImage);
      EventManager.PlayerDead -= SpawnDestroyVFX;
    }

    private void SetArmorMaterial()
    {
      _renderer = GetComponentInChildren<Renderer>();

      Material[] materials = _renderer.materials;

      foreach (Material material in materials)
      {
        if (material.name == "Outline_Blue (Instance)")
        {
          _armorMaterial = material;

          break;
        }
      }
    }

    private void VignetteAnimation(Image vignetteImage)
    {
      _vignetteTween = vignetteImage.DOFade(vignetteTargetAlpha, vignetteDuration / 2)
                   .OnComplete(() => vignetteImage.DOFade(0f, vignetteDuration / 2)).SetAutoKill(true);
    }

    private void SwitchArmorOutline(int armor)
    {
      _armorMaterial.SetFloat("_Scale", armor > 0 ? maxOutlineValue : 0f);
    }
  }
}