using SpaceshipVsAsteroids.Visual;

namespace SpaceshipVsAsteroids.Props
{
  public class AsteroidVisualHandler : ObjectVisualHandlerBase<Asteroid>
  {
    protected override void SubscribeEvents()
    {
      Target.AsteroidDestroyed += SpawnDestroyVFX;
    }

    protected override void UnsubscribeEvents()
    {
      Target.AsteroidDestroyed -= SpawnDestroyVFX;
    }
  }
}