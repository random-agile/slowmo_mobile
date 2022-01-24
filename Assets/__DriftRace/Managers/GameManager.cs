using SLOWMOGameKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DriftRace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        [SerializeField] private CharacterLocomotion locomotionAbility;

        void Awake()
        {
            Instance = this;
        }

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

        public void LaunchVictory()
        {
            locomotionAbility.Victory();
        }

    }
}
