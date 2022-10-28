using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    void Start()
    {

    }

    //아이템 회전
    void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
        
    }
}
