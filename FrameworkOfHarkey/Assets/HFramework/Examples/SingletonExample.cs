using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HFramework
{
    public class SingletonExample : Singleton<SingletonExample>
    {
        protected SingletonExample()
        {
            Debug.Log("SingletonExample");
        }

#if UNITY_EDITOR
        [MenuItem("HFramework/Example/Singleton", false, 7)]
        private static void SingletonMenu()
        {
            var sgt1 = Instance;
            var sgt2 = Instance;
        }       
#endif
    }

    public class MonoSingletonExample : MonoSingleton<MonoSingletonExample>
    {
#if UNITY_EDITOR
        [MenuItem("HFramework/Example/MonoSingleton", false, 8)]
        private static void MonoSingletonMenu()
        {
            EditorApplication.isPlaying = true;
        }

        //[RuntimeInitializeOnLoadMethod]
        //private static void MonoSingleton()
        //{
        //    var initInstance1 = Instance;
        //    var initInstance2 = Instance;
        //}
#endif
    }
}
