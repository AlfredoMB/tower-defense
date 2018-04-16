using AlfredoMB.MVC;
using AlfredoMB.Tower;
using System;

namespace AlfredoMB.Builder
{
    [Serializable]
    public class BuilderModel : IModel
    {
        public TowerModel SelectedTower;
    }
}