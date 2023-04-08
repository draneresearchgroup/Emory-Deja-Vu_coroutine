using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJV_Trial
{
    public string videoName;
    public string videoNum;
    public string videoReference;
    public int audioReference;

    public DJV_Trial()
    {
        videoName ="";
        videoNum="";
        videoReference="";
        audioReference=0;
    }

    public DJV_Trial(string videoName, string videoNum, string videoReference, int audioReference)
    {
        this.videoName =videoName;
        this.videoNum=videoNum;
        this.videoReference=videoReference;
        this.audioReference=audioReference;
    }
  
}
