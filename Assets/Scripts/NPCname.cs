using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCname : MonoBehaviour
{
    public Camera Cam;

    void Start()
    {
        
    }

    //NPC이름과 역할 UI을 항상 플레이어(카메라)를 바라보도록 설정함
    void Update()
    {
        transform.LookAt(Cam.transform);
    }
}
