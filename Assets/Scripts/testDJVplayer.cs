using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class testDJVplayer : MonoBehaviour
{
    
    // test phase: show video (no audio), participant response block (UI), then move to next video

    private static int n = 32; // number of video clips, 32 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public GameObject VRplayer;
    private DataPrint DataPrinter;

    public GameObject cross;
    public GameObject UI;

     //CSV Reader and DJV Trials
    DJV_CSVReader csv_reader;
    DJV_Trial trial;
    List<DJV_Trial> trials;

    IEnumerator deja_vu_coroutine(DJV_Trial trial)
    {
        DataPrinter = new DataPrint();
        DataPrinter.sendttlPulse(2);
        DataPrinter.WriteToFile("SceneNum:" + trial.videoNum + "\n");
        DataPrinter.WriteToFile("Scene:"+trial.videoName+"\n");
        DataPrinter.WriteToFile("Order:" + index + "\n");
        DataPrinter.WriteToFile("=======================================" + "\n");


        string videoname = trial.videoName;
        vp.clip = Resources.Load<VideoClip>(trial.videoReference) as VideoClip;
        Debug.Log(trial.videoReference);

         // play dark screen
        RenderSettings.skybox = (black);
        VRplayer.transform.eulerAngles = new Vector3(0f,trial.rotation, 0f);
        vp.Prepare();
        yield return new WaitForSeconds(3f);


        float time = trial.duration;
        RenderSettings.skybox = skyboxMaterial;
        Debug.Log("Video loaded, now playing:  " + videoname+"Time:"+time);
        vp.Play();
        yield return new WaitForSeconds(time); //5 seconds of play to ensure no turn is identifiable
        vp.Pause();
        yield return new WaitForSeconds(3f);


        
        DataPrinter.sendttlPulse(2);
        Debug.Log("Video finished playing");
        // play dark screen
        RenderSettings.skybox = (black);
        yield return new WaitForSeconds(1f);

        // trial block ends
        OnTrialEnd();
    
    }

    void OnTrialEnd(){
        Debug.Log("OnTrialEnd reached");
       
       
        if(index < n) {
             index++;
              PlayerPrefs.SetInt("Test_Index", index);
            SceneManager.LoadScene("ParticipantResponse");
        }
        else {
            // switch to end scene
            SceneManager.LoadScene("endScene");
        }    
    }

    // Start is called before the first frame update
    void Start()
    {   
        // csv_reader = new DJV_CSVReader();
        // string version_name = PlayerPrefs.GetString("Test");
        // trials = csv_reader.ReadTestTrialCSV(version);
        trials = TestPhaseInstructionsUI.testList;
        UI.SetActive(false);
        cross.SetActive(false);
        vp = GetComponent<VideoPlayer>();


        if(PlayerPrefs.HasKey("Test_Index"))
        {
            index = PlayerPrefs.GetInt("Test_Index", index);
        }
        else
        {
            index = 0;
        }
        if(index <n)
        {
                StartCoroutine(deja_vu_coroutine(trials[index])); 
        }
       else
        {
             SceneManager.LoadScene("endScene");
        }
        
    }
}