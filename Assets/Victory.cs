using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DriftRace
{
    public class Victory : MonoBehaviour
    {
        [SerializeField] private ParticleSystem WinConfetti;

        void OnTriggerEnter(Collider other)
        {
            WinConfetti.Play();
            GameManager.Instance.LaunchVictory();
        }
    }
}
