///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 23/07/2020 10:34
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SLOWMOGameKit 
{
    public class LevelGenerator : Singleton<LevelGenerator> 
    {
        protected override void Awake()
        {
            base.Awake();
            SceneManager.LoadScene("SCN_Level_1", LoadSceneMode.Additive);
        }

        public void ReloadGame()
        {
            SceneManager.LoadScene(0);
            SceneManager.LoadScene("SCN_Level_1", LoadSceneMode.Additive);
        }
    }
}
