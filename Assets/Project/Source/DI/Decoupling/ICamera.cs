using UnityEngine;

namespace AlfredoMB.DI.Decoupling
{
    public interface ICamera
    {
        object main { get; }

        Vector3 ScreenToWorldPoint(Vector3 mousePosition);
    }
}