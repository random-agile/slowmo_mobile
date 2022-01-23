using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace DriftRace
{
    public class AddUICameraInStack : MonoBehaviour
    {
        private void Start()
        {
            UniversalAdditionalCameraData cameraData = Camera.main.GetUniversalAdditionalCameraData();
            cameraData.cameraStack.Add(GetComponent<Camera>());
        }
    }
}
