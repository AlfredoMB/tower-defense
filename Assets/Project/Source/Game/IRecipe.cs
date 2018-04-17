using System.Collections.Generic;

namespace AlfredoMB.Game
{
    public interface IRecipe
    {
        Dictionary<object, int> GetCost();
    }
}