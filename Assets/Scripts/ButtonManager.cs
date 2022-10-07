using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject LocationPanel;
    public GameObject HistoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActiveFalse()
    {
        InfoPanel.SetActive(false);
        LocationPanel.SetActive(false);
        HistoryPanel.SetActive(false);
    }

    public void ActiveInfo()
    {
        ActiveFalse();
        InfoPanel.SetActive(true);
    }

    public void ActiveLocation()
    {
        ActiveFalse();
        LocationPanel.SetActive(true);
    }

    public void ActiveHistory()
    {
        ActiveFalse();
        HistoryPanel.SetActive(true);
    }

    public void CompanyInfoExit()
    {
        this.gameObject.SetActive(false);
    }

}
