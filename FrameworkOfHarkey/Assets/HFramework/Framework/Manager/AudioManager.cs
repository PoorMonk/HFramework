using UnityEngine;

namespace HFramework
{

    public class AudioManager : MonoSingleton<AudioManager>
    {
        //private static AudioManager _instance;
        //public static AudioManager Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new GameObject("AudioManager").AddComponent<AudioManager>();
        //        }
        //        return _instance;
        //    }
        //}

        public void PlaySound(string clipName)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            AudioClip audioClip = Resources.Load<AudioClip>(clipName);
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        
    }
}
