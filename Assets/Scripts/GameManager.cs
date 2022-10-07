using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CompanyInfo;
    public GameObject InfoNPC;
    public Camera getCamera;

    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckNPC();
    }

    void CheckNPC()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.gameObject);
                if(hit.collider.gameObject == InfoNPC)
                {
                    Clicked();
                }
            }
        }
    }
    
    void Clicked()
    {
        CompanyInfo.SetActive(true);
    }

}
