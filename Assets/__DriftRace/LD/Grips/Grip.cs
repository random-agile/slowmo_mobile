using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DriftRace
{
    public class Grip : MonoBehaviour
    {
        [SerializeField] private bool _isClockWise = true;

        public bool IsClockWise { get { return _isClockWise; } }

        private bool isActive = false;

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" && !isActive)
            {
                MainCharacter mainChara = other.GetComponentInParent<MainCharacter>();
                
                if(mainChara != null)
                {
                    EnableBehaviour(mainChara);       
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player" && isActive)
            {
                MainCharacter mainChara = other.GetComponentInParent<MainCharacter>();

                if (mainChara != null)
                {
                    DisableBehaviour(mainChara);
                }
            }
        }

        private void EnableBehaviour(MainCharacter character)
        {
            isActive = true;
            
            CharacterLocomotion locomotionAbility = character.Brain.GetComponentInChildren<CharacterLocomotion>();

            if(locomotionAbility != null)
            {
                locomotionAbility.NotifyGripDetected(this);
            }
        }

        private void DisableBehaviour(MainCharacter character)
        {
            isActive = false;

            CharacterLocomotion locomotionAbility = character.Brain.GetComponentInChildren<CharacterLocomotion>();

            if (locomotionAbility != null)
            {
                locomotionAbility.NotifyGripExit(this);
            }
        }

        void Update()
    {
        transform.Rotate( new Vector3(0, 3f, 0) );
    }

    }
}
