using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderManager : MonoBehaviour
{
    // Start is called before the first frame update
    Initializer init;
    private DJV stimuli;
    private DataPrint DataPrinter;  
    private int counter;
    private int condition;
    private int version;
    private int updatedCounter;

    void Start()
    {
        DataPrinter = new DataPrint();

        condition = PlayerPrefs.GetInt("Condition");
        counter = PlayerPrefs.GetInt("counter");
        conditionControl(condition);

        updatedCounter = counter;
        if (updatedCounter > 0)
        {
            updatedCounter = updatedCounter - 1;
           
            StartCoroutine(goToScene());
           

        }
        else if (condition == 0)
        {
            StartCoroutine(back());
        }
        else if (condition == 1)
        {
            DataPrinter.sendttlPulse(5); 
            StartCoroutine(end());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void conditionControl(int condition)
    {
       if(condition == 0)
        {
          
            stimuli = Initializer.StudyDJVlist[0];  
        }
        else
        {
            stimuli = Initializer.TestDJVlist[0];
        }
    }

    


    IEnumerator goToScene()
    {
        yield return new WaitForSeconds(2);
      
        SceneManager.LoadScene(stimuli.getSceneNum());
        PlayerPrefs.SetInt("counter", updatedCounter);
 
    }

    IEnumerator back()
    {
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
        PlayerPrefs.SetInt("Condition", 1);
        SceneManager.LoadScene(66);
    }
    IEnumerator end()
    {
        //yield on a new YieldInstruction that waits for 2 seconds.
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(68);
    }

}

