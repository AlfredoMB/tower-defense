using AlfredoMB.Game.Cannon;
using AlfredoMB.MVC;
using System;

namespace AlfredoMB.Game.Turret
{
    [Serializable]
    public class TurretModel : IModel
    {		
		public float TurnSpeed;

        public CannonModel Cannon { get; set; }
    }
}