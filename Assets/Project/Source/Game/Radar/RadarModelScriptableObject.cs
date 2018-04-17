using UnityEngine;
using AlfredoMB.MVC;

namespace AlfredoMB.Game.Radar
{
    [CreateAssetMenu]
    public class RadarModelScriptableObject : ScriptableObject, ISerializedModel<RadarModel>
    {
        public float ActionRadius;

        public RadarModel ToModel()
        {
            return new RadarModel()
            {
                ActionRadius = ActionRadius
            };
        }
    }
}
