using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HFramework
{
    public class AudioManagerExample
    {
#if UNITY_EDITOR
        private static bool _clicked = false;

        [MenuItem("HFramework/Example/AudioManager", false, 6)]
        private static void AudioManagerMenu()
        {
            _clicked = true;
            EditorApplication.isPlaying = true;
            //AudioManager.Instance.PlaySound("xiao_a_feng_01");
            //AudioManager.Instance.PlaySound("xiao_a_feng_01");
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Play()
        {
            //if (_clicked)
            {
                AudioManager.Instance.PlaySound("xiao_a_feng_01");
            }
        }
#endif
    }
}

