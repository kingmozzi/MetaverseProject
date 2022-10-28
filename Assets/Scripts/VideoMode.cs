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

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //비디오 재생
    public void VideoPlay()
    {
        VideoControl.Play();
    }

    //비디오 일시정지
    public void VideoPause()
    {
        VideoControl.Pause();
    }

    //비디오 정지
    public void VideoStop()
    {
        VideoControl.Stop();
    }

    //비디오 리스트 활성화
    public void ActiveVideoList()
    {
        VideoListPanel.SetActive(true);
    }

    //비디오 리스트 비활성화
    public void VideoListExit()
    {
        VideoListPanel.SetActive(false);
    }

    //비디오 선택
    public void VideoSelect(int index)
    {
        VideoControl.clip = Videos[index];
    }


}
