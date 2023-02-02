using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

//STUDY PHASE
public class study : MonoBehaviour
{
    public string[] videonames = new string[16];
    public VideoClip[] videos = new VideoClip[16];
    private VideoPlayer vp;
    public GameObject cross;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;

    IEnumerator deja_vu_coroutine(string videoname)
    {
        vp.Prepare();
        vp.Play();
        // redundant but can't erase due to compiling errors?
        if (vp.isPaused) {
            //play dark screen
            //1. Remove VP render new Skybox
            //2. Switch to Camera Rendered onto specific crosshair (+) image
            //3. Wait for x amount of time (float)
            RenderSettings.skybox = (black);
            cross.SetActive(true);
            yield return new WaitForSeconds(3f);
            cross.SetActive(false);
            playNextVideo();
        }
    }

    IEnumerator playNextVideo()
    {
        //play dark screen
        //1. Remove VP render new Skybox
        //2. Switch to Camera Rendered onto specific crosshair (+) image
        //3. Wait for x amount of time (float)
        RenderSettings.skybox = (black);
        cross.SetActive(true);
        yield return new WaitForSeconds(3);
        cross.SetActive(false);
        index += 1;
        if (index < 16)
        {
            string nextvideo = videonames[index];
            vp.clip = videos[index];
            RenderSettings.skybox = skyboxMaterial;
            deja_vu_coroutine(nextvideo);
        }
        else
        {
            // just to check to make sure thing ended
            cross.SetActive(true);
            yield return new WaitForSeconds(5f);
            cross.SetActive(false);
            //GO back to a home scene that would play the study phase
            //switch scene //we’ll cover this later but you can use the scenemanager unity object from Unity.SceneManagement
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        vp = GetComponent<VideoPlayer>();
        vp.clip = videos[index];
        RenderSettings.skybox = skyboxMaterial;
        StartCoroutine(deja_vu_coroutine(videonames[index]));
    }

    // Update is called once per frame
    void Update()
    {
        if (vp.isPaused) {
            StartCoroutine(playNextVideo());
        }
    }
}