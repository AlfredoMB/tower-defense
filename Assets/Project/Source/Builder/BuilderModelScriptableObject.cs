using AlfredoMB.MVC;
using AlfredoMB.Tower;
using System.Collections.Generic;
using UnityEngine;

namespace AlfredoMB.Builder
{
    [CreateAssetMenu]
	public class BuilderModelScriptableObject : ScriptableObject, ISerializedModel<BuilderModel>
    {
        public List<TowerModelScriptableObject> Towers;

        public BuilderModel BuilderModel;

        public BuilderModel ToModel()
        {
            foreach(var tower in Towers)
            {
                BuilderModel.AvailableTowers.Add(tower.ToModel());
            }

            return new BuilderModel(BuilderModel);
        }
    }
}