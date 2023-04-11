using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DJV
{
    private char turn;
    public int scenenum;
    public char studied;
    public string name;
    private VideoClip video;
    private AudioClip audio;


    public DJV(int num, VideoClip vClip, AudioClip aClip, string scenename, char turnCondition)
    {
        video = vClip;
        audio = aClip;
        turn = turnCondition;
        scenenum = num;
        name = scenename;
    }
    public DJV(int num, VideoClip vClip,  char turnCondition, string scenename, char studiedCondition)
    {
        scenenum = num;
        video = vClip;
        turn = turnCondition;
        studied = studiedCondition;
        name = scenename;
    }
    public VideoClip getVideo()
    {
        return video;
    }
    public AudioClip getAudio()
    {
        return audio;
    }

    public int getSceneNum()
    {
        return scenenum;
    }


}
