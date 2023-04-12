using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParticipantResponse : MonoBehaviour
{
    // Start is called before the first frame update

    public Text instruction;
    private DataPrint DataPrinter;  // to write file info
    int updater = 0;
    string input;
    public InputField inputfield;

    void Start()
    {
        DataPrinter = new DataPrint();
    }

    // Update is called once per frame
    void Update()
    {  
        if (updater == 1)
            instruction.text = "Did this scene prompt you to feel a sense of deja vu?";
        else if (updater == 2)
            instruction.text = "Do you have a sense of knowing which way to turn next?";
        else if (updater == 3)
            instruction.text = "Indicate which direction you feel the scene will turn next.";
        else if (updater == 4)
            instruction.text = "Did this scene prompt you to feel a sense of familiarity?";
        else if (updater == 5)
        {
            instruction.text = "Does this scene remind you of a particular scene from the previous phase? If so, type it in below. Otherwise, just continue to the next question.";
            inputfield.ActivateInputField();
            inputfield.Select();
        }
            
    }


    public void senseofDejaVuY()
    {
        updater += 1;
        DataPrinter.WriteToFile("Sense of Deja Vu: YES \n");

         
    }
    public void senseofDejaVuN()
    {
        updater += 1;
        DataPrinter.WriteToFile("Sense of Deja Vu: NO \n");
    }
    public void turnPredictionY()
    {
        updater += 1;
        DataPrinter.WriteToFile("Sense of Turn: YES \n");

        //write to file turn predict y ;
        //disable both buttons
    }

    public void turnPredictionN()
    {
        updater += 1;
        DataPrinter.WriteToFile("Sense of Turn: NO \n");

    }

    public void turndirectionL()
    {
        updater += 1;
        DataPrinter.WriteToFile("Prediction of Turn: Left \n");

    }

    public void turndirectionR()
    {
        updater += 1;
        DataPrinter.WriteToFile("Prediction of Turn: Right \n");


    }

    public void familiarityY()
    {
        updater += 1;
        DataPrinter.WriteToFile("Feeling of Familiarity: YES \n");

    }

    public void familiarityN()
    {
        updater += 1;
        DataPrinter.WriteToFile("Feeling of Familiarity: NO \n");

    }

    public void familiarScene(string s)
    {

        updater += 1;
        input = s;
        Debug.Log(input);
        DataPrinter.WriteToFile("Recall Response:"+input+"\n");
    }

    public void endParticipantResponse()
    {
        DataPrinter.WriteToFile("\n" + "============================================" + "\n");
        SceneManager.LoadScene("DJVTest");
    }

    public void updateIt()
    {
        updater += 1;
      
    }


}
