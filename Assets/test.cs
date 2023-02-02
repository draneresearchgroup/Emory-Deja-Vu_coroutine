using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class test : MonoBehaviour
{
    public string[] videonames = new string[16];
    public VideoClip[] videos = new VideoClip[16];
    private VideoPlayer testVideo;
    public GameObject cross;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public GameObject UI;

    IEnumerator deja_vu_coroutine(string videoname)
    {
        testVideo = GetComponent<VideoPlayer>();
        testVideo.clip = videos[index];
        RenderSettings.skybox = skyboxMaterial;
        testVideo.Play();
        yield return new WaitForSeconds(5f); // how long is this going to be played?
        testVideo.Stop();
        //play dark screen
        //1. Remove VP render new Skybox
        //2. Switch to Camera Rendered onto specific crosshair (+) image
        //3. Wait for x amount of time (float)
        RenderSettings.skybox = (black);
        cross.SetActive(true);
        yield return new WaitForSeconds(3f);
        cross.SetActive(false);
        playNextVideo(); //go to onEnd / playNextVideo method
    }

    void playNextVideo()
    {
        if (index < 16)
        {
            index++;
            string nextvideo = videonames[index];
            deja_vu_coroutine(nextvideo);
        }
        else
        {
            // just to check to make sure thing ended
            cross.SetActive(true);
            // yield return new WaitForSeconds(5f);
            // cross.SetActive(false);
            //GO back to a home scene that would play the study phase
            //switch scene //we’ll cover this later but you can use the scenemanager unity object from Unity.SceneManagement
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
