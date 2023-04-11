using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComputerandVideoGameQ : MonoBehaviour
{
    public Text activity;
    public GameObject q3;
    public GameObject q4;
    private DataPrint DataPrinter;  // to write file info
    int updater = 0;
    string input;

    // Start is called before the first frame update
    void Start()
    {
        DataPrinter = new DataPrint();


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Q1_strongagree()
    {
        DataPrinter.WriteToFile("\n" + "Computer and Video Game Questionnaire" + "\n");
        DataPrinter.WriteToFile("Q1: Strongly Agree\n");
    }
    public void Q1_agree()
    {
        DataPrinter.WriteToFile("\n" + "Computer and Video Game Questionnaire" + "\n");
        DataPrinter.WriteToFile("Q1: Agree\n");
    }
    public void Q1_disagree()
    {
        DataPrinter.WriteToFile("\n" + "Computer and Video Game Questionnaire" + "\n");

        DataPrinter.WriteToFile("Q1: Disgree\n");
    }
    public void Q1_srongdisagree()
    {
        DataPrinter.WriteToFile("\n" + "Computer and Video Game Questionnaire" + "\n");

        DataPrinter.WriteToFile("Q1: Strongly Disagree\n");
    }


    public void Q2_compinexperienced()
    {
        DataPrinter.WriteToFile("Q2: Completely Inexperienced\n");
    }
    public void Q2_inexperienced()
    {
        DataPrinter.WriteToFile("Q2: Inexperienced\n");
    }
    public void Q2_somewhat()
    {
        DataPrinter.WriteToFile("Q2: Somewhat experienced/inexperienced\n");
    }
    public void Q2_Experienced()
    {
        DataPrinter.WriteToFile("Q2: Experienced\n");
    }
    public void Q2_VeryExperienced()
    {
        DataPrinter.WriteToFile("Q2: Very Experienced\n");
    }


    public void Q3_1()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("1\n");
    }
    public void Q3_2()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("2\n");
    }
    public void Q3_3()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("3\n");
    }
    public void Q3_4()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("4\n");
    }
    public void Q3_5()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("5\n");
    }
    public void Q3_6()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("6\n");
    }
    public void Q3_7()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("7\n");
    }
    public void Q3_8()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("8\n");
    }
    public void Q3_9()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("9\n");
    }
    public void Q3_10()
    {
        DataPrinter.WriteToFile("Q3:" + activity.text + ":");
        DataPrinter.WriteToFile("10\n");
    }

    public void Q3_ChangeActivity()
    {
        updater++;
        if (updater == 1)
            activity.text = "Programming";
        else if (updater == 2)
            activity.text = "Playing Games on my Cell Phone";
        else if (updater == 3)
            activity.text = "Playing Games on my Computer";
        else if (updater == 4)
            activity.text = "Playing Games on my Game Console";
        else if (updater == 5)
            activity.text = "Data Entry/Processing";
        else if (updater == 6)
            activity.text = "Graphic Design/Art";
        else if (updater == 7)
            activity.text = "Surfing the Internet";
        else if (updater == 8)
            activity.text = "Emailing";
        else if (updater == 9)
            activity.text = "Other";
        
        if (updater > 9)
        {
            q3.SetActive(false);
            q4.SetActive(true);
        }
    }




    public void Q4_yes()
    {
        DataPrinter.WriteToFile("Q4: Yes\n");
    }
    public void Q4_no()
    {
        DataPrinter.WriteToFile("Q4: No\n");
    }
    public void Q5_yes()
    {
        DataPrinter.WriteToFile("Q5: Yes\n");
    }
    public void Q5_no()
    {
        DataPrinter.WriteToFile("Q5: No\n");
    }
    public void Q6_yes()
    {
        DataPrinter.WriteToFile("Q6: Yes\n");
    }
    public void Q6_no()
    {
        DataPrinter.WriteToFile("Q6: No\n");
    }



    public void endVideoGameQuestion()
    {
        DataPrinter.WriteToFile("\n" + "============================================" + "\n");
    }




}
