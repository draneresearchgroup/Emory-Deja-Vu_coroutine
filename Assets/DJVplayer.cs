using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DJVplayer : MonoBehaviour
{
    private static int n = 4; // number of video clips, 16 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public string[] videonames = new string[n];
    public VideoClip[] videos = new VideoClip[n];

    // study variables
    public string[] studyvideonames = new string[n];
    public VideoClip[] studyvideos = new VideoClip[n];
    public GameObject cross;

    // test variables
    public string[] testvideonames = new string[n];
    public VideoClip[] testvideos = new VideoClip[n];
    public GameObject UI;

    public int condition = 0; // if 0, load study, if 1, load test

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
                yield return new WaitForSeconds(5f);
                cross.SetActive(false);
            }
            // test phase: display UI
            else {
                UI.SetActive(true);
                yield return new WaitForSeconds(5f); // for UI things
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
            videonames = testvideonames;
            videos = testvideos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        load();
        vp = GetComponent<VideoPlayer>();
        
        StartCoroutine(deja_vu_coroutine(videonames[index]));
    }

    // Update is called once per frame
    void Update()
    {
    }
}