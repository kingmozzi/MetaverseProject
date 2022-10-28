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

    void Start()
    {
        companyName = InfoKindText.text;
        InfoKindText.text += "/소개";
    }

    void Update()
    {
        
    }

    //모든패널 끄기
    void ActiveFalse()
    {
        InfoPanel.SetActive(false);
        LocationPanel.SetActive(false);
        HistoryPanel.SetActive(false);
        InfoKindText.text = companyName;
    }

    //모든패널 끄고 소개패널 활성화.
    public void ActiveInfo()
    {
        ActiveFalse();
        InfoPanel.SetActive(true);
        InfoKindText.text += "/소개";
    }

    //모든패널 끄고 위치패널 활성화.
    public void ActiveLocation()
    {
        ActiveFalse();
        LocationPanel.SetActive(true);
        InfoKindText.text += "/위치";
    }

    //모든패널 끄고 연혁패널 활성화.
    public void ActiveHistory()
    {
        ActiveFalse();
        HistoryPanel.SetActive(true);
        InfoKindText.text += "/연혁";
    }

    //회사정보창 끄기
    public void CompanyInfoExit()
    {
        Manager.CompanyInfoExit();
    }

}
