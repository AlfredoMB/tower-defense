using AlfredoMB.Game.Cannon;
using AlfredoMB.MVC;
using System;

namespace AlfredoMB.Game.Turret
{
    [Serializable]
    public class TurretModel : IModel
    {
		public CannonModel Cannon;

		public float TurnSpeed;
		public float ActionRadius;

        public TurretModel(TurretModel turretModel)
        {
            //Cannon = turretModel.Cannon;
            TurnSpeed = turretModel.TurnSpeed;
            ActionRadius = turretModel.ActionRadius;
        }
    }
}