using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;  //uncommented scene management package

public class studyDJVplayer : MonoBehaviour
{
    
    // study phase:  show video, play audio, display ISI cross-hair, then move to next video.

    private static int n = 4; // number of video clips, 16 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public string[] videonames = new string[n];
    public VideoClip[] videos = new VideoClip[n];
    public int frames = 30; // frame rate to change dynamically
    public GameObject cross;


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
            // move to the test phase
            SceneManager.LoadScene("DJVTest");
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        cross.SetActive(false);
        vp = GetComponent<VideoPlayer>();
        
        StartCoroutine(deja_vu_coroutine(index));
    }

   void Update()
   {
        Application.targetFrameRate = frames;
   }
}