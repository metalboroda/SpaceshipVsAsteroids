using UnityEngine;
using UnityEngine.UI;

namespace SpaceshipVsAsteroids.Utils
{
  public class BackgroundScroller : MonoBehaviour
  {
    public float scrollSpeed = 0.05f;

    [Space]
    [SerializeField] private Image backgroundImage;

    private float _offset;

    private void Start()
    {
      _offset = backgroundImage.material.GetTextureOffset("_MainTex").y;
    }

    private void Update()
    {
      _offset += Time.deltaTime * scrollSpeed;
      backgroundImage.material.SetTextureOffset("_MainTex", new Vector2(0, _offset));

      if (_offset > 1.0f)
      {
        _offset -= 1.0f;
      }
    }
  }
}