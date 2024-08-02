#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Utility
{
    public class CustomScreenCapture : MonoBehaviour
    {

    }

    [CustomEditor(typeof(CustomScreenCapture))]
    public class CustomScreenCaptureEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Take Screen Capture"))
            {
                TakeScreenCapture();
            }
        }

        private static void TakeScreenCapture()
        {
            string fileName = SceneManager.GetActiveScene().name + "_" + DateTime.UtcNow.ToString().Replace("/","_").Replace(":", "_") + ".png";
            ScreenCapture.CaptureScreenshot(fileName);

            Debug.Log("Took Screen Capture");
        }
    }

}
#endif