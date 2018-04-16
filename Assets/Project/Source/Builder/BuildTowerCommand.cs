using AlfredoMB.Command;
using AlfredoMB.Tower;
using UnityEngine;

namespace AlfredoMB.Builder
{
    public class BuildTowerCommand : ICommand
    {
        public readonly Vector3 Position;
        public readonly TowerModel Tower;

        public BuildTowerCommand(Vector3 position, TowerModel tower)
        {
            Position = position;
            Tower = tower;
        }
    }
}