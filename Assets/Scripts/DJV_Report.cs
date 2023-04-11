// ########################################################################################################################
// ########################################################################################################################
//
//  This is a program to measure participant report of feeling of deja vu during presentation of VR scenes with HTC Vive Pro headset.
//  The program was developed by Noah Okada and Ameer Husary at the Epilepsy and Systems Neuroscience Laboratory at Emory University School of Medicine.
//  December 2021.
//
//  Software information
//      - Unity:        2020.3.17f1 
// 
//  Conditions
//      - DJV_Report script:            Attached to XR Rig.
//     
// ########################################################################################################################
// ########################################################################################################################
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO.Ports;

public class DJV_Report : MonoBehaviour
{
    public ActionBasedController controllerL;   //Action Based Controller linked to HTC Vive Controller
    public ActionBasedController controllerR;   //Action Based Controller linked to HTC Vive Controller
    private DataPrint DataPrinter;  //Connects to DataPrint Object to write data to output file
    private bool isPressed;         //Button press condition
    string responseInfo;            //string to list participant response
    string responseTime;                       //string to output time of participant response


    // Start is called before the first frame update
    void Start()
    {
    //********************************************************************************************************************
    //
    // At the begining of the scene we instantiate the dataprinter to connect to the textfile to be printed. 
    // Then we search for ActionBasedController in scene. This controller can be either left or right HTC Vive controller.
    // We then write the data from the button response if the button is pressed during the scene. 
    //
    //
    // 
    //********************************************************************************************************************
     
        DataPrinter = new DataPrint();
      
    }

    void Update(){
       controllerL.selectAction.action.performed += Action_performed;
      if(isPressed==true) {writeTTL();} 
    }


    void writeTTL(){
       DataPrinter.sendttlPulse(1);
        responseInfo = "Deja Vu indicated at: ";
        responseTime = "" + System.DateTime.Now+"\n";
        DataPrinter.WriteToFile(responseInfo + responseTime);
        Debug.Log(responseInfo + responseTime);
        isPressed = false;
        
       
    }




    private void Action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
    //********************************************************************************************************************
    //
    // Perform action of writing system time to text file. 
    //
    // Note:
    //********************************************************************************************************************
       isPressed = true;
    }


}
