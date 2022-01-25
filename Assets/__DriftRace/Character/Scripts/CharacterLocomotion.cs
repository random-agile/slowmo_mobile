///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 08/01/2022 08:41
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLOWMOGameKit;
using System;
using Dreamteck.Splines;
using MoreMountains.Feedbacks;

namespace DriftRace 
{
    public class CharacterLocomotion : CharacterAbility<CharacterBase>
    {
        [Header("References")]
        [SerializeField] protected LineRenderer rope;

        [Header("Settings")]
        [SerializeField] protected float speed = 5f;
        [SerializeField] protected float rotationSpeed = 15f;
        [SerializeField] protected LayerMask groundMask;

        [Header("Animation")]
        [SerializeField] private Animator animator;

        [Header("VFX")]
        [SerializeField] private Outline outline;
        [SerializeField] private ParticleSystem aura;
        [SerializeField] private MMFeedbacks WarpFeedback;


        private Grip currentGrip;
        private Action DoAction;
        private Vector3 currentForward = Vector3.forward;
        private float startRotatingMagnitude = 0f;

        #region Monobehaviour

        protected override void Awake()
        {

            base.Awake();
            DoAction = DoActionVoid;
        }

        protected override void Update()
        {
            base.Update();

            if (!IsAbilityStarted) return;
            
            if(Input.GetMouseButtonDown(0))
            {
                if(DoAction == DoActionGoForward && currentGrip != null)
                {
                    WarpFeedback?.PlayFeedbacks();
                    animator.SetBool("isGrip", true);
                    outline.GetComponent<Outline>().enabled = true;
                    aura.Play();
                    SoundManager.StopSound();
                    SoundManager.PlaySound("warpsound");
                    SetModeRotateAroundGrip();
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                if(DoAction == DoActionRotateAroundGrip)
                {
                    animator.SetBool("isGrip", false);
                    outline.GetComponent<Outline>().enabled = false;
                    SoundManager.StopSound();
                    SoundManager.audioSrc.loop = true;
                    SoundManager.PlaySound("footstepsw");
                    aura.Stop();
                    SetModeGoForward();
                }
            }

            if(DoAction == DoActionRotateAroundGrip)
            {
                rope.SetPosition(0, _owner.Position);
                rope.SetPosition(1, currentGrip.transform.position);
            }
        }

        #endregion

        #region Ability

        public override void StartAbility()
        {
            base.StartAbility();
            SetModeGoForward();
        }

        public override void UpdateAbility()
        {
            base.UpdateAbility();
            DoAction();
        }

        public override void StopAbility()
        {
            base.StopAbility();
            currentGrip = null;
        }

        #endregion

        #region Mode Void 

        private void SetModeVoid()
        {
            DoAction = DoActionVoid;
        }

        private void DoActionVoid() {}

        #endregion

        #region Mode GoForward 

        private void SetModeGoForward()
        {
            DoAction = DoActionGoForward;

            CalculateCurrentForward();

            rope.gameObject.SetActive(false);

            _owner.Body.Rotator.localRotation = Quaternion.identity;
        }

        private void DoActionGoForward()
        {
            _owner.Velocity = currentForward * speed * 1.5f;
            _owner.Body.Rb.rotation = Quaternion.Slerp(_owner.Body.Rb.rotation, Quaternion.LookRotation(currentForward), rotationSpeed * Time.deltaTime);
        }

        #endregion

        #region Mode RotateAroundGrip 

        private void SetModeRotateAroundGrip()
        {
            DoAction = DoActionRotateAroundGrip;
            rope.gameObject.SetActive(true);

            Vector3 gripPos = currentGrip.transform.position;
            gripPos.y = 0f;

            Vector3 playerPos = _owner.Body.Rb.position;
            playerPos.y = 0f;

            startRotatingMagnitude = (playerPos - gripPos).magnitude;
        }

        private void DoActionRotateAroundGrip()
        {
            Vector3 rotationAxis = currentGrip.IsClockWise ? Vector3.up : Vector3.down; 
            Quaternion q = Quaternion.AngleAxis(3f, rotationAxis);

            Vector3 gripPos = currentGrip.transform.position;
            gripPos.y = 0f;

            Vector3 playerPos = _owner.Body.Rb.position;
            playerPos.y = 0f;

            _owner.Body.Rb.MovePosition(q * ((playerPos - gripPos).normalized * startRotatingMagnitude) + gripPos);
            
            CalculateCurrentForward();

            _owner.Body.Rb.rotation = Quaternion.Slerp(_owner.Body.Rb.rotation, Quaternion.LookRotation(currentForward), rotationSpeed * Time.deltaTime);

            float rotationAngle = currentGrip.IsClockWise ? 90f : -90f;
            Quaternion targRot = Quaternion.AngleAxis(rotationAngle, Vector3.up);
            _owner.Body.Rotator.localRotation = Quaternion.Slerp(_owner.Body.Rotator.localRotation, targRot, rotationSpeed * Time.deltaTime);
        }

        #endregion

        private void CalculateCurrentForward()
        {
            RaycastHit hit;

            if (Physics.Raycast(_owner.Position + Vector3.up * 0.1f, Vector3.down, out hit, 2f, groundMask))
            {
                SplineComputer spline = hit.transform.GetComponent<SplineComputer>();
                SplineSample sample = spline.Project(_owner.Position);

                currentForward = sample.forward;
                currentForward.y = 0f;
            }
        }

        public void NotifyGripDetected(Grip grip)
        {
            currentGrip = grip;
        }

        public void NotifyGripExit(Grip grip)
        {
            if (currentGrip == grip)
            {
                currentGrip = null;
            }
        }

        public void Victory()
        {
            speed = 0;
            animator.SetBool("isWin", true);
        }

    }
}
