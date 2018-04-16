using UnityEngine;

namespace AlfredoMB.DI.Decoupling.UnityImplementations
{
    public class UnityCamera : ICamera
    {
        public object main
        {
            get
            {
                return Camera.main;
            }
        }

        public Vector3 ScreenToWorldPoint(Vector3 mousePosition)
        {
            return Camera.main.ScreenToWorldPoint(mousePosition);
        }
    }
}