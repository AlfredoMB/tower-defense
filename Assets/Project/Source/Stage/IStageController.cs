using AlfredoMB.Game.Ship;
using AlfredoMB.MVC;

namespace AlfredoMB.Stage
{
    public interface IStageController : IController
    {
        StageModel CurrentState { get; }

        bool IsGameOver { get; }
        bool IsVictory { get; }

        void AllEnemiesSpawned();
        void OnEnemyPassed();
        void OnShipDestroyed(ShipModel destroyedShip);
        void OnShipSpawned();
    }
}