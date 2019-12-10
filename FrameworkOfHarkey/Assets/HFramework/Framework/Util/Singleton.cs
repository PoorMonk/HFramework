using System;
using System.Reflection;

namespace HFramework
{
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null)
                    {
                        throw new Exception("Non-public ctor() not found");
                    }
                    _instance = ctor.Invoke(null) as T;
                }
                return _instance;
            }
        }

        protected Singleton(){ }
    }
}
