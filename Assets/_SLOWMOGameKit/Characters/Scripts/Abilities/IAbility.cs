///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 30/11/2020 08:17
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLOWMOGameKit 
{
    public interface IAbility
    {
        void StartAbility();
        void UpdateAbility();
        void StopAbility();
    }
}
