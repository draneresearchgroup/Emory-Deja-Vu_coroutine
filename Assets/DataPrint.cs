using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.IO.Ports;


public class DataPrint : MonoBehaviour
{
    private string myFilePath;
    public  int participant_num;
    public int version;
    public  int block_num;
    private static int v; //version static
    private static int b; //block static
    private static int pnum; //participant num static
   
   
   //SERIAL PORT STUFF
    public SerialPort sp;
    float next_time;

    void Start()
    {
        serialportEnabling();
        v = version;
        pnum = participant_num;
        b = block_num;
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Logs/");
        myFilePath = Application.streamingAssetsPath + "/Logs/" + "ParticipantResponse"+pnum + ".txt";
        WriteToFile("Virtual Reality Deja Vu Virtual Tour Paradigm:" + "\n"+ "Participant:" + participant_num + "\n"+ "Version:"+version+"\n"+"Block:" + block_num + "\n");
        WriteToFile("Virtual Reality Deja Vu Virtual Tour Paradigm:" + "\n"+ "Participant:" + participant_num + "\n"+ "Version:"+version+"\n"+"Block:" + block_num + "\n");
        WriteToFile("\n" + "==========================================================" + "\n");


    }

  
    public void WriteToFile(string s)
    {
        myFilePath = Application.streamingAssetsPath + "/Logs/" + "ParticipantResponse" + pnum + ".txt";
       
        if (!File.Exists(myFilePath))
        {
            File.WriteAllText(myFilePath, "Data from Participants" + "\n");
        }
        try
        {
            StreamWriter filewriter = new StreamWriter(myFilePath, true);
            filewriter.Write(s);
            filewriter.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Cannot write into the File");
        }
    }

    public void sendttlPulse(int pulseCount){
        string the_com = "COM3";
        sp = new SerialPort("\\\\.\\" + the_com, 9600);
        if(!sp.IsOpen)   sp.Open();
        if(sp.IsOpen)  sp.Write(pulseCount.ToString());
        sp.Close();
    }


    public void serialportEnabling(){
        string the_com="";
        next_time = Time.time;
        
        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM1")
            {
                the_com = mysps;
                break;
            }
        }

        sp = new SerialPort("\\\\.\\" + the_com, 9600);
        if (!sp.IsOpen)
        {
            print("Opening " + the_com + ", baud 9600");
            sp.Open();
            sp.ReadTimeout = 100;
            sp.Handshake = Handshake.None;
            if (sp.IsOpen) { print("Open"); }
        }


    }

}
