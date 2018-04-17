using AlfredoMB.Command;
using AlfredoMB.DI;
using AlfredoMB.DI.Decoupling;
using AlfredoMB.MVC;
using AlfredoMB.Stage;
using UnityEngine;

namespace AlfredoMB.Game.Builder
{
    /// <summary>
    /// Moves Builder cursor on the board;
    /// Changes Builder cursor's color based on possible positioning;
    /// Sends BuildTowerCommand on click;
    /// </summary>
    public class BuilderView : MonoBehaviour, IView
    {
		public Renderer[] MeshRenderers;

        private ICamera _camera;
        private IInput _input;
        private ICommandController _commandController;
        private IStageController _stageController;

        private void Start()
        {
            _camera = SimpleDI.Get<ICamera>();
            _input = SimpleDI.Get<IInput>();
            _commandController = SimpleDI.Get<ICommandController>();
            _stageController = SimpleDI.Get<IStageController>();
        }

        private void Update()
        {
            var position = GetBuildPosition();
            transform.position = position;

			SetColor (CanBuild(position) 
                ? Color.green 
                : Color.red);
		}

        private void OnMouseUpAsButton()
        {
            _commandController.AddCommand(
                new BuildTowerCommand(GetBuildPosition(), _stageController.CurrentState.BuilderModel.SelectedTower));
        }

        private Vector3 GetBuildPosition()
        {
            var position = _camera.ScreenToWorldPoint(_input.mousePosition);
            var board = _stageController.CurrentState.BoardModel;

            return new Vector3(
                Mathf.RoundToInt(position.x / board.TileSize) * board.TileSize,
                0,
                Mathf.RoundToInt(position.z / board.TileSize) * board.TileSize);
        }

        private bool CanBuild(Vector3 position)
        {
            var tilePosition = new TilePosition(position, _stageController.CurrentState.BoardModel);
            return _stageController.CurrentState.BoardModel.IsFree(tilePosition);
        }

        private void SetColor(Color color)
        {
			foreach(MeshRenderer renderer in MeshRenderers)
            {
				renderer.material.color = color;
			}
		}
	}
}