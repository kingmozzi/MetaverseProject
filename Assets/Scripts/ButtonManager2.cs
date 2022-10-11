using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager2 : MonoBehaviour
{
    public GameObject PartPanel;
    public GameObject ServicePanel;
    public GameObject SpecialPanel;
    public Text InfoKindText;
    public GameManager Manager;
    public Image DetailImage;

    public GameObject DetailPanel;
    public Image namePanel;
    public Text itemName;
    public Image picturePanel;
    public Text detail;
    public Text value;
    public Toggle isLike;

    public GameObject SpDetailPanel;
    public Image SpNamePanel;
    public Text SpItemName;
    public Image SpDetailImage;
    public Text SpDetail;
    public Toggle SpIsLike;

    string companyName;
    int detailIndex;
    int SpDetailIndex;

    // Start is called before the first frame update
    void Awake()
    {
        // for(int i=0;i<Manager.itemLength;i++)
        // {

        // }
    }


    void Start()
    {
        companyName = InfoKindText.text;
        InfoKindText.text += "/부품";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActiveFalse()
    {
        PartPanel.SetActive(false);
        ServicePanel.SetActive(false);
        SpecialPanel.SetActive(false);
        InfoKindText.text = companyName;
    }

    public void ActivePart()
    {
        ActiveFalse();
        PartPanel.SetActive(true);
        InfoKindText.text += "/부품";
    }

    public void ActiveService()
    {
        ActiveFalse();
        ServicePanel.SetActive(true);
        InfoKindText.text += "/서비스";
    }

    public void ActiveSpecial()
    {
        ActiveFalse();
        SpecialPanel.SetActive(true);
        InfoKindText.text += "/특장";
    }

    public void ServiceInfoExit()
    {
        Manager.ServiceInfoExit();
    }

    public void ActiveDetail(int index)
    {
        Item temp = Manager.items[index];
        detailIndex = -1;
        switch(temp.grade)
        {
            case 0:
                namePanel.color = new Color(169/255f, 172/255f, 171/255f);
                picturePanel.color = new Color(124/255f, 126/255f, 125/255f);
                break;
            case 1:
                namePanel.color = new Color(41/255f, 144/255f, 114/255f);
                picturePanel.color = new Color(88/255f, 143/255f, 111/255f);
                break;
            case 2:
                namePanel.color = new Color(40/255f, 113/255f, 144/255f);
                picturePanel.color = new Color(85/255f, 128/255f, 163/255f);
                break;
            case 3:
                break;
        }

        itemName.text = temp.name;
        detail.text = temp.detail;
        value.text = (temp.value).ToString() + "\\";
        isLike.isOn = temp.isLike;
        DetailImage = temp.image;

        DetailPanel.SetActive(true);
        detailIndex = index;
    }

    public void toggleListener()
    {
        if(detailIndex == -1)
        {
            return;
        }
        if(isLike.isOn)
        {
            Manager.addCart(detailIndex);
        }
        else{
            Manager.deleteCart(detailIndex);
        }
    }

    public void DetailExit()
    {
        detailIndex=-1;
        DetailPanel.SetActive(false);
    }

    public void ActiveSpDetail(int index)
    {
        SpecialItem temp = Manager.SpItems[index];
        SpDetailIndex = -1;

        SpItemName.text = temp.name;
        SpDetail.text = temp.detail;
        SpIsLike.isOn = temp.isLike;
        SpDetailImage = temp.image;

        SpDetailPanel.SetActive(true);
        SpDetailIndex = index;
    }

    public void SpToggleListener()
    {
        if(SpDetailIndex == -1)
        {
            return;
        }
        // if(SpIsLike.isOn)
        // {
        //     Manager.addCart(detailIndex);
        // }
        // else{
        //     Manager.deleteCart(detailIndex);
        // }
    }


    public void SpDetailExit()
    {
        SpDetailIndex=-1;
        SpDetailPanel.SetActive(false);
    }


}
