using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DJVplayer : MonoBehaviour
{
    // study phase:  show video, play audio, display ISI cross-hair, then move to next video.
    // test phase: show video (no audio), participant response block (UI), then move to next video

    private static int n = 4; // number of video clips, 16 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public string[] videonames;
    public VideoClip[] videos;
    // study variables
    public string[] studyvideonames = new string[n];
    public VideoClip[] studyvideos = new VideoClip[n];
    public GameObject cross;

    // test variables
    public string[] testvideonames = new string[n];
    public VideoClip[] testvideos = new VideoClip[n];
    public GameObject UI;

    public int condition = 0; // if 0, load study, if 1, load test

    // to do:
    // does the test phase have a participant's block after every video or after every other video?
    // Yes the test phase will have a paerticipant response after each video


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





    IEnumerator deja_vu_coroutine(string videoname)
    {
        while (index < n){ 
            string nextvideo = videonames[index];
            vp.clip = videos[index];
            vp.Prepare();
            yield return new WaitForSeconds(3f);
            float time = (float) GetComponent<VideoPlayer>().clip.length;
            RenderSettings.skybox = skyboxMaterial;
            vp.Play();
            yield return new WaitForSeconds(time);
            // play dark screen
            RenderSettings.skybox = (black);
            // study phase: display crosshair image
            if (condition == 0) {
                cross.SetActive(true);
                yield return new WaitForSeconds(3f);
                cross.SetActive(false);
            }
            // test phase: display UI
            else {
                UI.SetActive(true);
                yield return new WaitForSeconds(3f); // for UI things
                UI.SetActive(false);
            }
              
            index += 1;
        }
        // just to check to make sure thing ended
        cross.SetActive(true);
        yield return new WaitForSeconds(5f);
        cross.SetActive(false);
        //GO back to a home scene that would play the study phase
        //switch scene //we’ll cover this later but you can use the scenemanager unity object from Unity.SceneManagement
    }

    void load()
    {
        if (condition == 0) { // load study
            videonames = studyvideonames;
            videos = studyvideos;
        }
        else { // load test
            videonames = new string[2*n];
            videos = new VideoClip[2*n];
            // videonames = testvideonames;
            // videos = testvideos;
            
            // following code is under the assumption that the study videos is the novel scenes and test videos are the spatially similar scene? 
            int i = 0;
            // fill array with study and test videos
            while (i < 2*n) {
                videonames[i] = studyvideonames[i];
                videos[i] = studyvideos[i];
                i++;
                videonames[i] = testvideonames[i];
                videos[i] = testvideos[i];
                i++;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        load();
        vp = GetComponent<VideoPlayer>();
        
        StartCoroutine(deja_vu_coroutine(videonames[index]));
    }

   
}