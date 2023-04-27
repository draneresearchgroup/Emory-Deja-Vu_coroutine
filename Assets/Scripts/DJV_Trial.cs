using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJV_Trial
{
    public string videoName;
    public string videoNum;
    public string videoReference;
    public int audioReference;
    public float duration;
    public float rotation;

    public DJV_Trial()
    {
        videoName ="";
        videoNum="";
        videoReference="";
        audioReference=0;
        duration =0f;
        rotation =0f;
    }

    public DJV_Trial(string videoName, string videoNum, string videoReference, int audioReference, float  duration, float rotation)
    {
        this.videoName =videoName;
        this.videoNum=videoNum;
        this.videoReference=videoReference;
        this.audioReference=audioReference;
        this.duration = duration;
        this.rotation = rotation;
    }
  
}
