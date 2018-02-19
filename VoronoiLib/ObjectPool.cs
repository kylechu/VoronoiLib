using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace VoronoiLib
{
    public static class ObjectPool<T> where T : new()
    {
        private static Queue<T> _pool = new Queue<T>();

        public static T Get()
        {
            if (_pool.Count > 0)
            {
                return _pool.Dequeue();
            }
            else
            {
                return new T();
            }
        }

        public static void Recycle(T obj)
        {
            _pool.Enqueue(obj);
        }
    }
}
