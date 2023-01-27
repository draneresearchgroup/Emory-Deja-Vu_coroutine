using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//STUDY PHASE
public class study : MonoBehaviour
{
    public string[] videonames = new string[16];
    public Video[] videos = new Video[16];
    private VideoPlayer testVideo;

    IEnumerator deja_vu_coroutine(string videoname)
    { 
        testVideo = GetComponent<VideoPlayer>();
        testVideo.Play();
        yield return new WaitForSeconds(3f); // how long is this going to be played?
        testVideo.Stop();
        //play dark screen
        RenderSettings.skybox = (null);
        //1. Remove VP render new Skybox
        //2. Switch to Camera Rendered onto specific crosshair (+) image
        //3. Wait for x amount of time (float)
        yield return new WaitForSeconds(3f);
        playNextVideo(); //go to onEnd / playNextVideo method
    }

    void playNextVideo()
    {
        if (index < 16)
        {
            string nextvideo = videonames.next();
            deja_vu_coroutine(nextvideo);
        }
        else
        {
            //GO back to a home scene that would play the study phase
            //switch scene //we’ll cover this later but you can use the scenemanager unity object from Unity.SceneManagement
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(deja_vu_coroutine(videonames[0]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}