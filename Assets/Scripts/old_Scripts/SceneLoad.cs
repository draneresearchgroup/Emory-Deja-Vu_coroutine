using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.IO.Ports;


public class SceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    Initializer init;
    public VideoPlayer vp;
    public VideoClip[] videoClips;
    public AudioClip[] audioClips;
    private VideoClip vid;
    private AudioClip sceneName;
    private DJV stimuli;
    private int version;
    private int condition;
    private int counter;
    private DataPrint DataPrinter;   //to write to file
    private string time;



    void Start()
    {
        DataPrinter = new DataPrint();
        counter = PlayerPrefs.GetInt("counter");
        condition = PlayerPrefs.GetInt("Condition");
        if (condition == 0){
            loadStudy();
        }
            
        else{
            loadTest();
        }
          StartCoroutine(waitToPlay());

    }
    void Update()
    {
        if (vp.isPaused)
        {
            if(condition == 0)
            {
                DataPrinter.sendttlPulse(2);
                waitToChange();
                SceneManager.LoadScene(0);
            }
            else if (condition == 1)
            {
                DataPrinter.sendttlPulse(2);
                waitToChange();
                SceneManager.LoadScene(67);  //participant response scene
            }
        }
    }

    void loadStudy()
    {
        AudioSource audio = GetComponent<AudioSource>();
        stimuli = Initializer.StudyDJVlist[0];
        if (counter > 0)
        {
            Initializer.StudyDJVlist.RemoveAt(0);
        }
        vid = stimuli.getVideo();
        sceneName = stimuli.getAudio();
        vp.clip = vid;
        vp.Prepare();
        DataPrinter.WriteToFile("SceneNum:" + stimuli.scenenum + "\n");
        DataPrinter.WriteToFile("Scene:"+stimuli.name+"\n");
        DataPrinter.WriteToFile("Order:" + counter + "\n");
       
    }

    void loadTest()
    {
        stimuli = Initializer.TestDJVlist[0];
        if (counter > 0)
        {
            Initializer.TestDJVlist.RemoveAt(0);
        }
        vid = stimuli.getVideo();
        vp.clip = vid;
        vp.Prepare();


        DataPrinter.WriteToFile("SceneNum:" + stimuli.scenenum + "\n");
        DataPrinter.WriteToFile("Scene:" + stimuli.name + "\n");
        DataPrinter.WriteToFile("Order:" + counter + "\n");
        DataPrinter.WriteToFile("Studied:" + stimuli.studied + "\n");
    }


    IEnumerator waitToPlay()
    {
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);
        time = "" + System.DateTime.Now;
        DataPrinter.sendttlPulse(2);
        DataPrinter.WriteToFile("Time:" + time + "\n");
        DataPrinter.WriteToFile("\n" + "==========================================================" + "\n");

        vp.Play();
        if (PlayerPrefs.GetInt("Condition")==0)
        {
           GetComponent<AudioSource>().clip = sceneName;
           GetComponent<AudioSource>().Play();
        }
      
 
    }
    IEnumerator waitToChange()
    {
        //yield on a new YieldInstruction that waits for 3 seconds.
        yield return new WaitForSeconds(3);
    }


}
