///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 23/07/2020 10:25
///-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using SLOWMOGameKit;
using UnityEngine;

namespace SLOWMOGameKit
{
    public class CharacterAbility<T> : CharacterComponent<T>, IAbility where T : CharacterBase
    {   
        [Header("Base")]
        [SerializeField] private AbilityType _type = AbilityType.AlwaysUpdate;
        [SerializeField] private UpdateMode updateMode = UpdateMode.Update;

        public AbilityType Type { get { return _type; } }

        public bool IsAbilityStarted { get; private set; } = false;

        public event Action OnAbilityStarted;
        public event Action OnAbilityEnded;

        #region Monobehaviour Functions

        virtual protected void Start()
        {       
            if(_type == AbilityType.AlwaysUpdate)
            {
                StartAbility();
            }
        }

        virtual protected void Update()
        {
            if(IsAbilityStarted && updateMode == UpdateMode.Update)
            {
                UpdateAbility();
            }
        }

        virtual protected void FixedUpdate()
        {
            if (IsAbilityStarted && updateMode == UpdateMode.FixedUpdate)
            {
                UpdateAbility();
            }
        }

        virtual protected void LateUpdate()
        {
            if (IsAbilityStarted && updateMode == UpdateMode.LateUpdate)
            {
                UpdateAbility();
            }
        }

        #endregion

        #region Ability Functions

        /// <summary>
        /// The enter method that will enable the execution of the UpdateAbility function each frame
        /// </summary>
        virtual public void StartAbility()
        {
            if (IsAbilityStarted) return;

            if(_type == AbilityType.Movement)
            {
                _owner.NotifyMovementAbilityStart(this as IAbility);
            }
            else if(_type == AbilityType.Skill)
            {
                _owner.NotifySkillAbilityStart(this as IAbility);
            }

            IsAbilityStarted = true;

            OnAbilityStarted?.Invoke();
        }

        /// <summary>
        /// Do not code in Update, LateUpdate, or FixedUpdate methods
        /// Code in UpdateAbility function instead
        /// </summary>
        virtual public void UpdateAbility()
        {

        }

        /// <summary>
        /// The exit method that will disable the execution of the UpdateAbility function each frame
        /// </summary>
        virtual public void StopAbility()
        {
            if (!IsAbilityStarted) return;

            IsAbilityStarted = false;

            OnAbilityEnded?.Invoke();
        }

        #endregion

        #region Enums

        public enum AbilityType
        {
            AlwaysUpdate,
            Movement,
            Skill
        }

        public enum UpdateMode
        {
            Update,
            FixedUpdate,
            LateUpdate
        }

        #endregion
    }
}
