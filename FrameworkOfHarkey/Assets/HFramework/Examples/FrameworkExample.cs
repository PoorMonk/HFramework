using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HFramework
{
    public class FrameworkExample : MonoBehaviourSimplify
    {
        protected override void OnBeforeDestroy()
        {
        }

        private void Awake()
        {
            RegisterMsg("test", MsgFunc);
        }

        private IEnumerator Start()
        {
            SendMsg("test", "hello");
            yield return new WaitForSeconds(1.0f);
            SendMsg("test", "world");
        }

        private void MsgFunc(object text)
        {
            Debug.Log(text);
        }

        [MenuItem("HFramework/Example/FrameworkExample", false, 3)]
        private static void Test()
        {
            MessageDispatch.RemoveAllMsgFuncs("test");
            EditorApplication.isPlaying = true;
            new GameObject("MsgReceiveObj").AddComponent<FrameworkExample>();
        }
    }
}
