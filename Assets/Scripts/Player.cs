using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TPS tps;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Floor tag와 충돌시 착지
    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Floor")
        {
           tps.Land(); 
        }
    }
}
