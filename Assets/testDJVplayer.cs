using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
// using Unity.SceneManagement;

public class testDJVplayer : MonoBehaviour
{
    
    // test phase: show video (no audio), participant response block (UI), then move to next video

    private static int n = 4; // number of video clips, 16 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public string[] videonames;
    public VideoClip[] videos;
    public int frames = 30; // frame rate to change dynamically

    public GameObject cross;

    // test variables
    public string[] testvideonames = new string[n];
    public VideoClip[] testvideos = new VideoClip[n];
    public GameObject UI;



    // to do: OH MY GOD THINGS ARE FIXED
    // dynamic framerate fixing: https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html

    IEnumerator end()
    {
        cross.SetActive(true);
        yield return new WaitForSeconds(5f);
        cross.SetActive(false);
    }


    IEnumerator deja_vu_coroutine(int curr_index)
    {
        string videoname = videonames[curr_index];
        vp.clip = videos[curr_index];
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
            
        index++;
        // display crosshair image
        cross.SetActive(true);
        yield return new WaitForSeconds(3f);
        cross.SetActive(false);

        // test phase: run UI (mock)
        UI.SetActive(true);
        yield return new WaitForSeconds(5f);
        UI.SetActive(false);
        
        // trial block ends
        OnTrialEnd();
    
    }

    void OnTrialEnd(){
        Debug.Log("OnTrialEnd reached");
        if(index < n) {
            StartCoroutine(deja_vu_coroutine(index));
        }
        else {
            // end game
            end();
            //GO back to a home scene that would play the study phase
            //switch scene //we’ll cover this later but you can use the scenemanager unity object from Unity.SceneManagement
        }    
    }

    void load()
    {
        // load test
        videonames = testvideonames;
        videos = testvideos;
    }

    // Start is called before the first frame update
    void Start()
    {   
        UI.SetActive(false);
        cross.SetActive(false);
        load();
        vp = GetComponent<VideoPlayer>();
        
        StartCoroutine(deja_vu_coroutine(index));
    }

   void Update()
   {
        Application.targetFrameRate = frames;
   }
}