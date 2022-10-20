using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager4 : MonoBehaviour
{
    public GameManager Manager;
    public GameObject SelectPanel;
    public GameObject RequestPanel;
    public GameObject CommuPanel;
    public GameObject CreatePanel;
    public GameObject ReadPanel;
    public TransactionApi transaction;
    public GameObject UpdatePwPanel;
    public GameObject DeletePwPanel;
    public GameObject UpdatePanel;
    public InputField UpdatePw;
    public InputField DeletePw;
    public GameObject PwCheckPopup;

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
        UpdatePwPanel.SetActive(false);
        DeletePwPanel.SetActive(false);
        UpdatePanel.SetActive(false);
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

    public void ActiveUpdate()
    {
        if(UpdatePw.text == transaction.curPost.password)
        {
            ActiveFalse();
            UpdatePanel.SetActive(true);
        }
        else
        {
            PwCheckPopup.SetActive(true);
        }
    }

    public void ActiveDelete()
    {
        if(DeletePw.text == transaction.curPost.password)
        {
            transaction.DeleteOne();
            ActiveCommu();
        }
        else
        {
            PwCheckPopup.SetActive(true);
        }
    }

    public void ActiveUpdatePw()
    {
        ActiveFalse();
        UpdatePwPanel.SetActive(true);
    }

    public void ActiveDeletePw()
    {
        ActiveFalse();
        DeletePwPanel.SetActive(true);
    }

    public void PwCheckPopupExit()
    {
        PwCheckPopup.SetActive(false);
    }

    public void UpdateSubmit()
    {
        transaction.UpdateOne();
        ActiveCommu();
    }
}
