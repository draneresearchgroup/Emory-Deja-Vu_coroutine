using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// basic file to show FPS of Unity
 
 public class showFPS : MonoBehaviour {
     public float deltaTime;
 
     void Update () {
         deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
         float fps = 1.0f / deltaTime;
         Debug.Log("Frames: " + fps);

     }
}
 
