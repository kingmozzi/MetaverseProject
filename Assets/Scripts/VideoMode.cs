using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoMode : MonoBehaviour
{
    public GameObject VideoListPanel;
    public VideoPlayer VideoControl;
    public VideoClip[] Videos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VideoPlay()
    {
        VideoControl.Play();
    }

    public void VideoPause()
    {
        VideoControl.Pause();
    }

    public void VideoStop()
    {
        VideoControl.Stop();
    }

    public void ActiveVideoList()
    {
        VideoListPanel.SetActive(true);
    }

    public void VideoListExit()
    {
        VideoListPanel.SetActive(false);
    }

    public void VideoSelect(int index)
    {
        VideoControl.clip = Videos[index];
    }


}
