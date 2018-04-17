using AlfredoMB.Game.Cannon;
using AlfredoMB.Game.Turret;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Tower
{
    /// <summary>
    /// Spots enemies;
    /// Turns turret toward selected enemy;
    /// Shoots bullets;
    /// </summary>
    public class TowerView : MonoBehaviour, IView
    {
        public RadarView RadarView;
        public TurretView TurretView;
        public CannonView CannonView;

        public TowerModel Model { get; private set; }
        public TurretController TurretController;

        public void SetModel(TowerModel model)
        {
            Model = model;
            RadarView.SetModel(model.Radar);
            TurretController = new TurretController(model.Turret, model.Radar, TurretView.transform, CannonView);
        }

        private void Update()
        {
            TurretController.Update();
        }
    }
}