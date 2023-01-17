using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestCueInitializer : MonoBehaviour
{
    Initializer init;
    // Start is called before the first frame update

    void Start()
    {
        PlayerPrefs.SetInt("Condition", 1); ///changes to test condition
        PlayerPrefs.SetInt("counter", Initializer.TestDJVlist.Count);// players should be displayed 32 scenes in this condition
        SceneManager.LoadScene(0); //los to do with UI here first
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
