using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class studyDJVplayer : MonoBehaviour
{
    
    // study phase:  show video, play audio, display ISI cross-hair, then move to next video.

    private static int n = 4; // number of video clips, 16 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public string[] videonames;
    public VideoClip[] videos;
    public int frames = 30; // frame rate to change dynamically


    // study variables
    public string[] studyvideonames = new string[n];
    public VideoClip[] studyvideos = new VideoClip[n];
    public GameObject cross;


    // to do:
    // dynamic framerate fixing: https://docs.unity3d.com/ScriptReference/Application-targetFrameRate.html


    //Great work! Here are my suggestions:

    /* 
    *** Consolidate coroutine and use parameter values***
    -> deja_vu_coroutine(int index_of_video, int index_of_video_name )
            ->set video from the passed parameter
            ->run video
            -> set cross hair
            ->move static trial_index up (trial++)
            ->OnTrialEnd() run a method that switches the videos
        //This coroutine runs one video, shows cross hair, and exits
        //You can call this coroutine in both the study and the test phase
     */

     /*
    *** Use a Method to Manage the Study and Test Blocks ***

    // OnTrialEnd()
            //if(condition is study) 
            {
                 if(trial_index < trial_nums) -> startcoroutine(deja_vu_coroutine) //for study

                 else
                    switch to test block
            }
            else if(condition is test)
            {
               run the UI
                 if(trial_index < trial_nums) -> startcoroutine(deja_vu_coroutine) //for test
                 else
                    end game
            }

            
     */

    // mock end function just to make sure the end of the videos is reached

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
        
        // trial block ends
        OnTrialEnd();
    
    }

    void OnTrialEnd(){
        // for study phase — continue trials
        Debug.Log("OnTrialEnd reached");
        if(index < n) {
            Debug.Log("Loading new video...");
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
        videonames = studyvideonames;
        videos = studyvideos;
    }

    // Start is called before the first frame update
    void Start()
    {   
        cross.SetActive(false);
        load();
        vp = GetComponent<VideoPlayer>();
        
        StartCoroutine(deja_vu_coroutine(index));
    }

   void Update()
   {
        Application.targetFrameRate = frames;
        // Debug.Log("Frames: " + Application.targetFrameRate);
   }
}