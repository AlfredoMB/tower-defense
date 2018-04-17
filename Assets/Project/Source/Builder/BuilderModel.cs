using AlfredoMB.MVC;
using AlfredoMB.Tower;
using System;
using System.Collections.Generic;

namespace AlfredoMB.Builder
{
    [Serializable]
    public class BuilderModel : IModel
    {
        public List<TowerModel> AvailableTowers = new List<TowerModel>();

        public TowerModel SelectedTower { get; private set; }

        public BuilderModel()
        { }

        public BuilderModel(BuilderModel builderModel)
        {
            AvailableTowers = builderModel.AvailableTowers;
        }

        public void SelectTower(int index)
        {
            SelectedTower = AvailableTowers[index];
        }
    }
}