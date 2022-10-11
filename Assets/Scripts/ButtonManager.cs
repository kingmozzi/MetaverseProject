using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject LocationPanel;
    public GameObject HistoryPanel;
    public Text InfoKindText;
    public GameManager Manager;

    private string companyName;

    // Start is called before the first frame update
    void Start()
    {
        companyName = InfoKindText.text;
        InfoKindText.text += "/소개";
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
        InfoKindText.text = companyName;
    }

    public void ActiveInfo()
    {
        ActiveFalse();
        InfoPanel.SetActive(true);
        InfoKindText.text += "/소개";
    }

    public void ActiveLocation()
    {
        ActiveFalse();
        LocationPanel.SetActive(true);
        InfoKindText.text += "/위치";
    }

    public void ActiveHistory()
    {
        ActiveFalse();
        HistoryPanel.SetActive(true);
        InfoKindText.text += "/연혁";
    }

    public void CompanyInfoExit()
    {
        Manager.CompanyInfoExit();
    }

}
