using AlfredoMB.MVC;
using UnityEngine;

namespace AlfredoMB.Builder
{
    [CreateAssetMenu]
	public class BuilderModel : ScriptableObject, IModel
    {
		public float TileSize = 4f;
		public int XTiles;
		public int YTiles;
	}
}