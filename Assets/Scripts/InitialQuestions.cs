using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitialQuestions : MonoBehaviour
{
    // Start is called before the first frame update
    private DataPrint DataPrinter;  // to write file info
    int updater = 0;

    void Start()
    {
        DataPrinter = new DataPrint();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void moveToInstruction()
    {
        DataPrinter.WriteToFile("\n" + "END OF SURVEY QUESTIONS" + "\n");
        DataPrinter.WriteToFile("\n" + "============================================" + "\n");
        SceneManager.LoadScene("Instructions");

    }

}
