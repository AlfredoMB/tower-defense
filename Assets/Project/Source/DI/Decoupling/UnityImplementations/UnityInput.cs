using UnityEngine;

namespace AlfredoMB.DI.Decoupling.UnityImplementations
{
    public class UnityInput : IInput
    {
        public Vector3 mousePosition
        {
            get
            {
                return UnityEngine.Input.mousePosition;
            }
        }
    }
}