using AlfredoMB.MVC;
using AlfredoMB.Tower;
using System;
using System.Collections.Generic;

namespace AlfredoMB.Builder
{
    [Serializable]
    public class BuilderModel : IModel
    {
        public List<TowerModel> AvailableTowers { get; private set; }

        public TowerModel SelectedTower { get; private set; }

        public BuilderModel(BuilderModel builderModel, List<TowerModel> towers)
        {
            AvailableTowers = towers;
        }

        public void SelectTower(int index)
        {
            SelectedTower = AvailableTowers[index];
        }
    }
}