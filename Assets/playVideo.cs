using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class playVideo : MonoBehaviour
{
    private VideoPlayer testVideo;
    // Start is called before the first frame update
    void Start()
    {
        testVideo = GetComponent<VideoPlayer>();
        testVideo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}