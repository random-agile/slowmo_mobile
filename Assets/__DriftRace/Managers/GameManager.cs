using SLOWMOGameKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DriftRace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CharacterLocomotion locomotionAbility;

        void Start()
        {
            Application.targetFrameRate = 60;
            locomotionAbility.StartAbility();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                LevelGenerator.Instance.ReloadGame();
            }
        }

    }
}
