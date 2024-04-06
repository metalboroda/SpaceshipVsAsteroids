using SpaceshipVsAsteroids.Visual;

namespace SpaceshipVsAsteroids.Props
{
  public class ArmorCrystalVisualHandler : ObjectVisualHandlerBase<ArmorCrystal>
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