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
            var towers = new List<TowerModel>();
            foreach(var tower in Towers)
            {
                towers.Add(tower.ToModel());
            }

            return new BuilderModel(BuilderModel, towers);
        }
    }
}