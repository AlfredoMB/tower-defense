using System.Collections.Generic;

namespace AlfredoMB.Tower
{
    public interface IRecipe
    {
        Dictionary<object, int> GetCost();
    }
}