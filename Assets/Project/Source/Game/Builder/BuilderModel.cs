using AlfredoMB.Game.Tower;
using AlfredoMB.MVC;
using System;

namespace AlfredoMB.Game.Builder
{
    [Serializable]
    public class BuilderModel : IModel
    {
        public TowerModel AvailableTower;
    }
}