using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DJVplayer : MonoBehaviour
{
    public string[] videonames = new string[16];
    public VideoClip[] videos = new VideoClip[16];
    private VideoPlayer vp;
    public GameObject cross;
    public GameObject UI;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public int condition = 0; // if 0, load study, if 1, load test

    IEnumerator deja_vu_coroutine(string videoname)
    {
        vp.clip = videos[index];
        RenderSettings.skybox = skyboxMaterial;
        vp.Prepare();
        vp.Play();
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator playNextVideo()
    {
        index += 1;
        if (index < 16)
        {
            string nextvideo = videonames[index];
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
            pause();
            playNextVideo();
        }
    }

    IEnumerator pause()
    {
        // study phase: play dark screen, crosshair image
        if (condition == 0) {
            RenderSettings.skybox = (black);
            cross.SetActive(true);
            yield return new WaitForSeconds(3);
            cross.SetActive(false);
        }
        // test phase: play dark screen, display UI
        else {
            RenderSettings.skybox = (black);
            UI.SetActive(true);
            yield return new WaitForSeconds(3);
            UI.SetActive(false);
        }       
    }
}