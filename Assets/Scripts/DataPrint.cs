using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.IO.Ports;


public class DataPrint : MonoBehaviour
{
    private string myFilePath;
    private  string participant_num;
    private string version;
    private  string block_num;
    private static string v; //version static
    private static string b; //block static
    private static string pnum; //participant num static
    private static string the_com;

   
   
   //SERIAL PORT STUFF
    public SerialPort sp;
    float next_time;

    public void initializeDataPrinter(string participant_num, string version_num, string block, string set_com)
    {
        v = version_num;
        b = block;
        pnum = participant_num;
        the_com = set_com;

        string study_version ="DJV_v"+v+"_study_b"+b;
        string test_version ="DJV_v"+v+"_test_b"+b;
        PlayerPrefs.SetString("Study", study_version);
        PlayerPrefs.SetString("Test", test_version);

        Directory.CreateDirectory(Application.streamingAssetsPath + "/Logs/");
        serialportEnabling();
        myFilePath = Application.streamingAssetsPath + "/Logs/" + "ParticipantResponse"+pnum + ".txt";
        WriteToFile("Virtual Reality Deja Vu Virtual Tour Paradigm:" + "\n"+ "Participant:" + pnum + "\n"+ "Version:"+v+"\n"+"Block:"+b+"\n");
        WriteToFile("\n" + "==========================================================" + "\n");

    }

    public void initializeDataPrinterNoCom(string participant_num, string version_num,  string block)
    {
        v = version_num;
        pnum = participant_num;
        b =block;
        the_com = null;

        string study_version ="DJV_v"+v+"_study_b"+b;
        string test_version ="DJV_v"+v+"_test_b"+b;
        PlayerPrefs.SetString("Study", study_version);
        PlayerPrefs.SetString("Test", test_version);

        Directory.CreateDirectory(Application.streamingAssetsPath + "/Logs/");
        myFilePath = Application.streamingAssetsPath + "/Logs/" + "ParticipantResponse"+pnum + ".txt";
        WriteToFile("Virtual Reality Deja Vu Virtual Tour Paradigm:" + "\n"+ "Participant:" + pnum + "\n"+ "Version:"+v+"\n"+ "\n");
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
         if(the_com!=null)
         {
                    sp = new SerialPort("\\\\.\\" + the_com, 9600);
                    if(!sp.IsOpen)   sp.Open();
                    if(sp.IsOpen)  sp.Write(pulseCount.ToString());
                    sp.Close();
         }

    }


    public void serialportEnabling(){
        
        if(the_com!=null)
        {
            string this_com=the_com;
            next_time = Time.time;
        

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

}

