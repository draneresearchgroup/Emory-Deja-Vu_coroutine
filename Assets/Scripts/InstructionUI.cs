using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;


public class InstructionUI : MonoBehaviour
{

    public Text instruction;
    int updater = 0;
    private DataPrint DataPrinter;  //Connects to DataPrint Object to write data to output file

    // Start is called before the first frame update
    void Start()
    {
        DataPrinter = new DataPrint();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void cycleText()

    {

        updater = updater + 1;
        if (updater == 1)
            instruction.text = "You will see a series of brief video tours.";
        else if (updater == 2)
            instruction.text = "During the first study phase, while watching each video, you will hear a voice tell you what the scene is. ";
        else if (updater ==3)
            instruction.text = "During the first study phase, while watching each video, you will hear a voice tell you what the scene is. ";
        else if (updater == 4)
            instruction.text = "For example, while viewing a golf course, the voice would say \"This is a golf course. Golf course\" ";
        else if (updater == 5)
            instruction.text = "Simply watch each scene and try to remember it.";
        else if (updater == 5)
            instruction.text = "When the first set of video tours is over, you will be presented with a second phase.";
        else if (updater == 6)
            instruction.text = "Please press continue to begin the first study phase.";
        else if (updater == 7){
            DataPrinter.sendttlPulse(5);
            SceneManager.LoadScene(0);
        }
            

    }
}
