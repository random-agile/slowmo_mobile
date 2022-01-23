///-----------------------------------------------------------------
///   Author : Baptiste Falvet                    
///   Date   : 27/09/2020 10:19
///-----------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace SLOWMOGameKit 
{
    public class CreateNewCharacterAbilityFromCustomTemplate : Editor
    {
        private const string pathToYourScriptTemplate = "Assets/_SLOWMOGameKit/Scripts/Templates/CharacterAbilityTemplate.cs.txt";

        [MenuItem(itemName: "Assets/Create/SLOWMO/CharacterAbility", isValidateFunction: false, priority: 51)]
        public static void CreateScriptFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToYourScriptTemplate, "NewCharacterAbility.cs");
        }
    }
}
