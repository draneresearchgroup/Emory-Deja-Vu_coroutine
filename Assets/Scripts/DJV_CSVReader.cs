using System.Resources;
using System.Runtime.Versioning;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DJV_CSVReader
{

    public List<DJV_Trial> trials;

    //trial reading components
    private string videoName;
    private string videoNum;
    private string videoReference;
    private int audioReference;
    private float duration;
    private float rotation;
    private DJV_Trial trial;
    private TextAsset text2read;


    

    public List<DJV_Trial> ReadTrialCSV(string version)
    {
        Debug.Log("version is:"+version);
        text2read  = Resources.Load(version) as TextAsset;
        String[] data = text2read.text.Split(new String[] {",","\n"}, StringSplitOptions.None);
        int tablesize = data.Length / 6-1;
        trials  = new List<DJV_Trial>();

        for(int i=0; i<tablesize; i++)
        {
            videoName = data[6*(i+1)];
            videoNum = data[6*(i+1)+1];
            videoReference = data[6*(i+1)+2];
            int.TryParse(data[6*(i+1)+3],out audioReference);
            float.TryParse(data[6*(i+1)+4],out duration);
            float.TryParse(data[6*(i+1)+5],out rotation);

            trial = new DJV_Trial(videoName, videoNum, videoReference, audioReference, duration, rotation);
            trials.Add(trial);
        }

        Shuffle(trials);
        return trials;
    }

    public List<DJV_Trial> ReadTestTrialCSV(string version)
    {
        Debug.Log("version is:"+version);
        text2read  = Resources.Load(version) as TextAsset;
        String[] data = text2read.text.Split(new String[] {",","\n"}, StringSplitOptions.None);
        int tablesize = data.Length / 6-1;
        trials  = new List<DJV_Trial>();

        for(int i=0; i<tablesize; i++)
        {
            videoName = data[6*(i+1)];
            videoNum = data[6*(i+1)+1];
            videoReference = data[6*(i+1)+2];
            int.TryParse(data[6*(i+1)+3],out audioReference);
            float.TryParse(data[6*(i+1)+4],out duration);
            float.TryParse(data[6*(i+1)+5],out rotation);

            trial = new DJV_Trial(videoName, videoNum, videoReference, audioReference, duration, rotation);
            trials.Add(trial);
        }

        Shuffle(trials);
        return trials;
    }

    void Shuffle(List<DJV_Trial> t)
    {
        int n = t.Count;
        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n);
            DJV_Trial value = t[k];
            t[k] = t[n];
            t[n] = value;
        }

    }

}