using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HFramework
{
    public class GUIManagerExample : MonoBehaviour
    {
        private IEnumerator Start()
        {
            GUIManager.LoadPanel("HomePanel", UILayer.Bg);
            yield return new WaitForSeconds(5f);
            //GUIManager.UnLoadPanel("HomePanel");
        }

        [MenuItem("HFramework/Example/GUIManager", false, 4)]
        private static void GUIManagerMenu()
        {
            EditorApplication.isPlaying = true;
            new GameObject("GUIManager").AddComponent<GUIManagerExample>();
        }
    }
}
