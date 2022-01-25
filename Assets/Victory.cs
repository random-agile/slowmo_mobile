using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

namespace DriftRace
{
    public class Victory : MonoBehaviour
    {
        [SerializeField] private ParticleSystem WinConfetti;
        [SerializeField] private AudioSource aS;
        [SerializeField] private MMFeedbacks EndFeedback;
        
        void OnTriggerEnter(Collider other)
        {
            EndFeedback?.PlayFeedbacks();
            aS.Stop();
            SoundManager.StopSound();
            SoundManager.PlaySound("end");
            WinConfetti.Play();
            GameManager.Instance.LaunchVictory();
        }
    }
}
