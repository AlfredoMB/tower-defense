using AlfredoMB.Game.Tower;
using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Game.Builder
{
    [CreateAssetMenu]
	public class BuilderModelScriptableObject : ScriptableObject, ISerializedModel<BuilderModel>
    {
        public TowerModelScriptableObject Tower;

        public BuilderModel ToModel()
        {
            return new BuilderModel()
            {
                AvailableTower = Tower.ToModel()
            };
        }
    }
}