using AlfredoMB.MVC;
using System;

namespace AlfredoMB.Game.Bullet
{
    [Serializable]
	public class BulletModel : IModel
    {
		public float Damage;
		public float Mass;
    }
}