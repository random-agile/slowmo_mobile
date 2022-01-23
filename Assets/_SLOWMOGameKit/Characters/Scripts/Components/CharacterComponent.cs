///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 27/09/2020 10:30
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLOWMOGameKit 
{
    public class CharacterComponent<T> : MonoBehaviour where T : CharacterBase
    {
        protected T _owner;

        public T Owner { get { return _owner; } }

        virtual protected void Awake()
        {
            _owner = GetComponentInParent<T>();
        }
    }
}
