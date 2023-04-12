using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class button_responder : MonoBehaviour
{
    public TMP_Text session_input;
    public TMP_Text participant_input;

    public TMP_Dropdown version;
    public TMP_Dropdown com;


    public string session_text;
    public string participant_text;
    public string version_text;
    private int participant_num;
    private int session_num;
    private int version_num;
    private string comport_text;
    private DataPrint DataPrinter;  // to write file info
 



    // Report the information stored in each input field.
    public void buttonreponse() {
        
        PlayerPrefs.DeleteAll();
        session_text = session_input.text;
        participant_text = participant_input.text;
        version_text = version.options[version.value].text;
        comport_text = com.options[com.value].text;
        Debug.Log(version_text);

        Debug.Log("Participant Name: " + participant_text
                    + "\nSession name: " + session_text);

        Debug.Log("Version number: " + version.options[version.value].text);
        Debug.Log("Site: " + com.options[com.value].text);

        DataPrinter = new DataPrint();
        DataPrinter.initializeDataPrinter(participant_text, version_text, comport_text);

        SceneManager.LoadScene("Instructions");

    }


}
