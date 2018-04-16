﻿using System;
using System.Collections.Generic;

namespace AlfredoMB.DI
{
    /// <summary>
    /// A simple approach on Depencency Injection.
    /// </summary>
    public static class SimpleDI
    {
        private static Dictionary<Type, object> _instances = new Dictionary<Type, object>();

        public static void Register<T>(T instance)
        {
            _instances.Add(typeof(T), instance);
        }

        public static T Get<T>()
        {
            return (T)_instances[typeof(T)];
        }
    }
}
