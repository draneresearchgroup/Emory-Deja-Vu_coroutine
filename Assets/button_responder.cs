using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class button_responder : MonoBehaviour
{
    public TMP_Text session_input;
    public TMP_Text participant_input;

    public TMP_Dropdown version;
    public TMP_Dropdown site;

    public Toggle vr_checkbox;
    public Toggle eeg_checkbox;

    public string session_text;
    public string participant_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Report the information stored in each input field.
    public void buttonreponse() {
        session_text = session_input.text;
        participant_text = participant_input.text;

        Debug.Log("Participant Name: " + participant_text
                    + "\nSession name: " + session_text);

        Debug.Log("Version number: " + version.options[version.value].text);
        Debug.Log("Site: " + site.options[site.value].text);


        if(vr_checkbox.isOn) {
            Debug.Log("vr enabled");
        } else {
            Debug.Log("vr disabled");
        }


        if(eeg_checkbox.isOn) {
            Debug.Log("EEG enabled");
        } else {
            Debug.Log("EEG disabled");
        }

    }


}
