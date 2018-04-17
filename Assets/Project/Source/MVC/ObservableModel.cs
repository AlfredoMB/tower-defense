using System;

namespace AlfredoMB.MVC
{
    public class ObservableModel : IModel
    {
        public Action OnUpdated;

        protected void NotifyUpdate()
        {
            if (OnUpdated != null)
            {
                OnUpdated();
            }
        }
    }
}