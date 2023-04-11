using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class testDJVplayer : MonoBehaviour
{
    
    // test phase: show video (no audio), participant response block (UI), then move to next video

    private static int n = 4; // number of video clips, 32 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    // public string[] videonames = new string[n];
    // public VideoClip[] videos = new VideoClip[n];
    
    private int frames = 30; // frame rate to change dynamically
    public GameObject cross;
    public GameObject UI;

     //CSV Reader and DJV Trials
    DJV_CSVReader csv_reader;
    DJV_Trial trial;
    List<DJV_Trial> trials;

    IEnumerator deja_vu_coroutine(DJV_Trial trial)
    {

        string videoname = trial.videoName;
        vp.clip = Resources.Load<VideoClip>(trial.videoReference) as VideoClip;



        vp.Prepare();
        yield return new WaitForSeconds(3f);
        float time = (float) GetComponent<VideoPlayer>().clip.length;
        RenderSettings.skybox = skyboxMaterial;
        Debug.Log("Video loaded, now playing:  " + videoname);
        vp.Play();
        yield return new WaitForSeconds(time);

        Debug.Log("Video finished playing");
        // play dark screen
        RenderSettings.skybox = (black);

        yield return new WaitForSeconds(3f);

        
        // trial block ends
        OnTrialEnd();
    
    }

    void OnTrialEnd(){
        Debug.Log("OnTrialEnd reached");
        index++;
        PlayerPrefs.SetInt("Test_Index", index);
        if(index < n) {
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
        csv_reader = new DJV_CSVReader();
        trials = csv_reader.ReadTrialCSV("test_version");
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
        
        StartCoroutine(deja_vu_coroutine(trials[index])); //maybe not index. Maybe will dynamically change to other scene for simplicity
    }

   void Update()
   {
        Application.targetFrameRate = frames;
   }
}