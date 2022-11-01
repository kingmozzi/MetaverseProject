using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraContorl : MonoBehaviour
{
    public CinemachineFreeLook cam;
    public float x = 600f;
    public float y = 6f;

    bool fDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        LookAround();
    }

    void GetInput()
    {
        fDown = Input.GetButton("Fire2");
    }

    void LookAround()
    {
        if(fDown)
        {
            cam.m_XAxis.m_MaxSpeed = x;
            cam.m_YAxis.m_MaxSpeed = y;
        }
        else{
            cam.m_XAxis.m_MaxSpeed = 0f;
            cam.m_YAxis.m_MaxSpeed = 0f;
        }
    }
}
