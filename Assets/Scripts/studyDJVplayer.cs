using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class studyDJVplayer : MonoBehaviour
{
    // study phase:  show video, play audio, display ISI cross-hair, then move to next video.
    private static int n = 16; // number of video clips, 16 but putting 4 for the sake of testing
    private VideoPlayer vp;
    private int index = 0;
    public Material skyboxMaterial;
    public Material black;
    public AudioClip[] audios = new AudioClip[n];
    public AudioSource audio;
    public GameObject VRplayer;
    private DataPrint DataPrinter;

    public GameObject cross;

    //CSV Reader and DJV Trials
    DJV_CSVReader csv_reader;
    DJV_Trial trial;
    List<DJV_Trial> trials;
    
    IEnumerator deja_vu_coroutine(DJV_Trial trial)
    {
        DataPrinter = new DataPrint();
        DataPrinter.sendttlPulse(2);
        DataPrinter.WriteToFile("SceneNum:" + trial.audioReference + "\n");
        DataPrinter.WriteToFile("Scene:"+trial.videoName+"\n");
        DataPrinter.WriteToFile("Order:" + index + "\n");
        DataPrinter.WriteToFile("=======================================" + "\n");


        string videoname = trial.videoName;
        vp.clip = Resources.Load<VideoClip>(trial.videoReference) as VideoClip;
        Debug.Log(trial.videoReference);
        audio.clip = audios[trial.audioReference]; //for some reason audio player wont load in audio source from resources.load so will instead pass an int value.

        // play dark screen
        RenderSettings.skybox = (black);
        VRplayer.transform.eulerAngles = new Vector3(0f,trial.rotation, 0f);
        vp.Prepare();
        // display crosshair image
        cross.SetActive(true);
        yield return new WaitForSeconds(3f);
        cross.SetActive(false);

        audio.Play();
        float time = (float) GetComponent<VideoPlayer>().clip.length;
        RenderSettings.skybox = skyboxMaterial;
        Debug.Log("Video loaded, now playing:  " + videoname);
        vp.Play();
        yield return new WaitForSeconds(time);

        DataPrinter.sendttlPulse(2);
        Debug.Log("Video finished playing");
        // play dark screen
        RenderSettings.skybox = (black);
        yield return new WaitForSeconds(1f);
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

            //Will move to in between phase instead. Will load in UI for this.
            SceneManager.LoadScene("TestPhaseInstructions");
        }
    }

    // Start is called before the first frame update
    void Start()
    {   
        csv_reader = new DJV_CSVReader();
        string version_name = PlayerPrefs.GetString("Study");
        trials = csv_reader.ReadTrialCSV(version_name);
        cross.SetActive(false);
        AudioSource audio = GetComponent<AudioSource>();
        vp = GetComponent<VideoPlayer>();
        
        StartCoroutine(deja_vu_coroutine(trials[index]));
    }

}