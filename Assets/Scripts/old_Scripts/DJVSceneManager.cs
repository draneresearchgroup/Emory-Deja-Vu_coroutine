using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class DJVSceneManager : MonoBehaviour
{
    private static string sceneName;
    private static string sceneDuration;
    private static Scene s;
    private static int BI;
    private DataPrint DataPrinter;
    private string time;
    // Start is called before the first frame update
    void Start()
    {
        DataPrinter = new DataPrint(); 
        s = SceneManager.GetActiveScene();
        Debug.Log("You have arrived to the scene called " + s.name);
        DataPrinter.WriteToFile("Scene Name: " + s.name);
        BI = s.buildIndex;
        time = ""+System.DateTime.Now; 
        DataPrinter.WriteToFile("\n" + "Scene Build Index: " + BI);
        DataPrinter.WriteToFile("\n" + time); 
    }

    // Update is called once per frame
    void Update()
    {
        BI = s.buildIndex + 1;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DataPrinter.WriteToFile("\n" + "======================================" + "\n");
            SceneManager.LoadScene(BI); 

        }
    }
}
