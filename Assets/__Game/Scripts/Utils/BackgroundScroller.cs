using UnityEngine;

namespace SpaceshipVsAsteroids.Utils
{
  public class BackgroundScroller : MonoBehaviour
  {
    [SerializeField] private float scrollSpeed = 0.05f;

    private float _offset;

    private Material _material;

    private void Awake()
    {
      _material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
      _offset += (Time.deltaTime * scrollSpeed) / 10f;
      _material.SetTextureOffset("_MainTex", new Vector2(0, _offset));
    }
  }
}