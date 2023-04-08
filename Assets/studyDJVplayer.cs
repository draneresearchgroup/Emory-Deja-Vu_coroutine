using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


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
    public AudioClip[] audios = new AudioClip[n];
    public AudioSource audio;
    private AudioClip audioClip;

    private int frames = 30; // frame rate to change dynamically  //making private for current iteration
    public GameObject cross;

    //CSV Reader and DJV Trials
    DJV_CSVReader csv_reader;
    DJV_Trial trial;
    List<DJV_Trial> trials;
    
    IEnumerator deja_vu_coroutine(DJV_Trial trial)
    {

        string videoname = trial.videoName;
        vp.clip = Resources.Load<VideoClip>(trial.videoReference) as VideoClip;
        audio.clip = audios[trial.audioReference]; //for some reason audio player wont load in audio source from resources.load so will instead pass an int value.


        vp.Prepare();
        yield return new WaitForSeconds(3f);
        audio.Play();
        float time = (float) GetComponent<VideoPlayer>().clip.length;
        RenderSettings.skybox = skyboxMaterial;
        Debug.Log("Video loaded, now playing:  " + videoname);
        vp.Play();
        yield return new WaitForSeconds(time);

        Debug.Log("Video finished playing");
        // play dark screen
        RenderSettings.skybox = (black);
        // display crosshair image
        cross.SetActive(true);
        yield return new WaitForSeconds(3f);
        cross.SetActive(false);
        
        // trial block ends
        OnTrialEnd();
    
    }

    void OnTrialEnd(){
        index++;
        // for study phase — continue trials
        Debug.Log("OnTrialEnd reached");
        if(index < n) {
            Debug.Log("Loading new video...");
            StartCoroutine(deja_vu_coroutine(trials[index]));
        }

        else {
            // move to the test phase
            SceneManager.LoadScene("DJVTest");
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        csv_reader = new DJV_CSVReader();
        trials = csv_reader.ReadTrialCSV("test_version");
        cross.SetActive(false);
        AudioSource audio = GetComponent<AudioSource>();
        vp = GetComponent<VideoPlayer>();
        
        StartCoroutine(deja_vu_coroutine(trials[index]));
    }

   void Update()
   {
        Application.targetFrameRate = frames;
   }
}