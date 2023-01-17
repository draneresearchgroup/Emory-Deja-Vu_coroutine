using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndExperiment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   public void endExperiment()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
