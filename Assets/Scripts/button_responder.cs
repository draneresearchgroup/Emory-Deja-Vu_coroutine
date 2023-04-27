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
    public TMP_Dropdown ttl;
    public TMP_Dropdown block;


    public string session_text;
    public string participant_text;
    public string version_text;
    private int participant_num;
    private int session_num;
    private int version_num;
    private string comport_text;
    private string ttl_text;
    private string block_text;
    private DataPrint DataPrinter;  // to write file info
 



    // Report the information stored in each input field.
    public void buttonreponse() {
        
        PlayerPrefs.DeleteAll();
        session_text = session_input.text;
        participant_text = participant_input.text;
        version_text = version.options[version.value].text;
        comport_text = com.options[com.value].text;
        block_text = block.options[block.value].text;
        ttl_text = ttl.options[ttl.value].text;
     

        DataPrinter = new DataPrint();
        if(string.Equals(ttl_text, "Enabled"))
        {
            DataPrinter.initializeDataPrinter(participant_text, version_text, block_text,comport_text);

        }
        else
        {
            DataPrinter.initializeDataPrinterNoCom(participant_text, version_text, block_text);
        }

        SceneManager.LoadScene("Instructions");

    }


}
