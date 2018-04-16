using AlfredoMB.MVC;
using AlfredoMB.Ship;

namespace AlfredoMB.Stage
{
    public interface IStageController : IController
    {
        StageModel CurrentState { get; }

        bool IsGameOver { get; }
        bool IsVictory { get; }

        void AllEnemiesSpawned();
        void OnEnemyPassed();
        void OnShipDestroyed(ShipModel p_destroyedShip);
        void OnShipSpawned();
    }
}