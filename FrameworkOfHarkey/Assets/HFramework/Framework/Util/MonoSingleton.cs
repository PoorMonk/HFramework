using UnityEngine;

namespace HFramework
{
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();

                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogWarning("MonoSingleton More than 1");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        var instanceName = typeof(T).Name;
                        Debug.LogFormat("Instance Name: {0}", instanceName);
                        var instanceObj = GameObject.Find(instanceName);
                        if (!instanceObj)
                        {
                            instanceObj = new GameObject(instanceName);
                        }
                        _instance = instanceObj.AddComponent<T>();
                        DontDestroyOnLoad(instanceObj);
                        Debug.LogFormat("Add new Singleton {0} in game", instanceName);
                    }
                    else
                    {
                        Debug.LogFormat("Already exist: {0}", _instance.name);
                    }
                }
                return _instance;
            }
        }

        protected virtual void OnDestroy()
        {
            _instance = null;
        }
    }
}
