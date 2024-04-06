using SpaceshipVsAsteroids.Visual;

namespace SpaceshipVsAsteroids.Props
{
  public class CollectibleCrystalVisualHandler : ObjectVisualHandlerBase<CollectibleCrystal>
  {
    protected override void SubscribeEvents()
    {
      Target.CrystalDestroyed += SpawnDestroyVFX;
    }

    protected override void UnsubscribeEvents()
    {
      Target.CrystalDestroyed -= SpawnDestroyVFX;
    }
  }
}