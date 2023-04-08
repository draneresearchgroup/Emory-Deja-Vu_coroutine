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
    private DJV_Trial trial;
    private TextAsset text2read;


    

    public List<DJV_Trial> ReadTrialCSV(string version)
    {
        Debug.Log("version is:"+version);
        text2read  = Resources.Load(version) as TextAsset;
        String[] data = text2read.text.Split(new String[] {",","\n"}, StringSplitOptions.None);
        int tablesize = data.Length / 4-1;
        trials  = new List<DJV_Trial>();

        for(int i=0; i<tablesize; i++)
        {
            videoName = data[4*(i+1)];
            videoNum = data[4*(i+1)+1];
            videoReference = data[4*(i+1)+2];
            int.TryParse(data[4*(i+1)+3],out audioReference);

            trial = new DJV_Trial(videoName, videoNum, videoReference, audioReference);
            trials.Add(trial);
        }

        return trials;
    }

}