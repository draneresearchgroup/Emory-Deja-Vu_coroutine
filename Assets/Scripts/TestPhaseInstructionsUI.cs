using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestPhaseInstructionsUI : MonoBehaviour
{
    public Text instruction;
    int updater = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Condition", 1); ///changes to test condition
    }

    public void cycleText()
    {
        updater = updater + 1;
        if (updater == 1)
            instruction.text = "You will view short virtual tours of scenes again, but this time, they will be new ones not seen in the previous phase.";
        else if (updater == 2)
            instruction.text = "Some of the virtual tours will resemble scenes from the study phase and others will not.";
        else if (updater == 3)
            instruction.text = "After you view a tour, you will be asked several questions about it.";
        else if (updater == 4)
            instruction.text = "First, you will be asked if the test scene prompted you to feel a sense of deja vu (the feeling of having experienced something before without knowing why and despite knowing that the current situation is new). ";
        else if (updater == 5)
            instruction.text = "You will indicate Yes or No for this question.";
        else if (updater == 6)
            instruction.text = "Following this, you will be asked if you have a sense of knowing where to turn next (Yes or No). You may just have a feeling about this without knowing why. ";
        else if (updater == 7)
            instruction.text = "You will also be asked, regardless of your previous answer, to indicate (even if it's just a guess) whether the scene will proceed in a Left or Right turn.";
        else if (updater == 8)
            instruction.text = "Next, you will be asked if the test scene feels familiar to you (YES or NO).";
        else if (updater == 9)
            instruction.text = "Finally, you will be asked if the current scene reminded you of a particular earlier-presented scene from the first phase. If viewing the test scene triggered a memory of a similar-looking scene from earlier, please indicate the name of that earlier-viewed scene when prompted.";
        else if (updater == 10)
            instruction.text = "Even if the test scene did not remind you of a specific earlier-viewed scene, go ahead and take a guess when you see this prompt.";
        else if (updater == 11)
            instruction.text = "Please note that there will be no sound during the test phase.";
        else if (updater == 12)
            SceneManager.LoadScene("DJVTest");

    }
}
