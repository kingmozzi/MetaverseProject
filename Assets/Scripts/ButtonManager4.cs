using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager4 : MonoBehaviour
{
    public GameManager Manager;
    public GameObject SelectPanel;
    public GameObject RequestPanel;
    public GameObject CommuPanel;
    public GameObject CreatePanel;
    public GameObject ReadPanel;
    public TransactionApi transaction;

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
        SelectPanel.SetActive(false);
        RequestPanel.SetActive(false);
        CommuPanel.SetActive(false);
        CreatePanel.SetActive(false);
        ReadPanel.SetActive(false);
    }

    public void ActiveSelect()
    {
        ActiveFalse();
        SelectPanel.SetActive(true);
    }

    public void AcitveRequest()
    {
        ActiveFalse();
        RequestPanel.SetActive(true);
    }

    public void ActiveCommu()
    {
        ActiveFalse();
        CommuPanel.SetActive(true);
    }

    public void ActiveCreate()
    {
        ActiveFalse();
        CreatePanel.SetActive(true);
    }

    public void CommunityExit()
    {
        ActiveSelect();
        Manager.CommunityExit();
    }

    public void ActiveRead(int id)
    {
        transaction.GetOne(id);
    }

    public void ActiveRead2()
    {
        ActiveFalse();
        ReadPanel.SetActive(true);
    }

    public void PostSubmit()
    {
        transaction.PostOne();
        ActiveCommu();
    }
}
