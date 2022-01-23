using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLOWMOGameKit
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField] protected CharacterBody _body;
        [SerializeField] protected Transform _brain;

        public CharacterBody Body { get { return _body; } }

        public Transform Brain { get { return _brain; } }

        public Vector3 Velocity
        {
            get
            {
                return _body.Rb.velocity;
            }

            set
            {
                _body.Rb.velocity = value;
            }
        }

        public Vector3 Position
        {
            get
            {
                return _body.Rb.position;
            }

            set
            {
                _body.Rb.position = value;
            }
        }

        protected IAbility currentMovementAbility;
        protected IAbility currentSkillAbility;

        #region Monobehaviours 

        private void Update()
        {

        }

        #endregion

        #region public 


        public void NotifyMovementAbilityStart(IAbility movementAbility)
        {
            if (currentMovementAbility != null && movementAbility != currentMovementAbility) currentMovementAbility.StopAbility();

            currentMovementAbility = movementAbility;
        }

        public void NotifySkillAbilityStart(IAbility skillAbility)
        {
            if (currentSkillAbility != null && skillAbility != currentSkillAbility) currentSkillAbility.StopAbility();

            currentSkillAbility = skillAbility;
        }

        #endregion

    }
}
