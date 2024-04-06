using SpaceshipVsAsteroids.Enums;
using SpaceshipVsAsteroids.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShipUIHandler : MonoBehaviour
  {
    [SerializeField] private GameObject canvas;

    [Space]
    [SerializeField] private Image healthBar;
    [SerializeField] private Image armorBar;

    private PlayerShip _playerShip;

    private void Awake()
    {
      _playerShip = GetComponent<PlayerShip>();
    }

    private void OnEnable()
    {
      EventManager.GameStateChanged += SwitchCanvas;
      EventManager.PlayerHealthChanged += UpdateHealthBar;
      EventManager.PlayerArmorChanged += UpdateArmorBar;
    }

    private void OnDisable()
    {
      EventManager.GameStateChanged -= SwitchCanvas;
      EventManager.PlayerHealthChanged -= UpdateHealthBar;
      EventManager.PlayerArmorChanged -= UpdateArmorBar;
    }

    private void UpdateHealthBar(int health)
    {
      float healthRatio = (float)health / _playerShip.MaxHealth;

      healthBar.fillAmount = healthRatio;
    }

    private void UpdateArmorBar(int armor)
    {
      float armorRatio = (float)armor / _playerShip.MaxArmor;

      armorBar.fillAmount = armorRatio;
    }

    private void SwitchCanvas(GameState state)
    {
      if (state == GameState.Play)
      {
        canvas.SetActive(true);
      }
      else
      {
        canvas.SetActive(false);
      }
    }
  }
}