using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DriftRace
{
    public class SoundManager : MonoBehaviour
    {
        public static AudioClip footsteps, warp, ends;
        public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Awake()
    {
        footsteps = Resources.Load<AudioClip>("footstepsw");
        warp = Resources.Load<AudioClip>("warpsound");
        ends = Resources.Load<AudioClip>("end");

        audioSrc = GetComponent<AudioSource>();
    }    

    //the main switch/case that will be used to trigger sound effects
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "footstepsw":
                audioSrc.Play(0);
                break;
            case "warpsound":
                audioSrc.PlayOneShot(warp, 1f);
                break;
            case "end":
                audioSrc.PlayOneShot(ends, 0.25f);
                break;
        }
    }

    public static void StopSound()
    {
        audioSrc.Stop();
    }
    
    }
}
