using SpaceshipVsAsteroids.Visual;

namespace SpaceshipVsAsteroids.Props
{
  public class CrystalVisualHandler : ObjectVisualHandlerBase<Crystal>
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