using SpaceshipVsAsteroids.Visual;

namespace SpaceshipVsAsteroids.Ship
{
  public class PlayerShipVisualHandler : ObjectVisualHandlerBase<PlayerShip>
  {
    protected override void SubscribeEvents()
    {
      Target.PlayerDead += SpawnDestroyVFX;
    }

    protected override void UnsubscribeEvents()
    {
      Target.PlayerDead -= SpawnDestroyVFX;
    }
  }
}