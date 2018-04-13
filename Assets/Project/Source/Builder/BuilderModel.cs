using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AlfredoMB.MVC;

namespace AlfredoMB.Builder {
	[CreateAssetMenu]
	public class BuilderModel : Model {
		public float TileSize = 4f;
		public int XTiles;
		public int YTiles;
	}
}