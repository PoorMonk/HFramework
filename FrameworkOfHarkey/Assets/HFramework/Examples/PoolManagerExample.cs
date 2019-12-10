using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HFramework
{
    public class PoolManagerExample
    {
        private class Fish
        {

        }

#if UNITY_EDITOR
        [MenuItem("HFramework/Example/PoolManager", false, 5)]
        private static void PoolManagerMenu()
        {
            SimpleObjectPool<Fish> fishPool = new SimpleObjectPool<Fish>(() => new Fish(), null, 100);
            Debug.Log("fishPool.curCout: " + fishPool.CurCount);
            fishPool.Spawn();
            Debug.Log("fishPool.curCout: " + fishPool.CurCount);
            for (int i = 0; i < 5; i++)
            {
                fishPool.Spawn();
            }
            Debug.Log("fishPool.curCout: " + fishPool.CurCount);
        }
#endif
    }

}
