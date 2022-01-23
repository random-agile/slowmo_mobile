///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 08/06/2020 10:39
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using SLOWMOGameKit;
using UnityEngine;

namespace SLOWMOGameKit
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterBody : CharacterComponent<CharacterBase>
    {
        [Header("References")]
        [SerializeField] private Transform _center;
        [SerializeField] private Transform _rotator;
        [SerializeField] private CharacterModel _model;


        public Rigidbody Rb { get; private set; }

        public Transform Center { get { return _center; } }

        public Transform Rotator { get { return _rotator; } }

        public Quaternion Rotation
        {
            get
            {
                return Rb.rotation;
            }
            set
            {
                Rb.rotation = value;
            }
        }

        public CharacterModel Model { get { return _model; } }

        protected override void Awake()
        {
            base.Awake();
            Rb = GetComponent<Rigidbody>();
        }
    }
}
