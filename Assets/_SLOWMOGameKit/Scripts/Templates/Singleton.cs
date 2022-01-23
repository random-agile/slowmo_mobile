///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 29/03/2020 07:05
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLOWMOGameKit
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance { get; private set; }

        virtual protected void Awake()
        {
            if(Instance == null)
            {
                Instance = (T)FindObjectOfType(typeof(T));
            }
            else
            {
                Debug.LogWarning("A singleton can only be instantiated once!");
                Destroy(gameObject);
            }
        }

        virtual protected void OnDestroy()
        {
            if(Instance == this)
            {
                Instance = null;
            }
        }
    }
}
